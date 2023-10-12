using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAssemblyLoader.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RevitAssemblyLoader
{
    [Transaction(TransactionMode.Manual)]
    public class Startup : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var newThread = new Thread(() =>
            {
                var window = new MainWindow();
                window.Show();
                Dispatcher.Run();
            });
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();

            return Result.Succeeded;
        }
    }
}
