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
using ControlzEx.Theming;
using EndlessModding.Common;
using MahApps.Metro.Controls;

namespace EndlessModding.Keyboard
{
    /// <summary>
    /// Interaction logic for EndlessKeyboardView.xaml
    /// </summary>
    public partial class EndlessKeyboardView : MetroWindow
    {
        public EndlessKeyboardView()
        {
            this.FontFamily = new FontFamily("AmplitudeFont");
            InitializeComponent();
        }
    }
}
