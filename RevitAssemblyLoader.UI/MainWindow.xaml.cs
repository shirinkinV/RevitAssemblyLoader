using RevitAssemblyLoader.Abstractions;
using System.Windows;

namespace RevitAssemblyLoader.UI;

public partial class MainWindow : Window
{
    public MainWindow(IContainerVM mainVM)
    {
        InitializeComponent();
        DataContext = mainVM;
        (DataContext as MainVM).PropertyChanged += Content_PropertyChanged;
    }

    private void Content_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MainVM.Content))
        {
            Width = (DataContext as MainVM).Content.RecomendedWindowWidth;
            Height = (DataContext as MainVM).Content.RecomendedWindowHeight;
        }
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Dispatcher.InvokeShutdown();
#if !DESIGN
        (DataContext as MainVM).ApplicationClosing?.Invoke();
#endif
    }
}
