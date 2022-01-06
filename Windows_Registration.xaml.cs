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
            //SQl запос на добавление Имени, Логина и Пароля в БД
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [UserBD] (Name, Login, Password) VALUES (@Name, @Login, @Password)",
                sqlConnection);

            command.Parameters.AddWithValue("Name", userName.Text);
            command.Parameters.AddWithValue("Login", userLogin.Text);
            command.Parameters.AddWithValue("Password", userPassword.Password.ToString());


            command.ExecuteNonQuery().ToString();

        }

    }
}
