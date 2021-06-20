using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.UI;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EndlessModding.EndlessSpace2.Workshop
{
    public class WorkshopViewModel
    {

        //Public View Models
        public EndlessSpace2ViewModel MainWindow { get; set; }

        //Commands
        public ICommand ButtonOutDirClick { get; }
        public string LocOutDir_Text
        {
            get => _locOutDir_Text;
            set
            {
                _locOutDir_Text = value;
                RaisePropertyChanged();
            }
        }

        public WriteableBitmap Image
        {
            get => _image;
            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }
        public RuntimeModuleType Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged();
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                RaisePropertyChanged();
            }
        }
        public string ReleaseNotes
        {
            get => _releaseNotes;
            set
            {
                _releaseNotes = value;
                RaisePropertyChanged();
            }
        }
        public string Version
        {
            get => _version;
            set
            {
                _version = value;
                RaisePropertyChanged();
            }
        }
        public List<RuntimeModule> Mods
        {
            get => _mods;
        }
        public List<object> Modules
        {
            get => _modules;
        }

        //Fields
        private readonly ILogger _logger;
        private string _locOutDir_Text;
        private List<RuntimeModule> _mods;
        private List<object> _modules;
        private string _version;
        private string _releaseNotes;
        private string _author;
        private string _description;
        private string _title;
        private RuntimeModuleType _type;
        private WriteableBitmap _image;

        public WorkshopViewModel(ILogger Logger)
        {
            _logger = Logger;
            ButtonOutDirClick = new RelayCommand(Can_Button_OutDir_Click, Button_OutDir_Click);
            LocOutDir_Text = Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Endless Space 2\\Community")).FullName;
            RaisePropertyChanged();
        }

        private async void Button_OutDir_Click(object obj)
        {
            string dir = await UIHandler.OpenFolderExplorer("Open Workshop Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocOutDir_Text = dir;
            }
        }

        private bool Can_Button_OutDir_Click(object obj)
        {
            return true;
        }

        #region INotifyPropertyChanged
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
