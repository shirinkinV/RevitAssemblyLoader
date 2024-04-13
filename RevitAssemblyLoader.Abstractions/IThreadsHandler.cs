using System.Windows.Threading;

namespace RevitAssemblyLoader.Abstractions;

public interface IThreadsHandler
{
    public Dispatcher RevitDispatcher { get; }

    public Dispatcher UIDispatcher { get; }
}
