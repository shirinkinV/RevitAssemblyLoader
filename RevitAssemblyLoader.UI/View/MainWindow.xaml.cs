using RevitAssemblyLoader.UI.VM;
using RevitAssemblyLoader.UI.VM;
using System.Windows;

namespace RevitAssemblyLoader.UI.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Dispatcher.InvokeShutdown();
        }
    }
}
