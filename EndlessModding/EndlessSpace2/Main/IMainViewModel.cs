using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EndlessModding.EndlessSpace2.Main
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        EndlessSpace2ViewModel MainWindow { get; set; }


        ICommand ButtonGameDirClick { get; }

        string GameDirStatus_Text { get; set; }
        Brush GameDirStatus_Foreground { get; set; }
        string LocGameDir_Text { get; set; }
        string GameDir_Text { get; set; }

        string About { get; set; }
        string Steam { get; set; }
        string Github { get; set; }
    }
}
