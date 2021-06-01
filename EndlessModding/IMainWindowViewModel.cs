using EndlessModding.EndlessSpace2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EndlessModding
{
    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
        IEndlessSpace2ViewModel EndlessSpace2 { get; }

        ICommand EndlessSpace2Clicked { get; }
    }
}
