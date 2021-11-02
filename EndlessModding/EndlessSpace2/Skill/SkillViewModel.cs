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
using EndlessModding.EndlessSpace2.Common.Classes.Amplitude_Simulator;
using EndlessModding.EndlessSpace2.Common.Classes.EncounterPlayDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition;
using EndlessModding.EndlessSpace2.Common.Files;
using SimulationDescriptorReference = EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition.SimulationDescriptorReference;

namespace EndlessModding.EndlessSpace2.Skill
{
    public class SkillViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public ObservableConcurrentCollection<HeroSkillDefinition> Skills { get; set; }
        public ICommand NewSkillDefinition { get; }

        #region Skill Definition
        public ICommand AddLevel { get; }
        public ICommand RemoveLevel { get; }
        public ICommand AddTag { get; }
        public ICommand RemoveTag { get; }
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
        public BindingList<HeroSkillLevelDefinition> SkillLevels { get; set; }
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

        private Tags _tags;
        private BindingList<HeroSkillLevelDefinition> _skillLevels;
        private int _cost = 0;
        private int _currentTag = 0;
        private string _skillTreeRef = "";
        private string _newTag = "";
        private HeroSkillLevelDefinition _skillLevel;
        #endregion
        #region Skill Level

        #endregion
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
        public BindingList<SimulationDescriptorReference> _heroSDR { get; set; }
        public BindingList<SimulationDescriptorReference> _senateSDR { get; set; }
        public BindingList<SimulationDescriptorReference> _shipSDR { get; set; }
        public BindingList<SimulationDescriptorReference> _systemSDR { get; set; }
        public BindingList<EncounterPlayDefinition> _encounters { get; set; }
        public BindingList<MasteryLevel> _masteryLevels { get; set; }
        private string _skillName;
        private SimulationDescriptor simdes;
        private readonly ILogger _logger;
        public SkillViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
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
