using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using Excel = Microsoft.Office.Interop.Excel;
using Calendar.Models;

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserContext db;
        public static string data_Now;
        public MainWindow()
        {
            InitializeComponent();
            db = new UserContext();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            data_Now = Calendar_Win.SelectedDate.Value.ToShortDateString();
            WindowEvent windowEvent = new WindowEvent();
            windowEvent.ShowDialog();
        }

        private void excel1_Click(object sender, RoutedEventArgs e)
        {
            FolderSelection.FolderSelect();
            MessageBox.Show(FolderSelection.Folder);
            string _pathAndName = FolderSelection.Folder;
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = "Отчёт";


            ws.Cells[1, 1] = "Пользователь";
            ws.Cells[1, 2] = "Событие";
            ws.Cells[1, 3] = "Описание события";
            ws.Cells[1, 4] = "Пришёл/Не пришёл";
            }

        private void excel2_Click(object sender, RoutedEventArgs e)
        {
            FolderSelection.FolderSelect();
            string _pathAndName = FolderSelection.Folder;
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Name = "Отчёт";

            wb.SaveAs(wb, _pathAndName + @"\Отчёт2.xlsx");
            wb.Close();
        }

        //private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{


        //}
    }
}
