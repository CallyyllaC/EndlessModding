using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.UI;
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

namespace EndlessModding.EndlessSpace2.Main
{
    public class MainViewModel : IMainViewModel
    {
        //Public View Models
        public IEndlessSpace2ViewModel MainWindow { get; set; } // change me back to an interface when you get time

        //Commands
        public ICommand ButtonGameDirClick { get; }
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
        public string GameDir_Text
        {
            get;
            set;
        } = "Game Directory: ";
        public string GameDirBut_Text
        {
            get;
            set;
        } = "Find Folder";
        public string LocGameDir_Text
        {
            get => _locGameDir_Text;
            set
            {
                _locGameDir_Text = value;
                UpdateGameDirText();
                RaisePropertyChanged();
            }
        }
        public string About
        {
            get;
            set;
        } = "This is the new version of my ES2 Hero Designer, as you can see it has been expanded upon greatly since the last version, and now includes a large variety of modding tools. There have also been a lot of under the hood improvements to this tool that many of you will not be able to notice. However the original tool was both rushed in about a week, and written by a uni student with very limited experience. Not to say that this is greatly done, I have made a lot of shortcuts that will make many developers cry, however compared to the last one, this should be a lot easier to expand upon in the future as and when needed. I would also like to thank the community for their support over the years and for making this tool worth it.";
        public string Steam
        {
            get;
            set;
        } = "Ofc I will be making a steam tutorial, however I do not have one yet to link";
        public string Github
        {
            get;
            set;
        } = "It's not on github yet either tee-hee";
        public string HowTo
        {
            get;
            set;
        } = "IDK the program doesn't even exist yet lol";


        //Fields
        private readonly ILogger _logger;
        private string _gameDirStatus_Text = "Please locate the game install directory.";
        private Brush _gameDirStatus_Foreground = Brushes.Black;
        private string _locGameDir_Text = "Please locate the game install directory.";

        public MainViewModel()
        {
            ButtonGameDirClick = new RelayCommand(Can_Button_GameDir_Click, Button_GameDir_Click);
            RaisePropertyChanged();
        }

        private bool Can_Button_GameDir_Click(object obj)
        {
            try
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                var mainWindowVM = mainWindow.DataContext as MainWindowViewModel;
                MainWindow = mainWindowVM.EndlessSpace2 as EndlessSpace2ViewModel;
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
                return false;
            }
            return true;
        }
        private async void Button_GameDir_Click(object obj)
        {
            string dir = await UIHandler.OpenFolderExplorer("Open Game Directory");

            if (!string.IsNullOrEmpty(dir))
            {
                LocGameDir_Text = dir;
            }
        }
        private void UpdateGameDirText()
        {
            if (File.Exists($"{LocGameDir_Text}EndlessSpace2.exe"))
            {
                GameDirStatus_Text = "Game Directory Found";
                GameDirStatus_Foreground = Brushes.Green;
                MainWindow.ToggleTabs(true);
                MainWindow.ImportHandle.ImportAll(LocGameDir_Text);
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
