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
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using EndlessModding.Common;
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator;
using EndlessModding.EndlessSpace2.Common.Classes.EncounterPlayDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition;
using EndlessModding.EndlessSpace2.Common.Files;
using SteamKit2.Internal;
using SimulationDescriptorReference = EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition.SimulationDescriptorReference;
using XmlNamedReference = EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition.XmlNamedReference;

namespace EndlessModding.EndlessSpace2.Skill
{
    public class SkillViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public ObservableConcurrentCollection<HeroSkillDefinition> Skills { get; set; }
        public HeroSkillDefinition CurrentSkill
        {
            get => _currentSkill;
            set
            {
                if (_currentSkill != value)
                {
                    if (MainWindow != null)
                        MainWindow.IsBusy = true;

                    saveHero();
                    _currentSkill = value;
                    loadSkill(null);
                    RaisePropertyChanged();

                    if (MainWindow != null)
                        MainWindow.IsBusy = false;
                }
            }
        }

        #region Skill Definition
        public ICommand LoadSkill { get; }
        public ICommand NewSkill { get; }
        public ICommand AddLevel { get; }
        public ICommand RemoveLevel { get; }
        public ICommand AddTag { get; }
        public ICommand RemoveTag { get; }
        public string SkillName
        {
            get => _skillName;
            set
            {
                if (_skillName != value)
                {
                    _skillName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Tags Tags
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

        public BindingList<HeroSkillLevelDefinition> CurrentSkillLevels { get; set; } =
            new BindingList<HeroSkillLevelDefinition>();
        public int Cost
        {
            get => _cost;
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int CurrentTag
        {
            get => _currentTag;
            set
            {
                if (_currentTag != value)
                {
                    _currentTag = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string SkillTreeRef
        {
            get => _skillTreeRef;
            set
            {
                if (_skillTreeRef != value)
                {
                    _skillTreeRef = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string NewTag
        {
            get => _newTag;
            set
            {
                if (_newTag != value)
                {
                    _newTag = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroSkillLevelDefinition SkillLevel
        {
            get => _skillLevel;
            set
            {
                if (_skillLevel != value)
                {
                    _skillLevel = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroSkillLevelDefinition CurrentSkillLevel
        {
            get => _currentSkillLevel;
            set
            {
                if (_currentSkillLevel != value)
                {
                    _currentSkillLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion
        #region Skill Level

        public string SkillLevelName
        {
            get => _skillLevelName;
            set
            {
                if (_skillLevelName != value)
                {
                    _skillLevelName = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
        public BindingList<SimulationDescriptorReference> HeroSDR { get; set; } =
            new BindingList<SimulationDescriptorReference>();
        public BindingList<SimulationDescriptorReference> SenateSDR { get; set; } =
            new BindingList<SimulationDescriptorReference>();
        public BindingList<SimulationDescriptorReference> ShipSDR { get; set; } =
            new BindingList<SimulationDescriptorReference>();
        public BindingList<SimulationDescriptorReference> SystemSDR { get; set; } =
            new BindingList<SimulationDescriptorReference>();
        public BindingList<EncounterPlayDefinition> Encounters { get; set; } =
            new BindingList<EncounterPlayDefinition>();
        public BindingList<MasteryLevel> MasteryLevels { get; set; } =
            new BindingList<MasteryLevel>();

        public SimulationDescriptorReference CurrentHeroSDR
        {
            get => _currentHeroSDR;
            set
            {
                if (_currentHeroSDR != value)
                {
                    _currentHeroSDR = value;
                    _currentSimulationDescriptor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationDescriptorReference CurrentSenateSDR
        {
            get => _currentSenateSDR;
            set
            {
                if (_currentSenateSDR != value)
                {
                    _currentSenateSDR = value;
                    _currentSimulationDescriptor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationDescriptorReference CurrentShipSDR
        {
            get => _currentShipSDR;
            set
            {
                if (_currentShipSDR != value)
                {
                    _currentShipSDR = value;
                    _currentSimulationDescriptor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationDescriptorReference CurrentSystemSDR
        {
            get => _currentSystemSDR;
            set
            {
                if (_currentSystemSDR != value)
                {
                    _currentSystemSDR = value;
                    _currentSimulationDescriptor = value;
                    RaisePropertyChanged();
                }
            }
        }
        public EncounterPlayDefinition CurrentEncounter
        {
            get => _currentEncounter;
            set
            {
                if (_currentEncounter != value)
                {
                    _currentEncounter = value;
                    RaisePropertyChanged();
                }
            }
        }
        public MasteryLevel CurrentMasteryLevel
        {
            get => _currentMasteryLevel;
            set
            {
                if (_currentMasteryLevel != value)
                {
                    _currentMasteryLevel = value;
                    RaisePropertyChanged();
                }
            }
        }
        public SimulationDescriptorReference CurrentSimulationDescriptor
        {
            get => _currentSimulationDescriptor;
            set
            {
                if (_currentSimulationDescriptor != value)
                {
                    _currentSimulationDescriptor = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _skillName;
        private string _skillLevelName;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor simdes;
        private readonly ILogger _logger;
        private Data _data;
        private Tags _tags;
        private BindingList<HeroSkillLevelDefinition> _skillLevels;
        private int _cost = 0;
        private int _currentTag = 0;
        private HeroSkillLevelDefinition _currentSkillLevel;
        private string _skillTreeRef = "";
        private string _newTag = "";
        private HeroSkillLevelDefinition _skillLevel;
        private HeroSkillDefinition _currentSkill;
        private MasteryLevel _currentMasteryLevel;
        private EncounterPlayDefinition _currentEncounter;
        private SimulationDescriptorReference _currentSystemSDR;
        private SimulationDescriptorReference _currentShipSDR;
        private SimulationDescriptorReference _currentSenateSDR;
        private SimulationDescriptorReference _currentHeroSDR;
        private SimulationDescriptorReference _currentSimulationDescriptor;

        public SkillViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            _data = data;
            Skills = _data.HeroSkillDefinitions;
            LoadSkill = new RelayCommand(canLoadSkill, loadSkill);
            NewSkill = new RelayCommand(canNewSkill, newSkill);
        }
        private void AddArrayToList<T>(BindingList<T> output, T[] input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            output.Clear();
            if (input == null)
            {
                return;
            }
            foreach (T item in input)
            {
                try
                {
                    output.Add(item);
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message, e.InnerException);
                }
            }
        }

        private void loadSkill(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Skills.Count > 0 && CurrentSkill != null)
            {
                MainWindow.IsBusy = true;
                SkillName = CurrentSkill.Name;
                Tags = CurrentSkill.Tags;
                Cost = CurrentSkill.Cost;
                SkillTreeRef = CurrentSkill.HeroSkillTreeReference;
                AddArrayToList(CurrentSkillLevels, CurrentSkill.SkillLevel);
                MainWindow.IsBusy = false;

                if (CurrentSkillLevels.Count > 0)
                {
                    CurrentSkillLevel = CurrentSkillLevels[0];

                    SkillLevelName = CurrentSkillLevel.Name;
                    AddArrayToList(HeroSDR, CurrentSkillLevel.HeroSimulationDescriptorReference);
                    AddArrayToList(SenateSDR, CurrentSkillLevel.SenateSimulationDescriptorReference);
                    AddArrayToList(ShipSDR, CurrentSkillLevel.ShipSimulationDescriptorReference);
                    AddArrayToList(SystemSDR, CurrentSkillLevel.SystemSimulationDescriptorReference);
                    //AddArrayToList(Encounters, CurrentSkillLevel.EncounterPlayReference);
                    AddArrayToList(MasteryLevels, CurrentSkillLevel.MasteryLevel);
                }
            }
        }

        private bool canLoadSkill(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void newSkill(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Skills.AddFromEnumerable(new HeroSkillDefinition[] { new HeroSkillDefinition() { Custom = true } });
            CurrentSkill = Skills.Last();
        }

        private bool canNewSkill(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void saveHero()
        {/*
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            if (Skills.Count > 0 && CurrentSkill != null && CurrentSkill != null)
            {
                MainWindow.IsBusy = true;
                bool modified = false;
                if (CurrentSkill.Name != Name)
                {
                    CurrentSkill.Name = Name;
                    RaisePropertyChanged(CurrentSkill, "Name");
                    modified = true;
                }
                if (CurrentSkill.RealName != RealName)
                {
                    CurrentSkill.RealName = RealName;
                    RaisePropertyChanged(CurrentSkill, "RealName");
                    modified = true;
                }
                if (CurrentSkill.Description != Description)
                {
                    CurrentSkill.Description = Description;
                    RaisePropertyChanged(CurrentSkill, "Description");
                    modified = true;
                }
                if (CurrentSkill.Hidden != Hidden)
                {
                    CurrentSkill.Hidden = Hidden;
                    RaisePropertyChanged(CurrentSkill, "Hidden");
                    modified = true;
                }
                if (CurrentSkill.IgnoreInstanceNumber != IgnoreInstanceNumber)
                {
                    CurrentSkill.IgnoreInstanceNumber = IgnoreInstanceNumber;
                    RaisePropertyChanged(CurrentSkill, "IgnoreInstanceNumber");
                    modified = true;
                }
                if (CurrentSkill.ModelPath != ModelPath)
                {
                    CurrentSkill.ModelPath = ModelPath;
                    RaisePropertyChanged(CurrentSkill, "ModelPath");
                    modified = true;
                }
                if (CurrentSkill.Affinity == null || CurrentSkill.Affinity.Name != GetReferenceFromObject(Affinity)?.Name)
                {
                    CurrentSkill.Affinity = GetReferenceFromObject(Affinity);
                    RaisePropertyChanged(CurrentSkill, "Affinity");
                    modified = true;
                }
                if (CurrentSkill.Class == null || CurrentSkill.Class.Name != GetReferenceFromObject(CEcon_GetAssetClassInfo_Request.Class)?.Name)
                {
                    CurrentSkill.Class = GetReferenceFromObject(CEcon_GetAssetClassInfo_Request.Class);
                    RaisePropertyChanged(CurrentSkill, "Class");
                    modified = true;
                }
                if (CurrentSkill.Politics == null || CurrentSkill.Politics.Name != GetReferenceFromObject(Politic)?.Name)
                {
                    CurrentSkill.Politics = GetReferenceFromObject(Politic);
                    RaisePropertyChanged(CurrentSkill, "Politics");
                    modified = true;
                }
                if (CurrentSkill.ShipDesign == null || CurrentSkill.ShipDesign.Name != GetReferenceFromObject(Ship)?.Name)
                {
                    CurrentSkill.ShipDesign = GetReferenceFromObject(Ship);
                    RaisePropertyChanged(CurrentSkill, "ShipDesign");
                    modified = true;
                }

                if (CurrentSkills.Count != 0 && CurrentSkill.Skill != null)
                {
                    if (!CurrentSkill.Skill.Select(x => x.Name)
                        .SequenceEqual(GetReferenceFromObject(CurrentSkills).Select(x => x.Name))) //compare and change if not the same
                    {
                        CurrentSkill.Skill = GetReferenceFromObject(CurrentSkills);
                        RaisePropertyChanged(CurrentSkill, "Skill");
                        modified = true;
                    }
                }
                else if (CurrentSkills.Count == 0 && CurrentSkill.Skill == null)
                {
                    //both null, ignore
                }
                else
                {
                    CurrentSkill.Skill = GetReferenceFromObject(CurrentSkills);
                    RaisePropertyChanged(CurrentSkill, "Skill");
                    modified = true;
                }

                if (CurrentSkillTrees.Count != 0 && CurrentSkill.SkillTree != null)
                {
                    if (!CurrentSkill.SkillTree.Select(x => x.Name)
                        .SequenceEqual(GetReferenceFromObject(CurrentSkillTrees).Select(x => x.Name)))
                    {
                        CurrentSkill.SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                        RaisePropertyChanged(CurrentSkill, "SkillTree");
                        modified = true;
                    }
                }
                else if (CurrentSkillTrees.Count == 0 && CurrentSkill.SkillTree == null)
                {
                    //both null, ignore
                }
                else
                {
                    CurrentSkill.SkillTree = GetReferenceFromObject(CurrentSkillTrees);
                    RaisePropertyChanged(CurrentSkill, "SkillTree");
                    modified = true;
                }

                if (modified)
                {
                    CurrentSkill.Custom = true;
                    RaisePropertyChanged(CurrentSkill, "Custom");
                }
                MainWindow.IsBusy = false;
            }*/
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
