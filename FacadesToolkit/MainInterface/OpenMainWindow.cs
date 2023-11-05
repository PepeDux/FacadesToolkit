using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace FacadesToolkit
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    internal class OpenMainWindow : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Открытие главного меню
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            return Result.Succeeded;
        }
    }
}