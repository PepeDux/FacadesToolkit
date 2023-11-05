using System;

namespace FacadesToolkit
{
    internal class DataBank
    {
        //public static bool cuttingActive;       // статус продукта - подрезка
        //public static bool stackerActive;       // статус продукта - раскладка
        //public static bool coordinaterActive;   // статус продукта - геодезия
        //public static bool sflibActive;         // статус продукта - каталог семейств

        public static string currentFunctional;

        public static int indent;           // отступ обрезки

        public static int cutType = 1;      // сторона подрезки

        public static string path = null;   // путь до файла

        public static int digit;            // чисел после запятой

        public static double rate;          // смещение запятой

        public static int separator = 1;    // разделитель в числах

        public static Guid dockablePaneGuid = new Guid("{31F293CF-5686-45CB-8C10-60CF2A33DDAB}");   // DockablePane ID

        public static string selectedItemPath = null;   // выбранный элемент treeview
    }
}