using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.EndlessSpace2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EndlessModding.Keyboard;
using SteamKit2;
using SteamKit2.Internal;

namespace EndlessModding
{
    public class MainWindowViewModel
    {
        //Public View Models
        public EndlessSpace2ViewModel EndlessSpace2 { get; }
        public EndlessKeyboardViewModel EndlessKeyboard { get; }
        public BindingList<NewsObject> News { get; }
        public int SelectedNews { get; set; }

        //Private Views
        private EndlessSpace2View EndlessSpace2Window;

        private EndlessKeyboardView EndlessKeyboardWindow;


        //Commands
        public ICommand EndlessSpace2Clicked { get; }
        public ICommand EndlessKeyboardClicked { get; }


        //Fields
        private readonly ILogger _logger;



        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="es2vm">The endless space 2 view model.</param>
        public MainWindowViewModel(ILogger castleLogger, EndlessSpace2ViewModel es2vm, EndlessKeyboardViewModel ekvm)
        {
            castleLogger.Info($"{MethodBase.GetCurrentMethod().Name}");
            //setup injections
            _logger = castleLogger;
            EndlessSpace2 = es2vm;
            EndlessKeyboard = ekvm;
            //setup commands
            EndlessSpace2Clicked = new RelayCommand(Can_Endless_Space_2_Click, Endless_Space_2_Click);
            EndlessKeyboardClicked = new RelayCommand(Can_Endless_Keyboard_Click, Endless_Keyboard_Click);

            News = GetNews(392110);

        }
        private void EndlessSpace2WindowOnClosed(object sender, EventArgs e)
        {
            EndlessSpace2Window = null;
        }
        private void EndlessKeyboardWindowOnClosed(object sender, EventArgs e)
        {
            EndlessKeyboardWindow = null;
        }

        private void Endless_Keyboard_Click(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            EndlessKeyboardWindow = new EndlessKeyboardView() { DataContext = EndlessKeyboard };
            EndlessKeyboardWindow.Show();
            EndlessKeyboardWindow.Closed -= EndlessKeyboardWindowOnClosed;
            EndlessKeyboardWindow.Closed += EndlessKeyboardWindowOnClosed;
        }

        private bool Can_Endless_Keyboard_Click(object obj)
        {
            if (EndlessKeyboardWindow == null)
            {
                return true;
            }

            return false;
        }

        private void Endless_Space_2_Click(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            EndlessSpace2Window = new EndlessSpace2View() { DataContext = EndlessSpace2 };
            EndlessSpace2Window.Show();
            EndlessSpace2Window.Closed -= EndlessSpace2WindowOnClosed;
            EndlessSpace2Window.Closed += EndlessSpace2WindowOnClosed;
        }
        private bool Can_Endless_Space_2_Click(object obj)
        {
            if (EndlessSpace2Window == null)
            {
                return true;
            }

            return false;
        }

        //Steam News
        private BindingList<NewsObject> GetNews(int gameID)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var output = new BindingList<NewsObject>();
            using (dynamic steamNews = WebAPI.GetInterface("ISteamNews"))
            {
                KeyValue gameNews;


                try
                {
                    gameNews = steamNews.GetNewsForApp002(appid: gameID, maxlength: 0, count: 25);

                    foreach (KeyValue news in gameNews["newsitems"].Children)
                    {
                        NewsObject tmp = new NewsObject();
                        tmp.Title = news["title"].AsString();
                        tmp.Url = news["url"].AsString();
                        tmp.Date = UnixTimeStampToDateTime(double.Parse(news["date"].AsString()));
                        output.Add(tmp);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
            }

            return output;
        }

        public struct NewsObject
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Date { get; set; }
        }

        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToShortDateString();
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
