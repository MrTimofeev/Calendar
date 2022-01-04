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

        public static bool isSigned = false;

        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            Window1 myAuthorization = new Window1();
            myAuthorization.ShowDialog();
        }
    }
}
