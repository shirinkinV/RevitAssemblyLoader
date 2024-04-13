using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Threading;

namespace RevitAssemblyLoader
{
    [Transaction(TransactionMode.Manual)]
    public class Startup : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            /*var newThread = new Thread(() =>
            {
                var window = new MainWindow();
                window.Show();
                window.Closing += Window_Closing;
                Dispatcher.Run();
            });
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();*/
            return Result.Succeeded;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();
        }
    }
}
