using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using ControlzEx.Theming;
using EndlessModding.EndlessSpace2;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using static EndlessModding.Common.BootStrapper;

namespace EndlessModding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            DataContext = ApplicationBootStrapper.MainWindowViewModel;
            ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
            //ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithAppMode;
            //ThemeManager.Current.SyncTheme();

            if (!FontHandling.IsFontInstalled("AmplitudeFont"))
            {
                FontHandling.InstallFont("./Fonts/AmplitudeFont.otf");
            }

            InitializeComponent();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            var item = (MainWindowViewModel.NewsObject)row.Item;
            System.Diagnostics.Process.Start($"steam://openurl/{item.Url}");
        }


        private static class FontHandling
        {
            public static bool IsFontInstalled(string fontName)
            {
                using (var testFont = new System.Drawing.Font(fontName, 8))
                    return 0 == string.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            public static void InstallFont(string fontSourcePath)
            {
                fontSourcePath = Path.GetFullPath(fontSourcePath);
                var shellAppType = Type.GetTypeFromProgID("Shell.Application");
                var shell = Activator.CreateInstance(shellAppType);
                var fontFolder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { Environment.GetFolderPath(Environment.SpecialFolder.Fonts) });
                if (File.Exists(fontSourcePath))
                    fontFolder.CopyHere(fontSourcePath);/*
                Shell32.Shell shell = new Shell32.Shell();
                Shell32.Folder fontFolder = shell.NameSpace(0x14);
                fontFolder.CopyHere(fontSourcePath);*/
            }
        }
    }
}
