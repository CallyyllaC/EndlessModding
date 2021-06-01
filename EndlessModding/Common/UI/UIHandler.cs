using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EndlessModding.Common.UI
{
    public static class UIHandler
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

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {

            T parent = VisualTreeHelper.GetParent(child) as T;

            if (parent != null)
                return parent;

            else
                return FindParent<T>(parent);
        }
    }
}
