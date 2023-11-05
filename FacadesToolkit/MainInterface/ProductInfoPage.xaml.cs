using Autodesk.Revit.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Controls;

namespace FacadesToolkit
{
    public partial class ProductInfoPage : Page
    {
        public string Product;
        public string SQLActive;
        public string SQLStart;
        public string SQLFinish;
        public string SQLSubscribe;

        public DateTime dateTime = DateTime.Today.ToUniversalTime(); //Сегодняшняя дата

        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);

        public DBConnect dBConnect = new DBConnect();

        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable table = new DataTable();



        public ProductInfoPage(string productName)
        {
            InitializeComponent();

            ShowInfo(productName);
        }

        /// <summary>
        /// Отобразить информацию о подписке на выбранный модуль
        /// </summary>
        public void ShowInfo(string productName)
        {
            dBConnect.ConnectDB();

            string Product = productName;
            string SQLStart = productName + "Start";
            string SQLFinish = productName + "Finish";
            string SQLSubscribe = productName + "Subscribe";

            DateTime startDate;
            DateTime finishDate;

            string queryString = $"SELECT ID, CurrentIP, " + SQLStart + $"," + SQLFinish + $" FROM Users WHERE CurrentIP = '{address[0]}' and " + SQLSubscribe + $" > 0";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) //Если есть данные
                {
                    while (reader.Read())
                    {
                        //Вычисляем даты действительности ключа исходя из данных из БД
                        startDate = (new DateTime(1970, 1, 1)).AddSeconds((long)reader[SQLStart]);
                        finishDate = (new DateTime(1970, 1, 1)).AddSeconds((long)reader[SQLFinish]);

                        //Вывод данных о датах активности продукта в окно информации о продукте
                        StartDate.Content = startDate.ToShortDateString();
                        FinishDate.Content = finishDate.ToShortDateString();
                    }

                }
                reader.Close();

                //Вывод названия продукта в окно информации о продукте
                ProductLabel.Content = Product;
            }
        }
    }
}
