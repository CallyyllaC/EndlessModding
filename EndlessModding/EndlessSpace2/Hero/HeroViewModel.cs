using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EndlessModding.EndlessSpace2.Common.Files;
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
                _name = value;
                RaisePropertyChanged();
            }
        }
        public bool Hidden
        {
            get => _hidden;
            set
            {
                _hidden = value;
                RaisePropertyChanged();
            }
        }
        public HeroAffinityDefinition Affinity
        {
            get => _affinity;
            set
            {
                _affinity = value;
                RaisePropertyChanged();
            }
        }
        public HeroClassDefinition Class
        {
            get => _class;
            set
            {
                _class = value;
                RaisePropertyChanged();
            }
        }
        public HeroPoliticsDefinition Politic
        {
            get => _politics;
            set
            {
                _politics = value;
                RaisePropertyChanged();
            }
        }
        public ShipDesignDefinition Ship
        {
            get => _ship;
            set
            {
                _ship = value;
                RaisePropertyChanged();
            }
        }
        public int CurrentHero
        {
            get => _currentHero;
            set
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
        public WriteableBitmap MoodImage
        {
            get => _moodImage;
            set
            {
                _moodImage = value;
                RaisePropertyChanged();
            }
        }
        public WriteableBitmap LargeImage
        {
            get => _largeImage;
            set
            {
                _largeImage = value;
                RaisePropertyChanged();
            }
        }
        public WriteableBitmap MediumImage
        {
            get => _mediumImage;
            set
            {
                _mediumImage = value;
                RaisePropertyChanged();
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
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Medium Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            MediumImage = new WriteableBitmap(img);
            MainWindow.IsBusy = false;
        }

        private bool canLoadMediumImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private async void loadLargeImage(object obj)
        {
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Large Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            LargeImage = new WriteableBitmap(img);
            MainWindow.IsBusy = false;
        }

        private bool canLoadLargeImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private async void loadMoodImage(object obj)
        {
            MainWindow.IsBusy = true;
            string filename = await EndlessModding.Common.IO.IOHandler.OpenFileExplorer("Mood Image", "png");
            if (filename == null)
            {
                return;
            }
            BitmapSource img = new BitmapImage(new Uri(filename, UriKind.Absolute));
            MoodImage = new WriteableBitmap(img);
            MainWindow.IsBusy = false;
        }

        private bool canLoadMoodImage(object obj)
        {
            return CurrentHero >= 0 && !MainWindow.IsBusy;
        }

        private void removeSkillTree(object obj)
        {
            if (SelectedSkillTree != null)
            {
                CurrentSkillTrees.Remove(SelectedSkillTree);
                SelectedSkillTree = null;
            }
        }

        private bool canRemoveSkillTree(object obj)
        {
            if (SkillTrees != null)
            {
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addSkillTree(object obj)
        {
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
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void removeSkill(object obj)
        {
            if (SelectedSkill != null)
            {
                CurrentSkills.Remove(SelectedSkill);
                SelectedSkill = null;
            }
        }

        private bool canRemoveSkill(object obj)
        {
            if (Skills != null)
            {
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private void addSkill(object obj)
        {
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
                return !MainWindow.IsBusy;
            }
            else
            {
                return false;
            }
        }

        private XmlNamedReference[] GetReferenceFromObject<T>(BindingList<T> input)
        {
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
            if (Heros.Count > 0)
            {
                Name = Heros.ElementAt(CurrentHero).Name;
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
            Heros.AddFromEnumerable(new HeroDefinition[] { new HeroDefinition() { Custom = true } });
            CurrentHero = Heros.Count - 1;
        }

        private bool canNewHero(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveHero()
        {
            if (Heros.Count > 0 && CurrentHero >= 0)
            {
                bool modified = false;
                if (Heros.ElementAt(CurrentHero).Name != Name)
                {
                    Heros.ElementAt(CurrentHero).Name = Name;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Name");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).Hidden != Hidden)
                {
                    Heros.ElementAt(CurrentHero).Hidden = Hidden;
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Hidden");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).Affinity != GetReferenceFromObject(Affinity))
                {
                    Heros.ElementAt(CurrentHero).Affinity = GetReferenceFromObject(Affinity);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Affinity");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).Class != GetReferenceFromObject(Class))
                {
                    Heros.ElementAt(CurrentHero).Class = GetReferenceFromObject(Class);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Class");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).Politics != GetReferenceFromObject(Politic))
                {
                    Heros.ElementAt(CurrentHero).Politics = GetReferenceFromObject(Politic);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Politics");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).ShipDesign != GetReferenceFromObject(Ship))
                {
                    Heros.ElementAt(CurrentHero).ShipDesign = GetReferenceFromObject(Ship);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "ShipDesign");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).Skill != GetReferenceFromObject(CurrentSkills))
                {
                    Heros.ElementAt(CurrentHero).Skill = GetReferenceFromObject(CurrentSkills);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "Skill");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                if (Heros.ElementAt(CurrentHero).SkillTree != GetReferenceFromObject(CurrentSkillTrees))
                {
                    Heros.ElementAt(CurrentHero).SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                    RaisePropertyChanged(Heros.ElementAt(CurrentHero), "SkillTree");
                    Heros.ElementAt(CurrentHero).Custom = true;
                }
                Heros.ElementAt(CurrentHero).MoodImage = MoodImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "MoodImage");
                Heros.ElementAt(CurrentHero).LargeImage = LargeImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "LargeImage");
                Heros.ElementAt(CurrentHero).MediumImage = MediumImage;
                RaisePropertyChanged(Heros.ElementAt(CurrentHero), "MediumImage");
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
