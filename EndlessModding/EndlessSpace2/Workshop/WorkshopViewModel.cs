using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.Common.IO;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using EndlessModding.EndlessSpace2.Common.Extensions;
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
    public class WorkshopViewModel : INotifyPropertyChanged
    {

        //Public View Models
        public EndlessSpace2ViewModel MainWindow { get; set; }

        public ICommand GetImage { get; }
        public ICommand NewMod { get; }
        public ICommand AddAuthor { get; }
        public ICommand RemoveAuthor { get; }
        public ICommand AddTag { get; }
        public ICommand RemoveTag { get; }

        public string[] Tags
        {
            get => _tags;
            set
            {
                _tags = value;
                RaisePropertyChanged();
            }
        }
        public BindingList<RuntimePlugin> Plugins
        {
            get => _plugins;
            set
            {
                _plugins = value;
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
        public string[] Author
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
        public int CurrentMod
        {
            get => _currentMod;
            set
            {
                if (MainWindow != null)
                    MainWindow.IsBusy = true;

                saveMod();
                _currentMod = value;
                loadMod(null);
                RaisePropertyChanged();

                if (MainWindow != null)
                    MainWindow.IsBusy = false;
            }
        }
        public int SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                RaisePropertyChanged();
            }
        }
        public int SelectedTag
        {
            get => _selectedTag;
            set
            {
                _selectedTag = value;
                RaisePropertyChanged();
            }
        }
        public string NewAuthor
        {
            get => _newAuthor;
            set
            {
                _newAuthor = value;
                RaisePropertyChanged();
            }
        }
        public BindingList<RuntimeModule> Mods { get; }
        public BindingList<object> Exportables
        {
            get => _exportables;
        }
        public string TagsBox
        {
            get => _tagsBox;
            set
            {
                _tagsBox = value;
                RaisePropertyChanged();
            }
        }
        public string[] TagsAvailible { get; } = new string[]
        {
            "AI",
            "Art",
            "Balance",
            "Buildings",
            "Gameplay",
            "Heroes",
            "Improvements",
            "MajorFactions",
            "Maps",
            "MinorFactions",
            "Multiplayer",
            "Other",
            "Quests",
            "Resources",
            "Technologies",
            "Terrain",
            "Units"
        };
        //Fields
        private string[] _tags;
        private string _tagsBox;
        private BindingList<RuntimePlugin> _plugins = new BindingList<RuntimePlugin>();
        private int _currentMod = 0;
        private int _selectedAuthor = 0;
        private int _selectedTag = 0;
        private string _newAuthor = "";
        private readonly ILogger _logger;
        private BindingList<RuntimeModule> _mods;
        private BindingList<object> _exportables = new BindingList<object>();
        private string _version;
        private string _releaseNotes;
        private string[] _author;
        private string _description;
        private string _title;
        private RuntimeModuleType _type;
        private WriteableBitmap _image;
        private Import _import;

        public WorkshopViewModel(ILogger Logger, Import import)
        {
            _logger = Logger;
            _import = import;
            Mods = _import.RuntimeModules;
            CurrentMod = Mods.Count - 1;
            GetImage = new RelayCommand(canGetImage, getImage);
            NewMod = new RelayCommand(canNewMod, newMod);
            AddAuthor = new RelayCommand(canAddAuthor, addAuthor);
            RemoveAuthor = new RelayCommand(canRemoveAuthor, removeAuthor);
            AddTag = new RelayCommand(canAddTag, addTag);
            RemoveTag = new RelayCommand(canRemoveTag, removeTag);

            RaisePropertyChanged();
        }
        private void isbusy(bool value)
        {
            if (MainWindow != null)
                MainWindow.IsBusy = true;
        }
        private void newMod(object obj)
        {
            Mods.Add(new RuntimeModule());
            CurrentMod = Mods.Count - 1;
        }
        private bool canNewMod(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private async void getImage(object obj)
        {
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Mod Icon", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            Image = new WriteableBitmap(img);
        }
        private bool canGetImage(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private void loadMod(object obj)
        {
            if (Mods.Count > 0)
            {
                Version = Mods[CurrentMod].Version;
                ReleaseNotes = Mods[CurrentMod].ReleaseNotes;
                Author = Mods[CurrentMod].Author;
                Description = Mods[CurrentMod].Description;
                Title = Mods[CurrentMod].Title;
                Type = Mods[CurrentMod].Type;
                Image = Mods[CurrentMod].Image;

                var tmpTags = Mods[CurrentMod].Tags.Value;
                if (!string.IsNullOrEmpty(tmpTags))
                {
                    if (tmpTags.Split(',').Count() > 1)
                        Tags = tmpTags.Split(',');
                    else
                        Tags = tmpTags.Split(' ');

                Tags = Tags.Select(innerItem => innerItem.Trim()).ToArray();
                }
                else
                {
                    Tags = new string[0];
                }

                Plugins.Clear();
                foreach (var item in Mods[CurrentMod].Plugins)
                {
                    Plugins.Add(item);
                }
            }
        }
        private void saveMod()
        {
            if (Mods.Count > 0 && CurrentMod >= 0)
            {
                Mods[CurrentMod].Version = Version;
                RaisePropertyChanged(Mods[CurrentMod], "Version");
                Mods[CurrentMod].ReleaseNotes = ReleaseNotes;
                RaisePropertyChanged(Mods[CurrentMod], "ReleaseNotes");
                Mods[CurrentMod].Author = Author;
                RaisePropertyChanged(Mods[CurrentMod], "Author");
                Mods[CurrentMod].Description = Description;
                RaisePropertyChanged(Mods[CurrentMod], "Description");
                Mods[CurrentMod].Title = Title;
                RaisePropertyChanged(Mods[CurrentMod], "Title");
                Mods[CurrentMod].Type = Type;
                RaisePropertyChanged(Mods[CurrentMod], "Type");
                Mods[CurrentMod].Image = Image;
                RaisePropertyChanged(Mods[CurrentMod], "Image");
                Mods[CurrentMod].Plugins = Plugins.ToArray();
                RaisePropertyChanged(Mods[CurrentMod], "Plugins");
                Mods[CurrentMod].Tags.Value = string.Join(", ", Tags);
                RaisePropertyChanged(Mods[CurrentMod], "Tags");
            }
        }
        private void removeAuthor(object obj)
        {
            Author = Author.Where(val => val != Author[SelectedAuthor]).ToArray();
        }
        private bool canRemoveAuthor(object obj)
        {
            if (Author != null && Author.Count() > SelectedAuthor)
            {
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }
        private void addAuthor(object obj)
        {
            var tmp = Author.ToList();
            tmp.Add(NewAuthor);
            Author = tmp.ToArray();
        }
        private bool canAddAuthor(object obj)
        {
            return !string.IsNullOrEmpty(NewAuthor) && !MainWindow.IsBusy;
        }
        private void removeTag(object obj)
        {
            Tags = Tags.Where(val => val != Tags[SelectedTag]).ToArray();
        }
        private bool canRemoveTag(object obj)
        {
            if (Tags != null && Tags.Count() > 0)
            {
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }
        private void addTag(object obj)
        {
            var tmp = Tags.ToList();
            tmp.Add(TagsBox);
            Tags = tmp.ToArray();
        }
        private bool canAddTag(object obj)
        {
            return !MainWindow.IsBusy;
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
        private void RaisePropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
