using RevitAssemblyLoader.Abstractions;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Windows.Threading;

namespace RevitAssemblyLoader.Model;

public class Logger : Ilogger, IDisposable
{
    static string ALL_LOGS_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "shirinkinV", "RevitAssemblyLoader");
    static string LOGGER_INTERNAL_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "shirinkinV", "LoggerInternal");
    private bool _writing;
    private Dispatcher _backgroundDispatcher;
    private readonly Thread _backgroundThread;
    private readonly string _finalLogPath;

    private readonly bool _keepFileOpen;
    private readonly bool _isBackgroundMode;
    private readonly FileStream _fileStream;
    private readonly StreamWriter _streamWriter;
    private readonly ConcurrentQueue<string> _messages;

    private Dispatcher BackgroundDispatcher
    {
        get
        {
            _backgroundDispatcher ??= Dispatcher.FromThread(_backgroundThread);
            while (_backgroundDispatcher is null)
            {
                Thread.Sleep(100);
                _backgroundDispatcher = Dispatcher.FromThread(_backgroundThread);
            }
            return _backgroundDispatcher;
        }
    }

    public Logger()
    {
        if (!Directory.Exists(ALL_LOGS_FOLDER))
            Directory.CreateDirectory(ALL_LOGS_FOLDER);
        if (!Directory.Exists(LOGGER_INTERNAL_FOLDER))
            Directory.CreateDirectory(LOGGER_INTERNAL_FOLDER);
        var dateTime = DateTime.Now;
        _finalLogPath = Path.Combine(ALL_LOGS_FOLDER, $"{dateTime:dd.MM.yyyy}.log");//пишем логи на 1 день в отдельном файле
        _keepFileOpen = false;
        _isBackgroundMode = true;
        var fileExistsFlag = File.Exists(_finalLogPath);
        if (_keepFileOpen)
        {
            if (fileExistsFlag)
            {
                try
                {
                    _fileStream = new FileStream(_finalLogPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                    _streamWriter = new StreamWriter(_fileStream, Encoding.UTF8);
                }
                catch (Exception e)
                {
                    File.WriteAllText(Path.Combine(LOGGER_INTERNAL_FOLDER, $"{DateTime.Now.Ticks}.log"), $"{e}");
                }
            }
            else
            {
                _fileStream = new FileStream(_finalLogPath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                _streamWriter = new StreamWriter(_fileStream, Encoding.UTF8);
            }
        }

        if (_isBackgroundMode)
        {
            _messages = [];
            _backgroundThread = new Thread(Dispatcher.Run)
            {
                Name = $"RevitAssemblyLoader logger thread"
            };
            _backgroundThread.Start();
        }
    }

    public void Dispose()
    {
        try
        {
            _streamWriter?.Close();
            _streamWriter?.Dispose();
        }
        catch { }
        try
        {
            _fileStream?.Flush();
            _fileStream?.Dispose();
        }
        catch { }
        try
        {
            BackgroundDispatcher.InvokeShutdown();
        }
        catch { }
    }

    private void WriteMessageSync(string message)
    {
        try
        {
            if (_keepFileOpen)
            {
                _streamWriter.Write(message);
                _streamWriter.WriteLine();
                _streamWriter.Flush();
                _fileStream.Flush();
            }
            else
            {
                using var file = new FileStream(_finalLogPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                using var sw = new StreamWriter(file, Encoding.UTF8);
                sw.Write(message);
                sw.WriteLine();
            }
        }
        catch (Exception e)
        {
            File.WriteAllText(Path.Combine(LOGGER_INTERNAL_FOLDER, $"{DateTime.Now.Ticks}.log"), $"{e}");
        }
    }

    private void WriteMessageAsync(string message)
    {
        _messages.Enqueue(message);
        CheckMessages();
    }

    private void BackgroundThreadFuncrion()
    {
        while (_messages.Count > 0)
        {
            var succesDequeued = _messages.TryDequeue(out var message);
            if (!succesDequeued)
            {
                Thread.Sleep(10);
                continue;
            }
            WriteMessageSync(message);
        }
        _writing = false;
    }

    private void CheckMessages()
    {
        if (_writing)
            return;
        _writing = true;
        BackgroundDispatcher.InvokeAsync(BackgroundThreadFuncrion);
    }

    private void WriteMessage(int level, string message)
    {
        var datetime = DateTime.Now.ToString("dd.MM.yyyy_HH:mm:ss");
        var levelString = level switch
        {
            0 => "INFO",
            1 => "DEBUG",
            2 => "WARNING",
            3 => "ERROR",
            4 => "FATAL",
            _ => "NONE",
        };

        var resultStr = string.Join("||", datetime, levelString, message, "#");

        if (_isBackgroundMode)
            WriteMessageAsync(resultStr);
        else
            WriteMessageSync(resultStr);
    }

    public void Info(string message) => WriteMessage(0, message);

    public void Debug(string message) => WriteMessage(1, message);

    public void Warn(string message) => WriteMessage(2, message);

    public void Error(string message) => WriteMessage(3, message);

    public void Fatal(string message) => WriteMessage(4, message);
}
