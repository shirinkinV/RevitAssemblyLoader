using Microsoft.Extensions.DependencyInjection;
using RevitAssemblyLoader.Abstractions;
using RevitAssemblyLoader.DI;
using System.Windows;

namespace RevitAssemblyLoader.UITest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IThreadsHandler threadsHandler;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //initialize DI Container and show main window
        var serviceContainer = Services.Instance;
        var services = Services.Instance.ServiceProvider;
        threadsHandler = services.GetRequiredService<IThreadsHandler>();
        threadsHandler.UIDispatcher.InvokeAsync(() =>
        {
            var window = services.GetRequiredService<Window>();
            window.Closed += Window_Closed;
            window.Show();
        });
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Services.KillServices();
        threadsHandler.RevitDispatcher.InvokeShutdown();
    }
}