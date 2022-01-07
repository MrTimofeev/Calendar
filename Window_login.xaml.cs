using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
namespace Calendar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private SqlConnection sqlConnection = null;
        public Window1()
        {
            InitializeComponent();
        }

        public void submitRegisterButton_Click_1(object sender, RoutedEventArgs e)
        {
            Windows_Registration regWin = new Windows_Registration();
            regWin.Show();
        }

        private void submitAuthoButton_Click(object sender, RoutedEventArgs e)
        {
            String Login;
            String Password;
            bool flag = true;
            SqlDataReader dataReader = null;
            //MessageBox.Show(Convert.ToString(userLogin.Text));
            // MessageBox.Show(Convert.ToString(userPassword.Password));
            try
            {
                //SQL запрос Логина и Пароля введенного пользователем, для проследующей проверки на сущестоввание 
                SqlCommand sqlCommand = new SqlCommand($"SELECT Login, Password FROM UserBd WHERE Login = '{userLogin.Text}' AND Password = '{Convert.ToString(userPassword.Password)}'",
                    sqlConnection);

                dataReader = sqlCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    //Достаем Логин и Пароль из БД
                    Login = Convert.ToString(dataReader[0]);
                    Password = Convert.ToString(dataReader.GetString(1));
                    if (Convert.ToString(userLogin.Text) == Login && Convert.ToString(userPassword.Password) == Password)
                    {
                        MessageBox.Show("Вы авторизовались!!");
                        MainWindow calendarWin = new MainWindow();
                        calendarWin.Show();
                        Close();
                        flag = false;

                    }
                }
                if (flag == true)
                {
                    MessageBox.Show(
                       "Вы ввели неверный логин или пароль",
                       "Ошибка",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                //Вывод шибки на случай исключения 
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    //Закрытие dataReader
                    dataReader.Close();
                }

            }
        }

        private void window_load(object sender, RoutedEventArgs e)
        {
            //Подключение к Бд
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_reg"].ConnectionString);
            sqlConnection.Open();
        }
    }
}
