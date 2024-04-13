namespace RevitAssemblyLoader.Abstractions;

public class NavigationCommand<TContainerVM, TFragmentVM> : RelayCommand where TContainerVM : IContainerVM where TFragmentVM : IFragmentVM
{
    public NavigationCommand(
        string commandText,
        TContainerVM containerVM,
        string? commandTooltip = null,
        Func<bool>? canExecute = null)
        : base(() =>
        {
            containerVM.Content = containerVM.PosibleFragments.Where(x => x.GetType() == typeof(TFragmentVM)).Single();
        }, canExecute)
    {
        CommandText = commandText;
        CommandTooltip = commandTooltip;
    }

    public string CommandText { get; }

    public string? CommandTooltip { get; }
}
