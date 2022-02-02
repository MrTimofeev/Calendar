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
using Excel = Microsoft.Office.Interop.Excel;

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
            data_Now = Calendar_win.SelectedDate.Value.Date.ToShortDateString();
            WindowEvent windowEvent = new WindowEvent();
            windowEvent.ShowDialog();
        }


        private void excel1_Click(object sender, RoutedEventArgs e)
        {
            FolderSelection.FolderSelect();
            string _pathAndName = FolderSelection.Folder;
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = "Отчёт";

            ws.Cells[1, 1] = "Пользователь";
            ws.Cells[1, 2] = "Событие";
            ws.Cells[1, 3] = "Описание события";
            ws.Cells[1, 4] = "Пришёл/Не пришёл";

            wb.SaveAs(_pathAndName + @"\Отчёт1.xlsx");
            wb.Close();
        }

        private void excel2_Click(object sender, RoutedEventArgs e)
        {
            FolderSelection.FolderSelect();
            string _pathAndName = FolderSelection.Folder;
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = "Отчёт";

            wb.SaveAs(_pathAndName + @"\Отчёт2.xlsx");
            wb.Close();
        }


        //private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{


        //}
    }
}
