namespace RevitAssemblyLoader.Abstractions.VM;

public interface IPluginVM
{
    List<IExternalCommandVM> ExternalCommands { get; }
}
