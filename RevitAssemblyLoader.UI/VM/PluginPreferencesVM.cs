using RevitAssemblyLoader.Abstractions;
using RevitAssemblyLoader.Abstractions.VM;
using RevitAssemblyLoader.Abstractions.VM.Fragments;

namespace RevitAssemblyLoader.UI.VM;

public class PluginPreferencesVM : IPluginPreferencesVM
{
    public IPluginVM Plugin => throw new NotImplementedException();

    public IContainerVM ContainerVM => throw new NotImplementedException();

    public int RecomendedWindowWidth => throw new NotImplementedException();

    public int RecomendedWindowHeight => throw new NotImplementedException();

    public void ContentOnScreenAction()
    {
        throw new NotImplementedException();
    }
}
