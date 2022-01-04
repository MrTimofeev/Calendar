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
namespace Calendar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
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
            App.isSigned = true;
            if (App.isSigned == true)
            {
                MainWindow calendarWin = new MainWindow();
                calendarWin.Show();
                Close();
            }
            else
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
