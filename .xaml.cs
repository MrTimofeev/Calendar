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
        private int i = 2;
        private readonly UserContext db;
        public static string data_Now;
        public MainWindow()
        {
            InitializeComponent();
            db = new UserContext();//подключение к БД
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

            ws.Cells[1, 1] = "Имя события";
            ws.Cells[1, 2] = "Описание события";
            ws.Cells[1, 3] = "Дата события";
            ws.Cells[1, 4] = "Пришёл/Не пришёл";

            var user_Name = db.User_event;
            foreach (User_event us in user_Name) // цикл который добаляет данные в Exel
            {
                
                ws.Cells[i, 1] = us.Name_event;
                ws.Cells[i, 2] = us.Event_Description;
                ws.Cells[i, 3] = us.Event_date;
                ws.Cells[i, 4] = us.HasCome;
                i++;
            }
            wb.SaveAs(_pathAndName + @"\Отчёт1.xlsx");
            wb.Close();
        }
    }
}
