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
using ControlzEx.Theming;
using EndlessModding.EndlessSpace2;
using MahApps.Metro.Controls;
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
            InitializeComponent();
        }
    }
}
