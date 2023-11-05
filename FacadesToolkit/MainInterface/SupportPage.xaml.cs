using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System;
using Autodesk.Revit.UI;

namespace FacadesToolkit
{
    public partial class SupportPage : Page
    {
        public DBConnect dBConnect = new DBConnect();

        public static string host = Dns.GetHostName();
        public static IPAddress[] address = Dns.GetHostAddresses(host);

        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable table = new DataTable();
        public SupportPage()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            dBConnect.ConnectDB();

            string email;
            string report;
            string login = "";

            string queryString = $"SELECT ID, CurrentIP, Login FROM Users WHERE CurrentIP = '{address[0]}'";

            using (SqlCommand command = dBConnect.Query(queryString))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) //Если есть данные
                {
                    while (reader.Read())
                    {
                        login = reader["Login"].ToString();
                    }
                }
                else
                {
                    login = "Не авторизован";
                }

                reader.Close();
            }



            if (MessageTextBox.Text != "")
            {
                if (Email.Text == "")
                {
                    email = "Аноним";
                }
                else
                {
                    email = Email.Text;
                }

                report = MessageTextBox.Text;


                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("danila.kharitonov1999@gmail.com", "Пользователь: " + login);
                // кому отправляем
                MailAddress to = new MailAddress("danila.kharitonov1999@gmail.com");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "FacadesToolkit: письмо от пользователя: " + login + " Email: " + email;
                // текст письма
                m.Body = report;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("danila.kharitonov1999@gmail.com", "wqspantrhvyhnhwb");
                smtp.EnableSsl = true;
                smtp.Send(m);

                MessageBox.Show("Ваше письмо успешно отправлено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                NavigationService.Navigate(new StartPage());

            }
            else
            {
                MessageBox.Show("Поле 'Сообщение' не может быть пустым", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
