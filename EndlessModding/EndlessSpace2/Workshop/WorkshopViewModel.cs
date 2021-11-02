using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.Common.IO;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Runtime;
using EndlessModding.EndlessSpace2.Common.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EndlessModding.EndlessSpace2.Common.Files;

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
        public ICommand Refresh { get; }
        public ICommand Export { get; }

        public string[] Tags
        {
            get => _tags;
            set
            {
                if (_tags != value)
                {
                    _tags = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ObservableConcurrentCollection<RuntimePlugin> Plugins
        {
            get => _plugins;
            set
            {
                if (_plugins != value)
                {
                    _plugins = value;
                    RaisePropertyChanged();
                }
            }
        }
        public WriteableBitmap Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    RaisePropertyChanged();
                }
            }
        }
        public RuntimeModuleType Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _title?.Replace(" ", "");
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string[] Author
        {
            get => _author;
            set
            {
                if (_author != value)
                {
                    _author = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string ReleaseNotes
        {
            get => _releaseNotes;
            set
            {
                if (_releaseNotes != value)
                {
                    _releaseNotes = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Version
        {
            get => _version;
            set
            {
                if (_version != value)
                {
                    _version = value;
                    RaisePropertyChanged();
                }
            }
        }
        public RuntimeModule CurrentMod
        {
            get => _currentMod;
            set
            {
                if (_currentMod != value)
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
        }
        public int SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                if (_selectedAuthor != value)
                {
                    _selectedAuthor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int SelectedTag
        {
            get => _selectedTag;
            set
            {
                if (_selectedTag != value)
                {
                    _selectedTag = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string NewAuthor
        {
            get => _newAuthor;
            set
            {
                if (_newAuthor != value)
                {
                    _newAuthor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ObservableConcurrentCollection<RuntimeModule> Mods
        {
            get => _mods;
            set
            {
                if (_mods != value)
                {
                    _mods = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ObservableConcurrentCollection<IExportable> Exportables
        {
            get => _exportables;
            set
            {
                if (_exportables != value)
                {
                    _exportables = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string TagsBox
        {
            get => _tagsBox;
            set
            {
                if (_tagsBox != value)
                {
                    _tagsBox = value;
                    RaisePropertyChanged();
                }
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
        private ObservableConcurrentCollection<RuntimePlugin> _plugins = new ObservableConcurrentCollection<RuntimePlugin>();
        private RuntimeModule _currentMod = null;
        private int _selectedAuthor = 0;
        private int _selectedTag = 0;
        private string _newAuthor = "";
        private readonly ILogger _logger;
        private ObservableConcurrentCollection<RuntimeModule> _mods;
        private ObservableConcurrentCollection<IExportable> _exportables;
        private string _version;
        private string _releaseNotes;
        private string[] _author;
        private string _description;
        private string _title;
        private RuntimeModuleType _type;
        private WriteableBitmap _image;
        private Data _data;
        private Export _export;

        public WorkshopViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            _data = data;
            _export = new Export(Logger);
            Mods = _data.RuntimeModules;
            Exportables = _data.ExportableData;
            CurrentMod = null;
            GetImage = new RelayCommand(canGetImage, getImage);
            NewMod = new RelayCommand(canNewMod, newMod);
            AddAuthor = new RelayCommand(canAddAuthor, addAuthor);
            RemoveAuthor = new RelayCommand(canRemoveAuthor, removeAuthor);
            AddTag = new RelayCommand(canAddTag, addTag);
            RemoveTag = new RelayCommand(canRemoveTag, removeTag);
            Refresh = new RelayCommand(canRefresh, refresh);
            Export = new RelayCommand(canExport, export);

            RaisePropertyChanged();
        }

        private async void export(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            IExportable[] export = Exportables.Where(x => x.Enabled).ToArray();
            saveMod();
            _export.SaveMod(CurrentMod, export, MainWindow.MainViewModel.LocalModDirectory);

            await Task.CompletedTask;
            MainWindow.IsBusy = false;
        }

        private bool canExport(object obj)
        {
            return !MainWindow.IsBusy && CurrentMod != null;
        }
        private async void refresh(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            _data.GetExportableData();
            await Task.CompletedTask;
            MainWindow.IsBusy = false;
        }

        private bool canRefresh(object obj)
        {
            return true;
        }
        private void newMod(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Mods.AddFromEnumerable(new RuntimeModule[] { new RuntimeModule() { Type = RuntimeModuleType.Extension } });
            CurrentMod = Mods.Last();
        }
        private bool canNewMod(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private async void getImage(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Mod Icon", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            double x = 430d / (double)img.PixelWidth;
            double y = 430d / (double)img.PixelHeight;
            var s = new ScaleTransform(x, y);
            var res = new TransformedBitmap(img, s);
            Image = new WriteableBitmap(res);
            Image.Freeze();
            MainWindow.IsBusy = false;
        }
        private bool canGetImage(object obj)
        {
            return !MainWindow.IsBusy && CurrentMod != null;
        }
        private void loadMod(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Mods.Count > 0)
            {
                MainWindow.IsBusy = true;
                Version = CurrentMod.Version;
                ReleaseNotes = CurrentMod.ReleaseNotes;
                Author = CurrentMod.Author;
                Description = CurrentMod.Description;
                Title = CurrentMod.Title;
                Type = CurrentMod.Type;
                Image = CurrentMod.Image;

                var tmpTags = CurrentMod.Tags;
                if (tmpTags != null && !string.IsNullOrEmpty(tmpTags.Value))
                {
                    if (tmpTags.Value.Split(',').Count() > 1)
                        Tags = tmpTags.Value.Split(',');
                    else
                        Tags = tmpTags.Value.Split(' ');

                    Tags = Tags.Select(innerItem => innerItem.Trim()).ToArray();
                }
                else
                {
                    Tags = new string[0];
                }

                Plugins.Clear();
                if (CurrentMod.Plugins != null)
                {
                    foreach (var item in CurrentMod.Plugins)
                    {
                        Plugins.AddFromEnumerable(new RuntimePlugin[] { item });
                    }
                }
                MainWindow.IsBusy = false;
            }
        }
        private void saveMod()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Mods.Count > 0 && CurrentMod != null)
            {
                MainWindow.IsBusy = true;
                CurrentMod.Name = Name;
                CurrentMod.Version = Version;
                RaisePropertyChanged(CurrentMod, "Version");
                CurrentMod.ReleaseNotes = ReleaseNotes;
                RaisePropertyChanged(CurrentMod, "ReleaseNotes");
                CurrentMod.Author = Author;
                RaisePropertyChanged(CurrentMod, "Author");
                CurrentMod.Description = Description;
                RaisePropertyChanged(CurrentMod, "Description");
                CurrentMod.Title = Title;
                RaisePropertyChanged(CurrentMod, "Title");
                CurrentMod.Type = Type;
                RaisePropertyChanged(CurrentMod, "Type");
                CurrentMod.Image = Image;
                RaisePropertyChanged(CurrentMod, "Image");
                CurrentMod.Plugins = Plugins.ToArray();
                RaisePropertyChanged(CurrentMod, "Plugins");
                CurrentMod.Tags = new Tags();
                if (Tags.Length > 0)
                {
                    CurrentMod.Tags.Value = string.Join(", ", Tags);
                }
                RaisePropertyChanged(CurrentMod, "Tags");
                MainWindow.IsBusy = false;
            }
        }
        private void removeAuthor(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Author = Author.Where(val => val != Author[SelectedAuthor]).ToArray();
        }
        private bool canRemoveAuthor(object obj)
        {
            if (Author != null && Author.Count() > SelectedAuthor)
            {
                return !MainWindow.IsBusy && CurrentMod != null;
            }
            else
            {
                return false;
            }
        }
        private void addAuthor(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            List<string> tmp = new List<string>();
            if (Author != null)
            {
                tmp = Author.ToList();
            }
            tmp.Add(NewAuthor);
            Author = tmp.ToArray();
        }
        private bool canAddAuthor(object obj)
        {
            return !string.IsNullOrEmpty(NewAuthor) && !MainWindow.IsBusy && CurrentMod != null;
        }
        private void removeTag(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Tags = Tags.Where(val => val != Tags[SelectedTag]).ToArray();
        }
        private bool canRemoveTag(object obj)
        {
            if (Tags != null && Tags.Count() > 0)
            {
                return !MainWindow.IsBusy && CurrentMod != null;
            }
            else
            {
                return false;
            }
        }
        private void addTag(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var tmp = Tags.ToList();
            tmp.Add(TagsBox);
            Tags = tmp.ToArray();
        }
        private bool canAddTag(object obj)
        {
            return !MainWindow.IsBusy && CurrentMod != null;
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
