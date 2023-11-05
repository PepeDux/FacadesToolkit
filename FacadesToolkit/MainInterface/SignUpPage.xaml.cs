using Autodesk.Revit.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FacadesToolkit.MainInterface
{
    public partial class SignUpPage : Page
    {
        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);

        string queryString; //Переменная отвечает за запросы SQL

        public static DateTime currentTime = DateTime.Now;
        public static long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        DBConnect dBConnect = new DBConnect(); //Экземлпяр класса для подключения к БД

        public SignUpPage()
        {

            InitializeComponent();

            dBConnect.ConnectDB(); //Подключение к БД

            DBQuery dBQuery = new DBQuery();
            dBQuery.CheckAll();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;        // Логин 
            string pass = Password.Password; // Пароль
            string source = Source.Text;    // Ключ продукта

            DBQuery dBQuery = new DBQuery();


            // Авторизация
            queryString = $"SELECT ID, Login, Password, Source, CurrentIP FROM Users WHERE Login = '{login}' and Password = '{pass}' and Source = '{source}' and CurrentIP is null";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                command.ExecuteNonQuery(); //Передача данных

                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    //Запись текущего IP при верно введенных данных
                    queryString = $"UPDATE Users SET CurrentIP='{address[0]}' WHERE Login = '{login}' and Password = '{pass}' and Source = '{source}'";

                    using (SqlCommand command2 = dBConnect.Query(queryString))
                    {
                        command2.ExecuteNonQuery(); //Передача данных
                    }

                    MessageBox.Show("Вы авторизировались", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);


                    dBQuery.ProductUpdateAll();


                    //Возвращаемся на стартовый экран
                    NavigationService.Navigate(new StartPage());
                }
                else
                {
                    MessageBox.Show("Неверные данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            Login.Text = "";
            Password.Password = "";
            Source.Text = "";
        }
    }
}