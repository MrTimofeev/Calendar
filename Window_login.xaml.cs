using System;
using System.Windows;
using Calendar.Models;
namespace Calendar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static int UserId;
        private readonly UserContext db;
        public Window1()
        {
            InitializeComponent();
            db = new UserContext();//подключение к БД
        }

        public void SubmitRegisterButton_Click_1(object sender, RoutedEventArgs e)
        {
            Windows_Registration regWin = new Windows_Registration();
            regWin.Show();
        }

        public void SubmitAuthoButton_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            var user_Name = db.User;
            foreach (User us in user_Name) // цикл который проходит по всем логинам занесенным в базу
            {
                string Login = us.Login;// Достаем логин
                string Password = us.Password;// Достаем пароль 
                UserId = us.UserId;// Достаем ID для создания связи 

                //проверяем на существование логин и пароль
                if (Login == Convert.ToString(userLogin.Text) && Password == Convert.ToString(userPassword.Password))
                {
                    MessageBox.Show("Вы авторизовались");
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
     
    }
}
