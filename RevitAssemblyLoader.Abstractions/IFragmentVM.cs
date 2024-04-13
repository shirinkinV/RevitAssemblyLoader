namespace RevitAssemblyLoader.Abstractions;

public interface IFragmentVM
{
    public IContainerVM ContainerVM { get; }

    public int RecomendedWindowWidth { get; }

    public int RecomendedWindowHeight { get; }

    public void ContentOnScreenAction();
}
