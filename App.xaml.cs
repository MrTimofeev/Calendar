using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            MainWindow myMainWindow = new MainWindow();
            Window1 myAuthorization = new Window1();
            myAuthorization.ShowDialog();
            myMainWindow.Show();
        }
    }
}
