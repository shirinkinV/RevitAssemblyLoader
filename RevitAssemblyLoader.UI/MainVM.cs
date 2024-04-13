using RevitAssemblyLoader.Abstractions;
using RevitAssemblyLoader.Abstractions.VM.Fragments;

namespace RevitAssemblyLoader.UI;

public class MainVM : ObservableObject, IContainerVM
{
    public MainVM()
    {
        Title = $"RevitAssemblyLoader {GetType().Assembly.GetName().Version}";
    }

    IFragmentVM _content;
    public IFragmentVM Content
    {
        get => _content ??= PosibleFragments.OfType<IPluginsVM>().Single();
        set
        {
            if (Set(ref _content, value))
                _content.ContentOnScreenAction();
        }
    }

    private string title;

    public string Title { get => title; set => Set(ref title, value); }

    List<IFragmentVM> _posibleFragments = [];

    public List<IFragmentVM> PosibleFragments => _posibleFragments;

    public Action ApplicationClosing => () => { };

    public event Action AppClosingOccured;

    public void InvokeApplicationClosing()
    {
        AppClosingOccured?.Invoke();
    }
}
