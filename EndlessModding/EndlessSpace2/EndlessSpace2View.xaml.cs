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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using static EndlessModding.Common.BootStrapper;

namespace EndlessModding.EndlessSpace2
{
    /// <summary>
    /// Interaction logic for EndlessSpace2.xaml
    /// </summary>
    public partial class EndlessSpace2View : MetroWindow
    {
        public EndlessSpace2View()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
