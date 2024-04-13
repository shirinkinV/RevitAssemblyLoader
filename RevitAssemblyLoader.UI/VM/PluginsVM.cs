using RevitAssemblyLoader.Abstractions;
using RevitAssemblyLoader.Abstractions.VM.Fragments;

namespace RevitAssemblyLoader.UI.VM;

public class PluginsVM : ObservableObject, IPluginsVM
{
    public IContainerVM ContainerVM => throw new NotImplementedException();

    public int RecomendedWindowWidth => throw new NotImplementedException();

    public int RecomendedWindowHeight => throw new NotImplementedException();

    public void ContentOnScreenAction()
    {
        throw new NotImplementedException();
    }
}
