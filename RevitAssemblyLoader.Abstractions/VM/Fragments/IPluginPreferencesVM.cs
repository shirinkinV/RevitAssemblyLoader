namespace RevitAssemblyLoader.Abstractions.VM.Fragments;

public interface IPluginPreferencesVM : IFragmentVM
{
    IPluginVM Plugin { get; }

}
