using Autodesk.Revit.UI;
using FacadesToolkit.MainInterface;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace FacadesToolkit
{
    public partial class MainWindow : Window
    {
        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);

        public string queryString; //Переменная отвечает за запросы SQL

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();



        DBConnect dBConnect = new DBConnect(); //Экземлпяр класса для подключения к БД
        public MainWindow()
        {

            InitializeComponent();

            MainFrame.Navigate(new StartPage());

            DBQuery dBQuery = new DBQuery();
            dBQuery.CheckAll();
   
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string queryString = $"SELECT ID, CurrentIP FROM Users WHERE CurrentIP='{address[0]}' or PastIp = '{address[0]}'";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                command.ExecuteNonQuery(); //Передача данных

                SqlCommand selectCommand = new SqlCommand(queryString, DBConnect.connect);
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы уже авторизованы!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                    table = new DataTable();
                }
                else
                {
                    //Переход на окно авторизации
                    MainFrame.Navigate(new SignUpPage());
                }
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            //Открытие информационного окна
            MainFrame.Navigate(new InfoPage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //Открытие окна настроек
            MainFrame.Navigate(new SettingsPage());
        }
    }
}
