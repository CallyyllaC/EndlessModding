using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EndlessModding.Common;
using EndlessModding.Common.IO;
using EndlessModding.Keyboard;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Castle.Core.Logging;
using EndlessModding.Common.DataStructures;
using EndlessModding.EndlessSpace2.Common.Classes.FactionAffinityMapping;
using EndlessModding.EndlessSpace2.Common.Files;

namespace EndlessModding.FactionHeroStart
{
    public class FactionHeroStartViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonGameDirClick { get; }
        public bool GameFound
        {
            get => _gameFound;

            set
            {
                if (_gameFound != value)
                {
                    _gameFound = value;
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
        public FactionAffinityMapping CurrentAffinity
        {
            get => _currentAffinity;
            set
            {
                if (_currentAffinity != value)
                {
                    _currentAffinity = value;
                    RaisePropertyChanged();
                }
            }
        }


        public BindingList<FactionAffinityMapping> Affinities { get; set; } = new BindingList<FactionAffinityMapping>();

        private EndlessObservableConcurrentCollection<FactionAffinityMapping> Collection =
            new EndlessObservableConcurrentCollection<FactionAffinityMapping>();
        private EndlessObservableConcurrentCollection<FactionAffinityMapping> Collection2 =
            new EndlessObservableConcurrentCollection<FactionAffinityMapping>();

        private readonly ILogger _logger;
        private string _gameDirStatus_Text = "Please locate the game install directory.";
        private Brush _gameDirStatus_Foreground = Brushes.White;
        private string _locGameDir_Text = "Please locate the game install directory.";
        private bool _gameFound = false;
        private FactionAffinityMapping _currentAffinity = null;


        public FactionHeroStartViewModel(ILogger logger)
        {
            logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = logger;

            ButtonGameDirClick = new RelayCommand(Can_Button_GameDir_Click, Button_GameDir_Click);
        }
        private bool Can_Button_GameDir_Click(object obj)
        {
            return !GameFound;
        }
        private async void Button_GameDir_Click(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            string dir = await IOHandler.OpenFolderExplorer("Open Game Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocGameDir_Text = dir;
                UpdateGameDirText();
            }
        }
        private void UpdateGameDirText()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (File.Exists($"{LocGameDir_Text}EndlessSpace2.exe"))
            {
                GameDirStatus_Text = "Game Directory Found";
                GameDirStatus_Foreground = Brushes.Green;

                var files = Directory.GetFiles($"{LocGameDir_Text}Public\\Simulation\\", "FactionTraits[AffinityMapping].xml", SearchOption.TopDirectoryOnly).ToList();
                files.AddRange(Directory.GetFiles($"{LocGameDir_Text}Public\\Simulation\\", "FactionTraits[AffinityMapping_*].xml", SearchOption.TopDirectoryOnly));

                ImportFiles.LoadNodes(Collection,
                    "FactionAffinityMapping", files.ToArray(), _logger);

                foreach (var item in Collection)
                {
                    if (item.SubCategory == "MajorFactionAffinityMapping")
                    {
                        Affinities.Add(item);
                    }
                }

                GameFound = true;
            }
            else
            {
                GameFound = false;
                GameDirStatus_Text = "Error, cannot find EndlessSpace2.exe to verify folder location";
                GameDirStatus_Foreground = Brushes.Red;
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

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
