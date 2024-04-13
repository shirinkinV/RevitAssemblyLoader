using System.Windows.Input;

namespace RevitAssemblyLoader.Abstractions;

public class RelayCommand(Action execute, Func<bool>? canExecute = null) : ICommand
{
    private readonly Action execute = execute;
    private readonly Func<bool>? canExecute = canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter) => canExecute is null || canExecute();

    public void Execute(object parameter) => execute();

    public static implicit operator RelayCommand(Action action) => new(action);
}
