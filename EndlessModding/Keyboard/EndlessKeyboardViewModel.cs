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
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.IO;
using DataGrid = System.Windows.Controls.DataGrid;

namespace EndlessModding.Keyboard
{
    public class EndlessKeyboardViewModel : INotifyPropertyChanged
    {
        public FontFamily AmplitudeFont { get; } = new FontFamily("AmplitudeFont");

        public ICommand AddFont { get; }
        public ICommand CopyFont { get; }
        public ICommand AddText { get; }
        public ICommand AddColour { get; }
        public ICommand CopyText { get; }
        public ICommand ButtonGameDirClick { get; }

        public int SelectionStart { get; set; }
        public int SelectionLength { get; set; }
        public string FontText
        {
            get => _fontText;

            set
            {
                if (_fontText != value)
                {
                    _fontText = value;
                    RaisePropertyChanged();
                }
            }

        }
        public string TextText
        {
            get => _textText;

            set
            {
                if (_textText != value)
                {
                    _textText = value;
                    RaisePropertyChanged();
                }
            }

        }
        public AmplitudeFontCharacter SelectedFont { get; set; } = null;
        public AmplitudeTextCharacter SelectedText { get; set; } = null;
        public Color? Colour { get; set; }
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


        public BindingList<AmplitudeFontCharacter> Characters { get; set; } = new BindingList<AmplitudeFontCharacter>();
        public BindingList<AmplitudeTextCharacter> Texts { get; set; } = new BindingList<AmplitudeTextCharacter>();


        private readonly ILogger _logger;
        private string _gameDirStatus_Text = "Please locate the game install directory.";
        private Brush _gameDirStatus_Foreground = Brushes.White;
        private string _locGameDir_Text = "Please locate the game install directory.";
        private bool _gameFound = false;
        private string _fontText = "";
        private string _textText = "";
        public EndlessKeyboardViewModel(ILogger logger)
        {
            logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = logger;

            var typefaces = AmplitudeFont.GetTypefaces();
            foreach (Typeface typeface in typefaces)
            {
                GlyphTypeface glyph;
                typeface.TryGetGlyphTypeface(out glyph);
                IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                Characters.Clear();

                foreach (KeyValuePair<int, ushort> kvp in characterMap)
                {
                    if (kvp.Key > 57330 && kvp.Key < 58000)
                    {
                        Characters.Add(new AmplitudeFontCharacter(kvp.Key));
                    }
                }

            }

            AddText = new RelayCommand(canAddTextChar, AddTextChar);
            CopyText = new RelayCommand(canCopyTextText, CopyTextText);
            AddFont = new RelayCommand(canAddFontChar, AddFontChar);
            CopyFont = new RelayCommand(canCopyFontText, CopyFontText);
            AddColour = new RelayCommand(canAddColourText, AddColourText);
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

                var files = Directory.GetFiles($"{LocGameDir_Text}Public\\Localization\\english", "*", SearchOption.AllDirectories).ToList();
                files.AddRange(Directory.GetFiles($"{LocGameDir_Text}Public\\Gui", "*", SearchOption.AllDirectories));

                var pattern = @"\[(.*?)\]";
                var output = new List<string>();
                MatchCollection matches;

                foreach (var file in files)
                {
                    var text = File.ReadAllText(file);
                    matches = Regex.Matches(text, pattern);

                    foreach (Match m in matches)
                    {
                        output.Add(m.Groups[1].Value);
                    }
                }

                var tmp = output.Distinct().ToList();

                //Loop through the premade list and if anything isnt on there, add it
                bool found;
                foreach (var item in AmplitudeTextCharacter.lookup)
                {
                    found = false;

                    for (int i = 0; i < tmp.Count; i++)
                    {
                        if (string.Equals(tmp[i], item.Key, StringComparison.InvariantCultureIgnoreCase))
                        {
                            found = true;
                            i = tmp.Count;
                        }
                    }
                    if (!found)
                    {
                        tmp.Add(item.Key);
                    }
                }

                tmp.Sort();

                foreach (var item in tmp)
                {
                    Texts.Add(new AmplitudeTextCharacter(item));
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

        private void AddColourText(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var str = Colour.Value.ToString();
            str = str.Substring(3, str.Length - 3);
            if (SelectionLength <= 0)
            {
                if (SelectionStart == 0)
                {
                    SelectionStart = TextText.Length;
                }
                TextText = TextText.Insert(SelectionStart, $"#{str}# MY TEXT #REVERT#");
            }
            else
            {
                TextText = TextText.Insert(SelectionStart + SelectionLength, "#REVERT#")
                    .Insert(SelectionStart, $"#{str}#");
            }
        }
        private bool canAddColourText(object obj)
        {
            if (Colour != null)
            {
                return true;
            }

            return false;
        }

        private void CopyFontText(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Clipboard.SetText(FontText);
        }
        private bool canCopyFontText(object obj)
        {
            if (FontText.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void AddFontChar(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            FontText += $"{Convert.ToChar(SelectedFont.Key)}";
        }
        private bool canAddFontChar(object obj)
        {
            return SelectedFont != null;
        }

        private void CopyTextText(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Clipboard.SetText(TextText);
        }
        private bool canCopyTextText(object obj)
        {
            if (TextText.Length > 0)
            {
                return true;
            }
            return false;
        }

        private void AddTextChar(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (SelectionLength <= 0 && SelectionStart == 0)
            {
                SelectionStart = TextText.Length;
            }
            TextText = TextText.Insert(SelectionStart, $"[{SelectedText.Value}]");
        }
        private bool canAddTextChar(object obj)
        {
            return SelectedText != null;
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
