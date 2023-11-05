using Autodesk.Revit.UI;
using FacadesToolkit.MainInterface;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;

namespace FacadesToolkit
{
    public class DBQuery
    {
        static string host = Dns.GetHostName();
        static IPAddress[] address = Dns.GetHostAddresses(host);

        DBConnect dBConnect = new DBConnect();

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private string[] products = new string[] { "Cutting", "Coordinater", "SFLIB" };

        public static DateTime currentTime = DateTime.Now.AddMinutes(10);
        public static long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();

        /// <summary>
        /// Все поля базы данных для проверки
        /// </summary>
        public void CheckAll()
        {
            //Checking checking = new Checking();
            //if (checking.ValidateChecksums() == true)
            //{
            dBConnect.ConnectDB();

            foreach(string product in products)
            {
                Check(product);
            }

            //}
            //else
            //{
            //    TaskDialog.Show("Отказ в доступе", "Обнаружены изменения! Дальнейшее использование ПО невозможно.");
            //}
        }

        /// <summary>
        /// Не все поля базы данных
        /// </summary>
        public void ProductUpdateAll()
        {
            //Checking checking = new Checking();
            //if (checking.ValidateChecksums() == true)
            //{

            foreach(string product in products)
            {
                ProductUpdate(product);
            }

            //}
            //else
            //{
            //    TaskDialog.Show("Отказ в доступе", "Обнаружены изменения! Дальнейшее использование ПО невозможно.");
            //}
        }

        /// <summary>
        /// Метод проверки модуля
        /// </summary>
        public bool Check(string product)
        {
            //Checking checking = new Checking();
            //if (checking.ValidateChecksums() == true)
            //{
            dBConnect.ConnectDB();

            string SQLActive = product + "Active";
            string SQLStart = product + "Start";
            string SQLFinish = product + "Finish";
            string SQLSubscribe = product + "Subscribe";

            //Удаление данных если дата активности прродукта просрочена
            string queryString = $"UPDATE Users SET " + SQLActive + $"='False'," + SQLStart + $"=null," + SQLFinish + $"=null," + SQLSubscribe + $"=null WHERE CurrentIP='{address[0]}' and (" + SQLStart + $" > '{unixTime}' or " + SQLFinish + $" < '{unixTime}')";

            using (SqlCommand command2 = dBConnect.Query(queryString))
            {
                command2.ExecuteNonQuery();
            }



            queryString = $"SELECT ID, " + SQLStart + $"," + SQLFinish + $", CurrentIP FROM Users WHERE " + SQLStart + $" <= '{unixTime}' and " + SQLFinish + $" >= '{unixTime}' and CurrentIP = '{address[0]}'";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    table = new DataTable();
                    return true;
                }
                else
                {
                    table = new DataTable();
                    return false;                    
                }    
            }


            //}
            //else
            //{
            //    TaskDialog.Show("Отказ в доступе", "Обнаружены изменения! Дальнейшее использование ПО невозможно.");
            //}
        }

        /// <summary>
        /// Метод обновления подключения
        /// </summary>
        public void ProductUpdate(string product)
        {
            //Checking checking = new Checking();
            //if (checking.ValidateChecksums() == true)
            //{

            string SQLActive = product + "Active";
            string SQLStart = product + "Start";
            string SQLFinish = product + "Finish";
            string SQLSubscribe = product + "Subscribe";

            dBConnect.ConnectDB();

            int subscribe = 0;


            string queryString = $"SELECT ID, CurrentIP," + SQLSubscribe + $" FROM Users WHERE CurrentIP='{address[0]}' and " + SQLSubscribe + $" is not null";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                table = new DataTable();
                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) //Если есть данные
                    {
                        while (reader.Read())
                        {
                            subscribe = (int)reader[SQLSubscribe];
                        }
                    }

                    reader.Close();

                    if (subscribe > 0)
                    {
                        DateTime futureTime = DateTime.Now.AddMonths(subscribe);
                        long futureUnixTime = ((DateTimeOffset)futureTime).ToUnixTimeSeconds();

                        queryString = $"UPDATE Users SET " + SQLActive + $"='True', " + SQLStart + $"='{unixTime - 600}', " + SQLFinish + $"='{futureUnixTime}' WHERE CurrentIP='{address[0]}' and " + SQLStart + $" is null and " + SQLFinish + $" is null and " + SQLActive + $"='False' and " + SQLSubscribe + $" <> 0 and " + SQLSubscribe + $" is not null";

                        using (SqlCommand command3 = dBConnect.Query(queryString))
                        {
                            command3.ExecuteNonQuery(); //Передача данных
                        }
                    }
                }
            }
            //}
            //else
            //{
            //    TaskDialog.Show("Отказ в доступе", "Обнаружены изменения! Дальнейшее использование ПО невозможно.");
            //}
        }


        /// <summary>
        /// Автовход
        /// </summary>
        public void AutoEntry()
        {
            dBConnect.ConnectDB();

            string queryString = $"UPDATE Users SET CurrentIP='{address[0]}' WHERE PastIP='{address[0]}' and CurrentIP is null";

            using (SqlCommand command2 = dBConnect.Query(queryString))
            {
                command2.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Автовыход
        /// </summary>
        public void AutoExit()
        {
            dBConnect.ConnectDB();

            string queryString;

            queryString = $"UPDATE Users SET PastIP = '{address[0]}' WHERE CurrentIP='{address[0]}'";

            using (SqlCommand command3 = dBConnect.Query(queryString))
            {
                command3.ExecuteNonQuery(); //Передача данных
            }



            queryString = $"UPDATE Users SET CurrentIP = null WHERE CurrentIP='{address[0]}'";

            using (SqlCommand command3 = dBConnect.Query(queryString))
            {
                command3.ExecuteNonQuery(); //Передача данных
            }
        }

        /// <summary>
        /// Метод для перенаправки пользователя на одну из страниц плагина
        /// </summary>
        /// <param name="path"></param>
        public void Transition(string path)
        {
            MainWindow mainWindow = new MainWindow();

            string queryString = $"SELECT ID, CurrentIP FROM Users WHERE CurrentIP='{address[0]}'";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                table = new DataTable();

                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    // Переход на страницу информации о продукте
                    mainWindow.Show();
                    DataBank.currentFunctional = path;
                    mainWindow.MainFrame.Navigate(new InfoPage());
                }
                else
                {
                    // Переход на страницу регистрации
                    mainWindow.Show();
                    mainWindow.MainFrame.Navigate(new SignUpPage());
                }
            }
        }

        /// <summary>
        /// Проверка на версию
        /// </summary>
        /// <returns></returns>
        public bool VersionCheck()
        {
            dBConnect.ConnectDB();

            string queryString = $"SELECT ID, Version FROM General WHERE Version='{Properties.Settings.Default["Version"]}'";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                table = new DataTable();

                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
