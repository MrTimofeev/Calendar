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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string data_Now;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            data_Now = Calendar.SelectedDate.Value.Date.ToShortDateString();
            WindowEvent windowEvent = new WindowEvent();
            windowEvent.Show();
        }

        //private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
            
           
        //}
    }
}
