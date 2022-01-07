using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;


namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для Windows_Authorization.xaml
    /// </summary>
    public partial class Windows_Registration : Window
    {
        private SqlConnection sqlConnection = null;
        public Windows_Registration()
        {
            InitializeComponent();
        }

        private void Win(object sender, RoutedEventArgs e)
        {

        }

        private void window_load(object sender, RoutedEventArgs e)
        {
            //Подключение к БД
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_reg"].ConnectionString);
            sqlConnection.Open();

        }

        private void submitRegistration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(userName.Text.ToLower());
            SqlDataReader dataReader = null;
            String Name;
            bool flag = true;
            try
            {
                //SQL запрос NAME введенного пользователем, для последующей проверки на сущестоввание 
                SqlCommand sqlCommand = new SqlCommand($"SELECT Name FROM UserBd WHERE Name = '{userName.Text.ToLower()}'",
                    sqlConnection);

                dataReader = sqlCommand.ExecuteReader();

                
                while (dataReader.Read())
                {
                    //Достаем имя пользователя для проверки на существвание
                    Name = Convert.ToString(dataReader.GetString(0));
                    if (userName.Text == Name)
                    {
                        MessageBox.Show("Такое имя уже занято!!");
                        flag = false;
                    }

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


                //Проверка заполенение полей при регистрации
                if (userName.Text == "")
                {
                    MessageBox.Show("Вы не ввели данные в поле NAME");
                }
                else if (userLogin.Text == "")
                {
                    MessageBox.Show("Вы не ввели данные в поле LOGIN");
                }
                else if (Convert.ToString(userPassword.Password) == "")
                {
                    MessageBox.Show("Вы не ввели данные в поле PASSWORD");
                }
                else if (flag == true)
                {
                    //SQl запос на добавление Имени, Логина и Пароля в БД
                    SqlCommand command = new SqlCommand(
                        $"INSERT INTO [UserBD] (Name, Login, Password) VALUES (@Name, @Login, @Password)",
                        sqlConnection);

                    command.Parameters.AddWithValue("Name", userName.Text);
                    command.Parameters.AddWithValue("Login", userLogin.Text);
                    command.Parameters.AddWithValue("Password", userPassword.Password.ToString());

                    command.ExecuteNonQuery().ToString();

                    // Вывод сообщения и закрытие окна регистрации

                    MessageBox.Show("Вы успешно зарегистрировались!!");
                    Close();
                }

            }
        }
    }

}
