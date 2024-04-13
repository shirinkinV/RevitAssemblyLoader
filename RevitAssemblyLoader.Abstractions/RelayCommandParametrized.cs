using System.Windows.Input;

namespace RevitAssemblyLoader.Abstractions;

public class RelayCommand<ParameterT>(Action<ParameterT> execute, Func<ParameterT, bool> canExecute = null) : ICommand
{
    private readonly Action<ParameterT> execute = execute;
    private readonly Func<ParameterT, bool> canExecute = canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) => canExecute is null || canExecute((ParameterT)parameter);

    public void Execute(object parameter) => execute((ParameterT)parameter);

    public static implicit operator RelayCommand<ParameterT>(Action<ParameterT> action) => new(action);

}
