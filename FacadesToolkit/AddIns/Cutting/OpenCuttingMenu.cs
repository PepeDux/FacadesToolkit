using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace FacadesToolkit.AddIns.Cutting
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class OpenCuttingMenu : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DBQuery dBQuery = new DBQuery();

            if (dBQuery.Check("Cutting"))
            {
                CuttingMenu cuttingMenu = new CuttingMenu();
                cuttingMenu.Show();

                return Result.Succeeded;
            }
            else
            {
                TaskDialog.Show("Ошибка", "Вы не авторизованы. Проверьте актуальность ключа, либо повторно авторизуйтесь");
                //Переход на страницу
                dBQuery.Transition("Cutting");

                return Result.Failed;
            }
        }
    }
}
