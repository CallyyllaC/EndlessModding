using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using EndlessModding.EndlessSpace2.Common.Files;

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
        public string LocalModDirectory
        {
            get => _localModDirector;
            set
            {
                if (_localModDirector != value)
                {
                    _localModDirector = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string SteamModDirectory
        {
            get => _steamModDirectory;
            set
            {
                if (_steamModDirectory != value)
                {
                    _steamModDirectory = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string GameDirStatus_Text
        {
            get => _gameDirStatus_Text;
            set
            {
                if (_gameDirStatus_Text != value)
                {
                    _gameDirStatus_Text = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Brush GameDirStatus_Foreground
        {
            get => _gameDirStatus_Foreground;
            set
            {
                if (_gameDirStatus_Foreground != value)
                {
                    _gameDirStatus_Foreground = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string LocGameDir_Text
        {
            get => _locGameDir_Text;
            set
            {
                if (_locGameDir_Text != value)
                {
                    _locGameDir_Text = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool LoadLocalMods
        {
            get => _loadLocalMods;
            set
            {
                if (_loadLocalMods != value)
                {
                    _loadLocalMods = value;
                    RaisePropertyChanged();
                    LoadLocalModsOpposite = value;
                }
            }
        }
        public bool LoadSteamMods
        {
            get => _loadSteamlMods;
            set
            {
                if (_loadSteamlMods != value)
                {
                    _loadSteamlMods = value;
                    RaisePropertyChanged();
                    LoadSteamModsOpposite = value;
                }
            }
        }
        public bool LoadLocalModsOpposite
        {
            get => _loadLocalModsOpposite;
            set
            {
                if (CanImportMods)
                {
                    _loadLocalModsOpposite = !value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool LoadSteamModsOpposite
        {
            get => _loadSteamlModsOpposite;
            set
            {
                if (CanImportMods)
                {
                    _loadSteamlModsOpposite = !value;
                    RaisePropertyChanged();
                }
            }
        }
        public string About
        {
            get;
        } = @"This is the new version of my ES2 Hero Designer, as you can see it has been expanded upon greatly since the last version, and now (not now now though) includes a large variety of modding tools. There have also been a lot of under the hood improvements to this tool that many of you will not be able to notice. However the original tool was both rushed in about a week, and written by a uni student with very limited experience. Not to say that this is greatly done, I have made a lot of shortcuts that will make many developers cry, however compared to the last one, this should be a lot easier to expand upon in the future as and when needed. I would also like to thank the community for their support over the years and for making developing these tools worth it.

There have been a whole bunch of performance optimisations since the last release, enjoy!";

        public string Steam
        {
            get;
        } = "Ofc I will be making a steam tutorial, however I do not have one yet to link";
        public string Github
        {
            get;
        } = "https://github.com/CallyyllaC/EndlessModding";
        public string HowTo
        {
            get;
        } = @"First thing you're gonna want to do is load the ES2 Game directory that you have installed, it might take a while to load but this is normal and only needs to be done on launch, most of this time is getting the language files for the game, as there are a lot of them

Next, if you want to load in previously developed mods, ensure that you have the correct workshop directory selected and then tick the Load other mods box

After this, you're ready to go and make your first mod, head over to any of the mod tab, click new mod at the bottom left, and get to it. You can also edit the original games objects too!

Once this is done, head over to the Workshop tab and do the same, click new mod (or edit an old mod) and fill out the details

Once that is done, go ahead and click export!";
        public string Bugs
        {
            get;
        } = @"I've done my best, but there are a lot of things to test, and a lot of weird things that .net just does anyway from time to time.

The UI has a thing about not wanting to shrink on its own, so resizing things might need a manual touch, they will get bigger very nicely but not always go back as easily.

Logging has now been added! Log files are located in %appdata%\Cali\EndlessModding\Logging";
        public bool CanImportMods
        {
            get => _canImportMods;
            set
            {
                _canImportMods = value;
                RaisePropertyChanged();
                LoadSteamModsOpposite = LoadSteamMods;
                LoadLocalModsOpposite = LoadLocalMods;
            }
        }

        //Fields
        private readonly ILogger _logger;
        private ImportFiles _importFiles;
        private ImportMods _importMods;
        private Data _data;
        private bool _loadLocalMods = false;
        private bool _loadLocalSim = false;
        private bool _loadLocalModsOpposite = false;
        private bool _loadSteamlMods = false;
        private bool _loadSteamlModsOpposite = false;
        private bool _loadGameSim = false;
        private string _localModDirector;
        private string _steamModDirectory;
        private string _gameDirStatus_Text = "Please locate the game install directory.";
        private Brush _gameDirStatus_Foreground = Brushes.White;
        private string _locGameDir_Text = "Please locate the game install directory.";
        private bool _canImportMods = false;

        public MainViewModel(ILogger logger, Data data)
        {
            logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _data = data;
            _logger = logger;
            _importFiles = new ImportFiles(logger, data);
            _importMods = new ImportMods(logger, data);
            LocalModDirectory = Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Endless Space 2\\Community")).FullName;
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
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            await GetMods(obj);
            MainWindow.IsBusy = false;
        }
        private async void Button_OutDir_Click(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            string dir = await IOHandler.OpenFolderExplorer("Open Workshop Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocalModDirectory = dir;
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
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
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
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (File.Exists($"{LocGameDir_Text}EndlessSpace2.exe"))
            {
                GameDirStatus_Text = "Game Directory Found";
                GameDirStatus_Foreground = Brushes.Green;

                SteamModDirectory = LocGameDir_Text.Replace("\\common\\Endless Space 2", "\\workshop\\content\\392110");

                var tf = new TaskFactory();
                await tf.StartNew(new Action(() => { _importFiles.ImportAll(LocGameDir_Text); }));

                CanImportMods = true;
                MainWindow.ShouldTabs = true;
            }
            else
            {
                CanImportMods = false;
                GameDirStatus_Text = "Error, cannot find EndlessSpace2.exe to verify folder location";
                GameDirStatus_Foreground = Brushes.Red;
                MainWindow.ShouldTabs = false;
                return;
            }
        }
        private async Task GetMods(object obj)
        {
            var tmp = (CheckBox)obj;
            if (tmp.IsChecked == true)
            {
                var tf = new TaskFactory();
                if (LoadLocalMods)
                {
                    await tf.StartNew(new Action(() => { _importMods.LoadMods(LocalModDirectory); }));
                }
                else if (LoadSteamMods)
                {
                    await tf.StartNew(new Action(() => { _importMods.LoadMods(SteamModDirectory); }));
                }
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
