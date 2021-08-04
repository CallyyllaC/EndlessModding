﻿using Castle.Core.Logging;
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
        public int CurrentMod
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
        private int _currentMod = 0;
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
            _logger = Logger;
            _data = data;
            _export = new Export(Logger);
            Mods = _data.RuntimeModules;
            Exportables = _data.ExportableData;
            CurrentMod = Mods.Count - 1;
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
            IExportable[] export = Exportables.Where(x => x.Enabled).ToArray();
            if (export.Length > 0)
            {
                _export.SaveMod(Mods.ElementAt(CurrentMod), export, MainWindow.MainViewModel.LocOutDir_Text);
            }
        }

        private bool canExport(object obj)
        {
            return !MainWindow.IsBusy && CurrentMod != -1;
        }
        private async void refresh(object obj)
        {
            _data.GetExportableData();
        }

        private bool canRefresh(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private void newMod(object obj)
        {
            Mods.AddFromEnumerable(new RuntimeModule[] { new RuntimeModule() });
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
            double x = 430d / (double)img.PixelWidth;
            double y = 430d / (double)img.PixelHeight;
            var s = new ScaleTransform(x, y);
            var res = new TransformedBitmap(img, s);
            Image = new WriteableBitmap(res);
            Image.Freeze();
        }
        private bool canGetImage(object obj)
        {
            return !MainWindow.IsBusy;
        }
        private void loadMod(object obj)
        {
            if (Mods.Count > 0)
            {
                Version = Mods.ElementAt(CurrentMod).Version;
                ReleaseNotes = Mods.ElementAt(CurrentMod).ReleaseNotes;
                Author = Mods.ElementAt(CurrentMod).Author;
                Description = Mods.ElementAt(CurrentMod).Description;
                Title = Mods.ElementAt(CurrentMod).Title;
                Type = Mods.ElementAt(CurrentMod).Type;
                Image = Mods.ElementAt(CurrentMod).Image;

                var tmpTags = Mods.ElementAt(CurrentMod).Tags;
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
                if (Mods.ElementAt(CurrentMod).Plugins != null)
                {
                    foreach (var item in Mods.ElementAt(CurrentMod).Plugins)
                    {
                        Plugins.AddFromEnumerable(new RuntimePlugin[] { item });
                    }
                }
            }
        }
        private void saveMod()
        {
            if (Mods.Count > 0 && CurrentMod >= 0)
            {
                Mods.ElementAt(CurrentMod).Version = Version;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Version");
                Mods.ElementAt(CurrentMod).ReleaseNotes = ReleaseNotes;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "ReleaseNotes");
                Mods.ElementAt(CurrentMod).Author = Author;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Author");
                Mods.ElementAt(CurrentMod).Description = Description;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Description");
                Mods.ElementAt(CurrentMod).Title = Title;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Title");
                Mods.ElementAt(CurrentMod).Type = Type;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Type");
                Mods.ElementAt(CurrentMod).Image = Image;
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Image");
                Mods.ElementAt(CurrentMod).Plugins = Plugins.ToArray();
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Plugins");
                Mods.ElementAt(CurrentMod).Tags = new Tags();
                if (Tags.Length > 0)
                {
                    Mods.ElementAt(CurrentMod).Tags.Value = string.Join(", ", Tags);
                }
                RaisePropertyChanged(Mods.ElementAt(CurrentMod), "Tags");
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
