using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace FacadesToolkit
{
    public class PlugginPanel : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            // Автовыход при закрытии Revit
            DBQuery dBQuery = new DBQuery();
            dBQuery.AutoExit();

            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // Проверка значений БД и автовход
            DBQuery dBQuery = new DBQuery();

            if (dBQuery.VersionCheck())
            {

                dBQuery.AutoEntry();
                dBQuery.ProductUpdateAll();
                dBQuery.CheckAll();

                // Получение пути до сборки
                Assembly assemblyPath = Assembly.GetExecutingAssembly();
                string assemblyDir = new FileInfo(assemblyPath.Location).DirectoryName;

                // Название вкладок, панелей
                string tabName = "Facades Toolkit";
                string panelName0 = "Скрипты";

                // Создание вкладки и добавление в неё панелей
                application.CreateRibbonTab(tabName);
                RibbonPanel panelMain = application.CreateRibbonPanel(tabName, panelName0);


                PushButtonData createButton(string uniqueName, string name, string className, string longDescript, string pathToImage)
                {
                    var imagePath = Path.Combine(assemblyDir, pathToImage);

                    PushButtonData button = new PushButtonData(
                        uniqueName,
                        name,
                        assemblyPath.Location,
                        className)
                    {
                        LongDescription = longDescript,
                        LargeImage = new BitmapImage(new Uri(imagePath))
                    };

                    return button;
                }


                // Инициализация кнопок
                PushButtonData mainMenu = createButton(
                    "Main menu",
                    "Главное меню",
                    "FacadesToolkit.OpenMainWindow",
                    "Главное пользовательское меню. Содержит в себе блок авторизации, информации о подписках и настройки.",
                    @"Resources\profile_avatar.ico");

                PushButtonData cutting = createButton(
                    "Cutting",
                    "Запуск",
                    "FacadesToolkit.AddIns.Cutting.Cutting",
                    "Запуск скрипта подрезки. Если требуются дополнительные параметры - перейдите в меню подрезки.",
                    @"Resources\scissors.ico");

                PushButtonData cuttingMenu = createButton(
                    "Cutting menu",
                    "Меню подрезки",
                    "FacadesToolkit.AddIns.Cutting.OpenCuttingMenu",
                    "Меню подрезки. Позволяет настраивать отдельные параметры скрипта",
                    @"Resources\settings.ico");

                PushButtonData coordinaterRead = createButton(
                    "Coordinater Reader",
                    "Чтение",
                    "FacadesToolkit.AddIns.Coordinater.ReadCoordinates",
                    "Выполнить чтение файла. По умолчанию читает файл 'Координата.txt' лежащий на рабочем столе. После операции на указанных координатах появляется маркировка или экземпляры семейства Координатная точка.",
                    @"Resources\document_srch.ico");

                PushButtonData coordinaterWrite = createButton(
                    "Coordinater Writer",
                    "Запись",
                    "FacadesToolkit.AddIns.Coordinater.CategoryDetector",
                    "Выполнить запись в файл. По умолчанию создаёт на рабочем столе файл 'Координата.txt'. Дополнительные параметры настраиваются в 'Меню геодезии'.",
                    @"Resources\document_edit.ico");

                PushButtonData coordinaterMenu = createButton(
                    "Coordinater menu",
                    "Меню геодезии",
                    "FacadesToolkit.AddIns.Coordinater.StartupWindow",
                    "Меню геодезии. Позволяет настраивать отдельные параметры скрипта",
                    @"Resources\settings.ico");

                PushButtonData sflibShow = createButton(
                    "SFLIB Open",
                    "Показать каталог",
                    "FacadesToolkit.AddIns.SFLIB.ShowDockablePane",
                    "Открывает каталог семейств, позиционирует окно в ранее открытом месте.",
                    @"Resources\bulb.ico");

                PushButtonData sflibLoad = createButton(
                    "SFLIB Load",
                    "Загрузить семейство",
                    "FacadesToolkit.AddIns.SFLIB.Loader",
                    "Выполняет загрузку выбранного семейства в проект. Выбор происходит в окне SFLIB кликом ПКМ по семейству и выбором пункта 'загрузить в проект'.",
                    @"Resources\load_family.ico");


                panelMain.AddItem(mainMenu);
                panelMain.AddSeparator();
                panelMain.AddItem(cutting);
                panelMain.AddItem(cuttingMenu);
                panelMain.AddSeparator();
                panelMain.AddItem(coordinaterRead);
                panelMain.AddItem(coordinaterWrite);
                panelMain.AddItem(coordinaterMenu);
                panelMain.AddSeparator();
                panelMain.AddItem(sflibShow);
                panelMain.AddItem(sflibLoad);

                // добавлление DockablePane
                //RegisterDockablePane(application);
            }
            else
            {
                TaskDialog.Show("Ошибка", "Вы не авторизованы. Проверьте актуальность ключа, либо повторно авторизуйтесь");
            }
            return Result.Succeeded;
        }
    }
}