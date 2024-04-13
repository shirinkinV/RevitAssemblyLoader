using System.Windows.Threading;
using System.Windows;
using RevitAssemblyLoader.Abstractions;

namespace RevitAssemblyLoader.Model;

public class ThreadsHandler : IThreadsHandler
{
    private readonly Dispatcher revitDispatcher;
    private readonly Thread UIThread;
    private readonly Ilogger log;

    public ThreadsHandler(Ilogger log)
    {
        revitDispatcher = Dispatcher.CurrentDispatcher;
        var syncContext = SynchronizationContext.Current;
        //create UI thread with dispatcher
        UIThread = new Thread(() =>
        {
            SynchronizationContext.SetSynchronizationContext(syncContext);
            Dispatcher.Run();
        });
        UIThread.SetApartmentState(ApartmentState.STA);
        UIThread.Name = $"RevitAssemblyLoader main UI thread";
        UIThread.Start();
        while (UIDispatcher is null)
        {
            //wait ui thread running
            Thread.Sleep(100);
        }
        UIDispatcher.UnhandledException += PluginUIDispatcher_UnhandledException;
        this.log = log;
    }

    private void PluginUIDispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var ex = e.Exception;
        log.Error($"Fatal exception UIThread{ex}");
        FatalErrorAction?.Invoke();
        MessageBox.Show($"Fatal unhandled error RevitAssemblyLoader\n(╯°□°）╯︵ ┻━┻\n\n{ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        SynchronizationContext.SetSynchronizationContext(null);
        if (UIDispatcher.Thread.ThreadState == ThreadState.Running)
            UIDispatcher.Thread.Abort();
    }

    public Dispatcher RevitDispatcher => revitDispatcher;

    public Dispatcher UIDispatcher => Dispatcher.FromThread(UIThread);

    public event Action FatalErrorAction;
}
