namespace RevitAssemblyLoader.Abstractions;

public interface IContainerVM
{
    IFragmentVM Content { get; set; }

    List<IFragmentVM> PosibleFragments { get; }

    Action ApplicationClosing { get; }

    void InvokeApplicationClosing();
}
