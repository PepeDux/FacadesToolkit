using Autodesk.Revit.UI;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FacadesToolkit.Properties;

namespace FacadesToolkit
{
    public class DBConnect
    {
        public static SqlConnection connect;
        private string encodedCs = Settings.Default["Connect"].ToString();

        public void ConnectDB()
        {
            //Checking checking = new Checking();
            //if (checking.ValidateChecksums() == true)
            //{
            try
            {
                //Подключение к БД
                connect = new SqlConnection("Строка подключения к БД");
                connect.Open();
            }
            catch
            {
                TaskDialog.Show("Ошибка", "Невозможно подключиться к базе данных. Плагин будет отключён. Рекомендуется проверить интернет-подключение.");
                if (connect != null)
                {
                    connect.Close();
                }
            }
            //}
            //else
            //{
            //    TaskDialog.Show("Отказ в доступе", "Обнаружены изменения! Дальнейшее использование ПО невозможно.");
            //    if (connect != null)
            //    {
            //        connect.Close();
            //    }
            //}
        }

        //Метод для более удобного обращения к БД
        public SqlCommand Query(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connect);
            return command;
        }

    }
}