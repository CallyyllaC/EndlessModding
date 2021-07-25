using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EndlessModding.Common.IO
{
    public static class IOHandler
    {
        public static async Task<string> OpenFolderExplorer(string desc = null)
        {
            var folderBrowserDialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (desc != null)
            {
                folderBrowserDialog.Description = desc;
                folderBrowserDialog.UseDescriptionForTitle = true;
            }

            bool? result = folderBrowserDialog.ShowDialog();

            if (result == true)
                return await Task.FromResult(folderBrowserDialog.SelectedPath + "\\");
            else
                return await Task.FromResult<string>(null);
        }
        public static async Task<string> OpenFileExplorer(string desc = null, string ext = null)
        {
            var fileBrowserDialog = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            if (desc != null)
            {
                fileBrowserDialog.Title = desc;
            }
            if (ext != null)
            {
                fileBrowserDialog.DefaultExt = ext;
            }
            fileBrowserDialog.AddExtension = true;
            fileBrowserDialog.Multiselect = false;
            bool? result = fileBrowserDialog.ShowDialog();

            if (result == true)
                return await Task.FromResult(fileBrowserDialog.FileName);
            else
                return await Task.FromResult<string>(null);
        }
    }
}
