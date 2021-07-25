using Castle.Core.Logging;
using EndlessModding.Common;
using EndlessModding.Common.Import;
using EndlessModding.EndlessSpace2.Common.Classes.HeroAffinityDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroClassDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroPoliticsDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.ShipDesignDefinitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        public BindingList<HeroDefinition> Heros { get; set; }
        public BindingList<HeroAffinityDefinition> Affinities { get; set; }
        public BindingList<HeroClassDefinition> Classes { get; set; }
        public BindingList<HeroPoliticsDefinition> Politics { get; set; }
        public BindingList<ShipDesignDefinition> Ships { get; set; }
        public BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition> Skills { get; set; }
        public BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> SkillTrees { get; set; }




        public BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition> CurrentSkills { get; set; } = new BindingList<Common.Classes.HeroSkillDefinition.HeroSkillDefinition>();
        public BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition> CurrentSkillTrees { get; set; } = new BindingList<Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition>();

        public Common.Classes.HeroSkillDefinition.HeroSkillDefinition SelectedCurrentSkill { get; set; } = null;
        public Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition SelectedCurrentSkillTree { get; set; } = null;

        public Common.Classes.HeroSkillDefinition.HeroSkillDefinition SelectedSkill { get; set; } = null;
        public Common.Classes.HeroSkillTreeDefinitions.HeroSkillTreeDefinition SelectedSkillTree { get; set; } = null;

        private readonly ILogger _logger;
        private Import _import;
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

        public HeroViewModel(ILogger Logger, Import import)
        {
            _logger = Logger;
            _import = import;
            Heros = _import.HeroDefinitions;
            CurrentHero = Heros.Count - 1;
            Affinities = _import.HeroAffinityDefinitions;
            Classes = _import.HeroClassDefinitions;
            Politics = _import.HeroPoliticsDefinitions;
            Ships = _import.ShipDesignDefinitions;
            Skills = _import.HeroSkillDefinitions;
            SkillTrees = _import.HeroSkillTreeDefinitions;
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
        private void GetObjectFromReference<T>(BindingList<T> output, BindingList<T> lookup, XmlNamedReference[] input)
        {
            output.Clear();
            var lookfor = lookup[0].GetType().GetProperties().Where(x => x.Name == "Name").First();
            if (input == null)
            {
                return;
            }
            foreach (XmlNamedReference item in input)
            {
                try
                {
                    output.Add(lookup.Where(x => lookfor.GetValue(x).Equals(item.Name)).First());
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message, e.InnerException);
                }
            }
        }
        private T GetObjectFromReference<T>(BindingList<T> lookup, XmlNamedReference input)
        {
            var lookfor = lookup[0].GetType().GetProperties().Where(x => x.Name == "Name").First();
            if (input == null)
            {
                return default;
            }
            try
            {
                return lookup.Where(x => lookfor.GetValue(x).Equals(input.Name)).First();
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
                Name = Heros[CurrentHero].Name;
                Hidden = Heros[CurrentHero].Hidden;
                Affinity = GetObjectFromReference(Affinities, Heros[CurrentHero].Affinity);
                Class = GetObjectFromReference(Classes, Heros[CurrentHero].Class);
                Politic = GetObjectFromReference(Politics, Heros[CurrentHero].Politics);
                Ship = GetObjectFromReference(Ships, Heros[CurrentHero].ShipDesign);
                GetObjectFromReference(CurrentSkills, Skills, Heros[CurrentHero].Skill);
                GetObjectFromReference(CurrentSkillTrees, SkillTrees, Heros[CurrentHero].SkillTree);
                MoodImage = Heros[CurrentHero].MoodImage;
                LargeImage = Heros[CurrentHero].LargeImage;
                MediumImage = Heros[CurrentHero].MediumImage;
            }
        }

        private bool canLoadHero(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void newHero(object obj)
        {
            Heros.Add(new HeroDefinition());
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
                Heros[CurrentHero].Name = Name;
                RaisePropertyChanged(Heros[CurrentHero], "Name");
                Heros[CurrentHero].Hidden = Hidden;
                RaisePropertyChanged(Heros[CurrentHero], "Hidden");
                Heros[CurrentHero].Affinity = GetReferenceFromObject(Affinity);
                RaisePropertyChanged(Heros[CurrentHero], "Affinity");
                Heros[CurrentHero].Class = GetReferenceFromObject(Class);
                RaisePropertyChanged(Heros[CurrentHero], "Class");
                Heros[CurrentHero].Politics = GetReferenceFromObject(Politic);
                RaisePropertyChanged(Heros[CurrentHero], "Politics");
                Heros[CurrentHero].ShipDesign = GetReferenceFromObject(Ship);
                RaisePropertyChanged(Heros[CurrentHero], "ShipDesign");
                Heros[CurrentHero].Skill = GetReferenceFromObject(CurrentSkills);
                RaisePropertyChanged(Heros[CurrentHero], "Skill");
                Heros[CurrentHero].SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                RaisePropertyChanged(Heros[CurrentHero], "SkillTree");
                Heros[CurrentHero].MoodImage = MoodImage;
                RaisePropertyChanged(Heros[CurrentHero], "MoodImage");
                Heros[CurrentHero].LargeImage = LargeImage;
                RaisePropertyChanged(Heros[CurrentHero], "LargeImage");
                Heros[CurrentHero].MediumImage = MediumImage;
                RaisePropertyChanged(Heros[CurrentHero], "MediumImage");
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
