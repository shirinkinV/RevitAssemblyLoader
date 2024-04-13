namespace RevitAssemblyLoader.Abstractions;

public interface Ilogger
{
    void Info(string message);
    void Debug(string message);
    void Warn(string message);
    void Error(string message);
    void Fatal(string message);
}
