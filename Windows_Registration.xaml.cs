using Calendar.Models;
using System;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для Windows_Authorization.xaml
    /// </summary>
    public partial class Windows_Registration : Window
    {
        private readonly UserContext db;
        public Windows_Registration()
        {
            InitializeComponent();
            db = new UserContext();//подключение к БД
        }

        private void SubmitRegistration_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            var user_Name = db.User;
            foreach (User us in user_Name) // цикл который проходит по всем логинам занесенным в базу
            {
                string Login = us.Login;// Достаем логин
                if (Login == Convert.ToString(userLogin.Text))  //проверяем существет ли логин
                {
                    MessageBox.Show("Аккаунт с таким логином уже зарегестрирован");
                    flag = false;
                }

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
                // Создание сущности User и добавление в него атрибутов
                User user = new User
                {
                    Name = Convert.ToString(userName.Text),
                    Login = Convert.ToString(userLogin.Text),
                    Password = Convert.ToString(userPassword.Password)
                };

                db.User.Add(user);// Добаление сущности User
                db.SaveChanges();// сохранение cущности в БД
                
                // Вывод сообщения и закрытие окна 
                MessageBox.Show("Вы успешно зарегистрировались!!");
                Close();
            }

        }
    }

}
