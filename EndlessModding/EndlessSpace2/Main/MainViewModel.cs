using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EndlessModding.EndlessSpace2.Common.Import;

namespace EndlessModding.EndlessSpace2.Main
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Public View Models
        public EndlessSpace2ViewModel MainWindow { get; set; }

        //Commands
        public ICommand ButtonGameDirClick { get; }
        public ICommand ButtonOutDirClick { get; }
        public ICommand CheckboxChecked { get; }
        public ICommand Update { get; }
        public string LocOutDir_Text
        {
            get => _locOutDir_Text;
            set
            {
                _locOutDir_Text = value;
                RaisePropertyChanged();
            }
        }
        public string GameDirStatus_Text
        {
            get => _gameDirStatus_Text;
            set
            {
                _gameDirStatus_Text = value;
                RaisePropertyChanged();
            }
        }
        public Brush GameDirStatus_Foreground
        {
            get => _gameDirStatus_Foreground;
            set
            {
                _gameDirStatus_Foreground = value;
                RaisePropertyChanged();
            }
        }
        public string LocGameDir_Text
        {
            get => _locGameDir_Text;
            set
            {
                _locGameDir_Text = value;
                RaisePropertyChanged();
            }
        }
        public bool LoadOtherMods
        {
            get => _loadOtherMods;
            set
            {
                _loadOtherMods = value;
                RaisePropertyChanged();
            }
        }
        public string About
        {
            get;
        } = "This is the new version of my ES2 Hero Designer, as you can see it has been expanded upon greatly since the last version, and now includes a large variety of modding tools. There have also been a lot of under the hood improvements to this tool that many of you will not be able to notice. However the original tool was both rushed in about a week, and written by a uni student with very limited experience. Not to say that this is greatly done, I have made a lot of shortcuts that will make many developers cry, however compared to the last one, this should be a lot easier to expand upon in the future as and when needed. I would also like to thank the community for their support over the years and for making this tool worth it.";
        public string Steam
        {
            get;
        } = "Ofc I will be making a steam tutorial, however I do not have one yet to link";
        public string Github
        {
            get;
        } = "It's not on github yet either tee-hee";
        public string HowTo
        {
            get;
        } = "IDK the program doesn't even exist yet lol";
        public string Bugs
        {
            get;
        } = "Closing the window and reopening will reimport some of the data but not add it to old lists\nProbably a whole lot more\n";

        //Fields
        private readonly ILogger _logger;
        private ImportFiles _importFiles;
        private ImportMods _importMods;
        private Data _data;
        private bool _loadOtherMods = false;
        private string _locOutDir_Text;
        private string _gameDirStatus_Text = "Please locate the game install directory.";
        private Brush _gameDirStatus_Foreground = Brushes.White;
        private string _locGameDir_Text = "Please locate the game install directory.";

        public MainViewModel(ILogger logger, Data data)
        {
            _data = data;
            _logger = logger;
            _importFiles = new ImportFiles(logger, data);
            _importMods = new ImportMods(logger, data);
            LocOutDir_Text = Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Endless Space 2\\Community")).FullName;
            Update = new RelayCommand((t => true), new Action<object>(async x => await UpdateGameDirText()));
            ButtonOutDirClick = new RelayCommand(Can_Button_OutDir_Click, Button_OutDir_Click);
            ButtonGameDirClick = new RelayCommand(Can_Button_GameDir_Click, Button_GameDir_Click);
            CheckboxChecked = new RelayCommand(Can_Checkbox_Click, CheckBox_Click);
            RaisePropertyChanged();
        }

        private bool Can_Checkbox_Click(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private async void CheckBox_Click(object obj)
        {
            MainWindow.IsBusy = true;
            var tmp = (CheckBox)obj;
            if (tmp.IsChecked == true)
            {
                var tf = new TaskFactory();
                await tf.StartNew(new Action(() => { _importMods.LoadMods(_locOutDir_Text); }));
            }

            MainWindow.IsBusy = false;
        }

        private async void Button_OutDir_Click(object obj)
        {
            MainWindow.IsBusy = true;
            string dir = await IOHandler.OpenFolderExplorer("Open Workshop Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocOutDir_Text = dir;
            }
            MainWindow.IsBusy = false;
        }

        private bool Can_Button_OutDir_Click(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private bool Can_Button_GameDir_Click(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private async void Button_GameDir_Click(object obj)
        {
            MainWindow.IsBusy = true;
            string dir = await IOHandler.OpenFolderExplorer("Open Game Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocGameDir_Text = dir;
                await UpdateGameDirText();
            }
            MainWindow.IsBusy = false;
        }
        private async Task UpdateGameDirText()
        {
            if (File.Exists($"{LocGameDir_Text}EndlessSpace2.exe"))
            {
                GameDirStatus_Text = "Game Directory Found";
                GameDirStatus_Foreground = Brushes.Green;

                var tf = new TaskFactory();
                await tf.StartNew(new Action(() => { _importFiles.ImportAll(LocGameDir_Text); }));

                MainWindow.ToggleTabs(true);
            }
            else
            {
                GameDirStatus_Text = "Error, cannot find EndlessSpace2.exe to verify folder location";
                GameDirStatus_Foreground = Brushes.Red;
                MainWindow.ToggleTabs(false);
                return;
            }
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
