using System.Windows.Input;

namespace RevitAssemblyLoader.Abstractions.VM;

public interface IExternalCommandVM
{
    ICommand RunCommand { get; }

    string CommandName {  get; }

    object CommandSource {  get; }
}
