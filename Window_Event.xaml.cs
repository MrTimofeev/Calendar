using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Calendar;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для WindowEvent.xaml
    /// </summary>
    public partial class WindowEvent : Window
    {
        private string rb_ch;
        private readonly UserContext db;
        public WindowEvent()
        {
            
            InitializeComponent();
            db = new UserContext();//подключение к БД
            dt_1.Text = MainWindow.data_Now;

        }

        private void Save_event(object sender, RoutedEventArgs e)
        {
            User_event User_event = new User_event // Добавление записи события 
            {
                Name_event = Convert.ToString(txt_nazv.Text), // Добаление Имени события 
                Event_Description = Convert.ToString(txt.Text), // Добовление Описания 
                Event_date = Convert.ToString(dt_1.Text),// Добовление  даты 
                HasCome = rb_ch,// Добавления Пришел/Не пришел
                User_Id = Window1.UserId // Добавлние ID для связи 2 таблиц 
            };

            db.User_event.Add(User_event); // Добавдение сущности User_event 
            db.SaveChanges(); //Сохраниени сущности в БД
                              
            MessageBox.Show("Заметка события создана");// Вывод сообщения и закрытие окна 
            Close();

        }

        private void CbmBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void tire_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void exit_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (G_Sob.Visibility == Visibility.Hidden)
                G_Sob.Visibility = Visibility.Visible;
            else
                G_Sob.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Help regWin = new Help();
            regWin.Show();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            rb_ch = pressed.Content.ToString();
        }
    }
}
