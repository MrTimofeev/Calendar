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
            MessageBox.Show(userLogin.Text.ToLower());
            SqlDataReader dataReader = null;
            String Login;
            bool flag = true;
            try
            {
                //SQL запрос Login введенного пользователем, для последующей проверки на сущестоввание 
                SqlCommand sqlCommand = new SqlCommand($"SELECT Login FROM UserBd WHERE Login = '{userLogin.Text.ToLower()}'",
                    sqlConnection);

                dataReader = sqlCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    //Достаем логин пользователя для проверки на существвание
                    Login = Convert.ToString(dataReader.GetString(0));
                    if (userLogin.Text == Login)
                    {
                        MessageBox.Show("Аккаунт с таким логином уже зарегестрирован!!!");
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


                //Проверка заполенения полей при регистрации
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
                else if (Convert.ToString(userLogin.Text).Length < 5)
                {
                    MessageBox.Show("Длинна логина должна превышать 5 символов!!!");
                }
                else if (Convert.ToString(userPassword.Password).Length < 6)
                {
                    MessageBox.Show("Длинна пароля должна превышать 6 символов!!!");
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
