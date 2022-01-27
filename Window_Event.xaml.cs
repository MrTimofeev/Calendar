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
    /// Логика взаимодействия для WindowEvent.xaml
    /// </summary>
    public partial class WindowEvent : Window
    {
        public WindowEvent()
        {
            InitializeComponent();
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
    }
}
