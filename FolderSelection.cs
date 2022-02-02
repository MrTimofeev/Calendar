using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Calendar
{
    public class FolderSelection
    {

        private static string folder;

        public static string Folder { get => folder; set => folder = value; }

        public static void FolderSelect()
        {
            CommonOpenFileDialog dlg = new CommonOpenFileDialog();
            dlg.Title = "Обзор";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = Environment.CurrentDirectory;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Folder = dlg.FileName;
            }
        }

    }
}
