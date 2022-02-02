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
            MainWindow window = new MainWindow();
            window.Show();
            //Window1 myAuthorization = new Window1();
            //myAuthorization.ShowDialog();
        }
    }
}
