using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.ShipDesignDefinitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EndlessModding.EndlessSpace2.Common.Classes.TraitorBonusThresholdDefinition;
using EndlessModding.EndlessSpace2.Common.Files;
using log4net.Repository.Hierarchy;
using XmlNamedReference = EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition.XmlNamedReference;

namespace EndlessModding.EndlessSpace2.Hero
{
    public class HeroViewModel : INotifyPropertyChanged
    {
        //Public View Models
        public EndlessSpace2ViewModel MainWindow { get; set; }
        //properties
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value?.Replace(" ", ""))
                {
                    _name = value?.Replace(" ", "");
                    RaisePropertyChanged();
                }
            }
        }
        public string RealName
        {
            get => _realName;
            set
            {
                if (_realName != value)
                {
                    _realName = value;
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
        public bool Hidden
        {
            get => _hidden;
            set
            {
                if (_hidden != value)
                {
                    _hidden = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroAffinityDefinition Affinity
        {
            get => _affinity;
            set
            {
                if (_affinity != value)
                {
                    _affinity = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroClassDefinition Class
        {
            get => _class;
            set
            {
                if (_class != value)
                {
                    _class = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroPoliticsDefinition Politic
        {
            get => _politics;
            set
            {
                if (_politics != value)
                {
                    _politics = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ShipDesignDefinition Ship
        {
            get => _ship;
            set
            {
                if (_ship != value)
                {
                    _ship = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int CurrentHero
        {
            get => _currentHero;
            set
            {
                if (_currentHero != value)
                {
                    if (MainWindow != null)
                        MainWindow.IsBusy = true;

                    saveHero();
                    _currentHero = value;
                    loadHero(null);
                    RaisePropertyChanged();

                    if (MainWindow != null)
                        MainWindow.IsBusy = false;
                }
            }
        }
        public WriteableBitmap MoodImage
        {
            get => _moodImage;
            set
            {
                if (_moodImage != value)
                {
                    _moodImage = value;
                    RaisePropertyChanged();
                }
            }
        }
        public WriteableBitmap LargeImage
        {
            get => _largeImage;
            set
            {
                if (_largeImage != value)
                {
                    _largeImage = value;
                    RaisePropertyChanged();
                }
            }
        }
        public WriteableBitmap MediumImage
        {
            get => _mediumImage;
            set
            {
                if (_mediumImage != value)
                {
                    _mediumImage = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand LoadHero { get; }
        public ICommand NewHero { get; }
        public ICommand AddSkill { get; }
        public ICommand RemoveSkill { get; }
        public ICommand AddSkillTree { get; }
        public ICommand RemoveSkillTree { get; }
        public ICommand LoadMoodImage { get; }
        public ICommand LoadLargeImage { get; }
        public ICommand LoadMediumImage { get; }
        //field

        public ObservableConcurrentCollection<HeroDefinition> Heros { get; set; }
        public ObservableConcurrentCollection<HeroAffinityDefinition> Affinities { get; set; }
        public ObservableConcurrentCollection<HeroClassDefinition> Classes { get; set; }
        public ObservableConcurrentCollection<HeroPoliticsDefinition> Politics { get; set; }
        public ObservableConcurrentCollection<ShipDesignDefinition> Ships { get; set; }
        public ObservableConcurrentCollection<Common.Classes.HeroSkillDefinition.HeroSkillDefinition> Skills { get; set; }
        public ObservableConcurrentCollection<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> SkillTrees { get; set; }




        public BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition> CurrentSkills { get; set; } = new BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> CurrentSkillTrees { get; set; } = new BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();

        public Common.Classes.HeroSkillDefinition.HeroSkillDefinition SelectedCurrentSkill { get; set; } = null;
        public Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition SelectedCurrentSkillTree { get; set; } = null;

        public Common.Classes.HeroSkillDefinition.HeroSkillDefinition SelectedSkill { get; set; } = null;
        public Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition SelectedSkillTree { get; set; } = null;

        private readonly ILogger _logger;
        private Data _data;
        private string _name;
        private string _realName;
        private string _description;
        private bool _hidden;
        private HeroAffinityDefinition _affinity;
        private HeroClassDefinition _class;
        private HeroPoliticsDefinition _politics;
        private ShipDesignDefinition _ship;
        private int _currentHero = 0;
        private WriteableBitmap _moodImage = null;
        private WriteableBitmap _largeImage = null;
        private WriteableBitmap _mediumImage = null;

        public HeroViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            _data = data;
            Heros = _data.HeroDefinitions;
            CurrentHero = Heros.Count - 1;
            Affinities = _data.HeroAffinityDefinitions;
            Classes = _data.HeroClassDefinitions;
            Politics = _data.HeroPoliticsDefinitions;
            Ships = _data.ShipDesignDefinitions;
            Skills = _data.HeroSkillDefinitions;
            SkillTrees = _data.HeroSkillTreeDefinitions;
            LoadHero = new RelayCommand(canLoadHero, loadHero);
            NewHero = new RelayCommand(canNewHero, newHero);
            AddSkill = new RelayCommand(canAddSkill, addSkill);
            RemoveSkill = new RelayCommand(canRemoveSkill, removeSkill);
            AddSkillTree = new RelayCommand(canAddSkillTree, addSkillTree);
            RemoveSkillTree = new RelayCommand(canRemoveSkillTree, removeSkillTree);
            LoadMoodImage = new RelayCommand(canLoadMoodImage, loadMoodImage);
            LoadLargeImage = new RelayCommand(canLoadLargeImage, loadLargeImage);
            LoadMediumImage = new RelayCommand(canLoadMediumImage, loadMediumImage);

            RaisePropertyChanged();
        }

        private async void loadMediumImage(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Medium Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            double x = 180d / (double)img.PixelWidth;
            double y = 240d / (double)img.PixelHeight;
            var s = new ScaleTransform(x, y);
            var res = new TransformedBitmap(img, s);
            MediumImage = new WriteableBitmap(res);
            MediumImage.Freeze();
            MainWindow.IsBusy = false;
        }

        private bool canLoadMediumImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private async void loadLargeImage(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Large Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            double x = 360d / (double)img.PixelWidth;
            double y = 180d / (double)img.PixelHeight;
            var s = new ScaleTransform(x, y);
            var res = new TransformedBitmap(img, s);
            LargeImage = new WriteableBitmap(res);
            LargeImage.Freeze();
            MainWindow.IsBusy = false;
        }

        private bool canLoadLargeImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private async void loadMoodImage(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Mood Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            double x = 1324d / (double)img.PixelWidth;
            double y = 712d / (double)img.PixelHeight;
            var s = new ScaleTransform(x, y);
            var res = new TransformedBitmap(img, s);
            MoodImage = new WriteableBitmap(res);
            MoodImage.Freeze();
            MainWindow.IsBusy = false;
        }

        private bool canLoadMoodImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private void removeSkillTree(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (SelectedSkillTree != null)
            {
                CurrentSkillTrees.Remove(SelectedSkillTree);
                if (CurrentSkillTrees.Count != 0)
                {
                    SelectedSkillTree = CurrentSkillTrees[0];
                }
                else
                {
                    SelectedSkillTree = null;
                }
            }
        }

        private bool canRemoveSkillTree(object obj)
        {
            if (SkillTrees != null)
            {
                return CurrentHero >= 0 && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addSkillTree(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (SelectedCurrentSkillTree != null)
            {
                if (!CurrentSkillTrees.Contains(SelectedCurrentSkillTree))
                {
                    CurrentSkillTrees.Add(SelectedCurrentSkillTree);
                }
            }
        }

        private bool canAddSkillTree(object obj)
        {
            if (SkillTrees != null)
            {
                return CurrentHero >= 0 && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void removeSkill(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (SelectedSkill != null)
            {
                CurrentSkills.Remove(SelectedSkill);
                if (CurrentSkills.Count != 0)
                {
                    SelectedSkill = CurrentSkills[0];
                }
                else
                {
                    SelectedSkill = null;
                }
            }
        }

        private bool canRemoveSkill(object obj)
        {
            if (Skills != null)
            {
                return CurrentHero >= 0 && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addSkill(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (SelectedCurrentSkill != null)
            {
                if (!CurrentSkills.Contains(SelectedCurrentSkill))
                {
                    CurrentSkills.Add(SelectedCurrentSkill);
                }
            }
        }

        private bool canAddSkill(object obj)
        {
            if (Skills != null)
            {
                return CurrentHero >= 0 && !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private XmlNamedReference[] GetReferenceFromObject<T>(BindingList<T> input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            List<XmlNamedReference> output = new List<XmlNamedReference>();
            if (input == null)
            {
                return null;
            }

            foreach (T item in input)
            {
                try
                {
                    output.Add(new XmlNamedReference() { Name = (string)item.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(item) });
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message, e.InnerException);
                }
            }
            return output.ToArray();
        }
        private XmlNamedReference GetReferenceFromObject<T>(T input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (input == null)
            {
                return null;
            }
            try
            {
                return new XmlNamedReference() { Name = (string)input.GetType().GetProperties().Where(x => x.Name == "Name").First().GetValue(input) };
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e.InnerException);
                return null;
            }
        }
        private void GetObjectFromReference<T>(BindingList<T> output, ObservableConcurrentCollection<T> lookup, XmlNamedReference[] input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            output.Clear();
            var lookfor = lookup.ElementAt(0).GetType().GetProperties().Where(x => x.Name == "Name").First();
            if (input == null)
            {
                return;
            }
            foreach (XmlNamedReference item in input)
            {
                try
                {
                    output.Add(lookup.First(x => lookfor.GetValue(x).Equals(item.Name)));
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message, e.InnerException);
                }
            }
        }
        private T GetObjectFromReference<T>(ObservableConcurrentCollection<T> lookup, XmlNamedReference input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            var lookfor = lookup.ElementAt(0).GetType().GetProperties().First(x => x.Name == "Name");
            if (input == null)
            {
                return default;
            }
            try
            {
                return lookup.First(x => lookfor.GetValue(x).Equals(input.Name));
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e.InnerException);
                return default(T);
            }
        }

        private void loadHero(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Heros.Count > 0)
            {
                Name = Heros.ElementAt(CurrentHero).Name;
                RealName = Heros.ElementAt(CurrentHero).RealName;
                Description = Heros.ElementAt(CurrentHero).Description;
                Hidden = Heros.ElementAt(CurrentHero).Hidden;
                Affinity = GetObjectFromReference(Affinities, Heros.ElementAt(CurrentHero).Affinity);
                Class = GetObjectFromReference(Classes, Heros.ElementAt(CurrentHero).Class);
                Politic = GetObjectFromReference(Politics, Heros.ElementAt(CurrentHero).Politics);
                Ship = GetObjectFromReference(Ships, Heros.ElementAt(CurrentHero).ShipDesign);
                GetObjectFromReference(CurrentSkills, Skills, Heros.ElementAt(CurrentHero).Skill);
                GetObjectFromReference(CurrentSkillTrees, SkillTrees, Heros.ElementAt(CurrentHero).SkillTree);
                MoodImage = Heros.ElementAt(CurrentHero).MoodImage;
                LargeImage = Heros.ElementAt(CurrentHero).LargeImage;
                MediumImage = Heros.ElementAt(CurrentHero).MediumImage;
            }
        }

        private bool canLoadHero(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void newHero(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Heros.AddFromEnumerable(new HeroDefinition[] { new HeroDefinition() { Custom = true } });
            CurrentHero = Heros.Count - 1;
        }

        private bool canNewHero(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveHero()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Heros.Count > 0 && CurrentHero >= 0)
            {
                bool modified = false;
                if (Heros.ElementAt(CurrentHero).Name != Name)
                {
                    Heros.ElementAt(CurrentHero).Name = Name;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Name");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).RealName != RealName)
                {
                    Heros.ElementAt(CurrentHero).RealName = RealName;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "RealName");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).Description != Description)
                {
                    Heros.ElementAt(CurrentHero).Description = Description;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Description");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).Hidden != Hidden)
                {
                    Heros.ElementAt(CurrentHero).Hidden = Hidden;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Hidden");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).Affinity == null || Heros.ElementAt(CurrentHero).Affinity.Name != GetReferenceFromObject(Affinity)?.Name)
                {
                    Heros.ElementAt(CurrentHero).Affinity = GetReferenceFromObject(Affinity);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Affinity");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).Class == null || Heros.ElementAt(CurrentHero).Class.Name != GetReferenceFromObject(Class)?.Name)
                {
                    Heros.ElementAt(CurrentHero).Class = GetReferenceFromObject(Class);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Class");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).Politics == null || Heros.ElementAt(CurrentHero).Politics.Name != GetReferenceFromObject(Politic)?.Name)
                {
                    Heros.ElementAt(CurrentHero).Politics = GetReferenceFromObject(Politic);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Politics");
                    modified = true;
                }
                if (Heros.ElementAt(CurrentHero).ShipDesign == null || Heros.ElementAt(CurrentHero).ShipDesign.Name != GetReferenceFromObject(Ship)?.Name)
                {
                    Heros.ElementAt(CurrentHero).ShipDesign = GetReferenceFromObject(Ship);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "ShipDesign");
                    modified = true;
                }

                if (CurrentSkills.Count != 0 && Heros.ElementAt(CurrentHero).Skill != null)
                {
                    if (!Heros.ElementAt(CurrentHero).Skill.Select(x => x.Name)
                        .SequenceEqual(GetReferenceFromObject(CurrentSkills).Select(x => x.Name))) //compare and change if not the same
                    {
                        Heros.ElementAt(CurrentHero).Skill = GetReferenceFromObject(CurrentSkills);
                        RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Skill");
                        modified = true;
                    }
                }
                else if (CurrentSkills.Count == 0 && Heros.ElementAt(CurrentHero).Skill == null)
                {
                    //both null, ignore
                }
                else
                {
                    Heros.ElementAt(CurrentHero).Skill = GetReferenceFromObject(CurrentSkills);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Skill");
                    modified = true;
                }

                if (CurrentSkillTrees.Count != 0 && Heros.ElementAt(CurrentHero).SkillTree != null)
                {
                    if (!Heros.ElementAt(CurrentHero).SkillTree.Select(x => x.Name)
                        .SequenceEqual(GetReferenceFromObject(CurrentSkillTrees).Select(x => x.Name)))
                    {
                        Heros.ElementAt(CurrentHero).SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                        RaisePropertyChanged(Heros.ElementAt(CurrentHero), "SkillTree");
                        modified = true;
                    }
                }
                else if (CurrentSkillTrees.Count == 0 && Heros.ElementAt(CurrentHero).SkillTree == null)
                {
                    //both null, ignore
                }
                else
                {
                    Heros.ElementAt(CurrentHero).SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "SkillTree");
                    modified = true;
                }

                Heros.ElementAt(CurrentHero).MoodImage = MoodImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "MoodImage");
                Heros.ElementAt(CurrentHero).LargeImage = LargeImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "LargeImage");
                Heros.ElementAt(CurrentHero).MediumImage = MediumImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "MediumImage");
                if (modified)
                {
                    Heros.ElementAt(CurrentHero).Custom = true;
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
        private void RaisePropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
