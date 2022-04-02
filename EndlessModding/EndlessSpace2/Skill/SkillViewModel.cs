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
using EndlessModding.Common.DataStructures;
using EndlessModding.EndlessSpace2.Common.Classes.EncounterFormationDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.EncounterPlayDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroMasteryDefinitions;
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition;
using EndlessModding.EndlessSpace2.Common.Files;
using SimulationDescriptorReference = EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition.SimulationDescriptorReference;
using XmlNamedReference = EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition.XmlNamedReference;

namespace EndlessModding.EndlessSpace2.Skill
{
    public class SkillViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public EndlessObservableConcurrentCollection<HeroSkillDefinition> Skills { get; set; }
        public EndlessObservableConcurrentCollection<EncounterPlayDefinition> Encounters { get; set; }
        public EndlessObservableConcurrentCollection<HeroMasteryDefinition> MasteryLevels { get; set; }
        public EndlessObservableConcurrentCollection<Common.Classes.Amplitude_Simulator.SimulationDescriptor> SimulationDescriptorDefinitions { get; set; }/*
        public EndlessObservableConcurrentCollection<Common.Classes.Amplitude_Simulator.SimulationDescriptor> SystemSDRs { get => SimulationDescriptorDefinitions.Where(x=> x.Type == "System")}
        public EndlessObservableConcurrentCollection<Common.Classes.Amplitude_Simulator.SimulationDescriptor> ShipSDRs { get => }
        public EndlessObservableConcurrentCollection<Common.Classes.Amplitude_Simulator.SimulationDescriptor> SenateSDRs { get => }
        public EndlessObservableConcurrentCollection<Common.Classes.Amplitude_Simulator.SimulationDescriptor> HeroSDRs { get =>  }*/
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

        /// <summary>
        /// Skill definition skill levels
        /// </summary>
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

        public ICommand AddHeroSDR { get; }
        public ICommand RemoveHeroSDR { get; }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor CurrentHeroSDR
        {
            get => _currentHeroSDR;
            set
            {
                if (_currentHeroSDR != value)
                {
                    _currentHeroSDR = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor ComboHeroSDR
        {
            get => _comboHeroSDR;
            set
            {
                if (_comboHeroSDR != value)
                {
                    _comboHeroSDR = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand AddSenateSDR { get; }
        public ICommand RemoveSenateSDR { get; }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor CurrentSenateSDR
        {
            get => _currentSenateSDR;
            set
            {
                if (_currentSenateSDR != value)
                {
                    _currentSenateSDR = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor ComboSenateSDR
        {
            get => _comboSenateSDR;
            set
            {
                if (_comboSenateSDR != value)
                {
                    _comboSenateSDR = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand AddShipSDR { get; }
        public ICommand RemoveShipSDR { get; }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor CurrentShipSDR
        {
            get => _currentShipSDR;
            set
            {
                if (_currentShipSDR != value)
                {
                    _currentShipSDR = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor ComboShipSDR
        {
            get => _comboShipSDR;
            set
            {
                if (_comboShipSDR != value)
                {
                    _comboShipSDR = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand AddSystemSDR { get; }
        public ICommand RemoveSystemSDR { get; }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor CurrentSystemSDR
        {
            get => _currentSystemSDR;
            set
            {
                if (_currentSystemSDR != value)
                {
                    _currentSystemSDR = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Common.Classes.Amplitude_Simulator.SimulationDescriptor ComboSystemSDR
        {
            get => _comboSystemSDR;
            set
            {
                if (_comboSystemSDR != value)
                {
                    _comboSystemSDR = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand AddMastery { get; }
        public ICommand RemoveMastery { get; }
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
        public MasteryLevel ComboMasteryLevel
        {
            get => _comboMasteryLevel;
            set
            {
                if (_comboMasteryLevel != value)
                {
                    _comboMasteryLevel = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand AddEncounter { get; }
        public ICommand RemoveEncounter { get; }
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
        public EncounterPlayDefinition ComboEncounter
        {
            get => _comboEncounter;
            set
            {
                if (_comboEncounter != value)
                {
                    _comboEncounter = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> HeroSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> SenateSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> ShipSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> SystemSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> CurrentHeroSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> CurrentSenateSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> CurrentShipSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor> CurrentSystemSDRs { get; set; } =
            new BindingList<Common.Classes.Amplitude_Simulator.SimulationDescriptor>();
        public BindingList<MasteryLevel> CurrentMasteryLevels { get; set; } =
            new BindingList<MasteryLevel>();
        public BindingList<EncounterPlayDefinition> CurrentEncounters { get; set; } =
            new BindingList<EncounterPlayDefinition>();
        #endregion

        #region fields
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
        private HeroSkillDefinition _currentSkill;
        private MasteryLevel _currentMasteryLevel;
        private EncounterPlayDefinition _currentEncounter;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _currentSystemSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _currentShipSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _currentSenateSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _currentHeroSDR;
        private MasteryLevel _comboMasteryLevel;
        private EncounterPlayDefinition _comboEncounter;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _comboSystemSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _comboShipSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _comboSenateSDR;
        private Common.Classes.Amplitude_Simulator.SimulationDescriptor _comboHeroSDR;
        #endregion


        public SkillViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            _data = data;
            Skills = _data.HeroSkillDefinitions;
            Encounters = _data.EncounterPlayDefinitions;
            MasteryLevels = _data.MasteryLevelDefinitions;
            SimulationDescriptorDefinitions = _data.SimulationDescriptorDefinitions;

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
        private void GetObjectFromReference<T>(BindingList<T> output, EndlessObservableConcurrentCollection<T> lookup, XmlNamedReference[] input)
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
        private void GetObjectFromReference<T>(BindingList<T> output, EndlessObservableConcurrentCollection<T> lookup, SimulationDescriptorReference[] input)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            output.Clear();
            var lookfor = lookup.ElementAt(0).GetType().GetProperties().Where(x => x.Name == "Name").First();
            if (input == null)
            {
                return;
            }
            foreach (SimulationDescriptorReference item in input)
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
                    GetObjectFromReference(CurrentHeroSDRs, SimulationDescriptorDefinitions, CurrentSkillLevel.HeroSimulationDescriptorReference);
                    GetObjectFromReference(CurrentSenateSDRs, SimulationDescriptorDefinitions, CurrentSkillLevel.SenateSimulationDescriptorReference);
                    GetObjectFromReference(CurrentShipSDRs, SimulationDescriptorDefinitions, CurrentSkillLevel.ShipSimulationDescriptorReference);
                    GetObjectFromReference(CurrentSystemSDRs, SimulationDescriptorDefinitions, CurrentSkillLevel.SystemSimulationDescriptorReference);
                    GetObjectFromReference(CurrentEncounters, Encounters, CurrentSkillLevel.EncounterPlayReference);
                    AddArrayToList(CurrentMasteryLevels, CurrentSkillLevel.MasteryLevel);


                    //update the comboboxes
                    AddArrayToList(SystemSDRs, _data.SimulationDescriptorDefinitions.Where(x => x.Type == "HeroSkillSystem").ToArray());
                    AddArrayToList(ShipSDRs, _data.SimulationDescriptorDefinitions.Where(x => x.Type == "HeroSkillShip").ToArray());
                    AddArrayToList(SenateSDRs, _data.SimulationDescriptorDefinitions.Where(x => x.Type == "HeroSkillSenator").ToArray());
                    AddArrayToList(HeroSDRs, _data.SimulationDescriptorDefinitions.Where(x => x.Type == "HeroSkill").ToArray());
                }
            }
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
        private bool canLoadSkill(object obj)
        {
            return !MainWindow.IsBusy;
        }

        private void newSkill(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            Skills.Add(new HeroSkillDefinition() { Custom = true });
            CurrentSkill = Skills.Last();
        }

        private bool canNewSkill(object obj)
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
