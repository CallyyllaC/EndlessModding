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
using EndlessModding.Common.DataStructures;
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillDefinition;
using EndlessModding.EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions;
using EndlessModding.EndlessSpace2.Common.Files;
using XmlNamedReference = EndlessModding.EndlessSpace2.Common.Classes.HeroSkillTreeDefinitions.XmlNamedReference;

namespace EndlessModding.EndlessSpace2.SkillTree
{
    public class SkillTreeViewModel : INotifyPropertyChanged
    {
        public EndlessSpace2ViewModel MainWindow { get; set; }
        public EndlessObservableConcurrentCollection<HeroSkillTreeDefinition> SkillTrees { get; set; }
        public EndlessObservableConcurrentCollection<HeroSkillDefinition> Skills { get; set; }
        public ICommand LoadSkillTree { get; }
        public ICommand NewSkillTree { get; }
        public ICommand AddStage { get; }
        public ICommand RemoveStage { get; }
        public ICommand AddStageSkill { get; }
        public ICommand RemoveStageSkill { get; }
        public ICommand AddPrereq { get; }
        public ICommand RemovePrereq { get; }
        public HeroSkillTreeDefinition CurrentSkillTree
        {
            get => _currentSkillTree;
            set
            {
                if (_currentSkillTree != value)
                {
                    if (MainWindow != null)
                        MainWindow.IsBusy = true;

                    saveSkillTree();
                    _currentSkillTree = value;
                    loadSkillTree(null);
                    RaisePropertyChanged();

                    if (MainWindow != null)
                        MainWindow.IsBusy = false;
                }
            }
        }
        public string SkillTreeName
        {
            get => _skillTreeName;
            set
            {
                if (_skillTreeName != value)
                {
                    _skillTreeName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public BindingList<HeroSkillTreeStage> SkillTreeStages = new BindingList<HeroSkillTreeStage>();
        public BindingList<HeroSkillTreeSkill> CurrentSkillTreeStageSkills = new BindingList<HeroSkillTreeSkill>();
        public BindingList<Prerequisite> CurrentSkillTreeStageItems = new BindingList<Prerequisite>();
        public HeroSkillTreeStage CurrentSkillTreeStage
        {
            get => _currentSkillTreeStage;
            set
            {

                if (_currentSkillTreeStage != value)
                {
                    _currentSkillTreeStage = value;
                    RaisePropertyChanged();
                }
            }
        }
        public int CurrentSkillTreeStageLevel
        {
            get => _currentSkillTreeStageLevel;
            set
            {

                if (_currentSkillTreeStageLevel != value)
                {
                    _currentSkillTreeStageLevel = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroSkillDefinition CurrentSkillTreeStageSkill
        {
            get => _currentSkillTreeStageSkill;
            set
            {

                if (_currentSkillTreeStageSkill != value)
                {
                    _currentSkillTreeStageSkill = value;
                    RaisePropertyChanged();
                }
            }
        }
        public HeroSkillDefinition CurrentSkillTreeStageRequiredSkill
        {
            get => _currentSkillTreeStageRequiredSkill;
            set
            {

                if (_currentSkillTreeStageRequiredSkill != value)
                {
                    _currentSkillTreeStageRequiredSkill = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BindingList<HeroSkillTreeSkill> CurrentSkillTreeStageAlternateSkill =
            new BindingList<HeroSkillTreeSkill>();
        public HeroSkillTreeStage SkillTreeSpecializations
        {
            get => _skillTreeSpecializations;
            set
            {

                if (_skillTreeSpecializations != value)
                {
                    _skillTreeSpecializations = value;
                    RaisePropertyChanged();
                }
            }
        }


        private readonly ILogger _logger;
        private Data _data;
        private HeroSkillTreeDefinition _currentSkillTree;
        private string _skillTreeName;
        private HeroSkillTreeStage _skillTreeSpecializations;
        private int _currentSkillTreeStageLevel;
        private HeroSkillDefinition _currentSkillTreeStageSkill;
        private HeroSkillDefinition _currentSkillTreeStageRequiredSkill;
        private Prerequisite[] _currentSkillTreeStageItems;
        private HeroSkillTreeStage _currentSkillTreeStage;

        public SkillTreeViewModel(ILogger Logger, Data data)
        {
            Logger.Info($"{MethodBase.GetCurrentMethod().Name}");
            _logger = Logger;
            _data = data;
            SkillTrees = _data.HeroSkillTreeDefinitions;
            Skills = _data.HeroSkillDefinitions;

            var tmp = SkillTrees.FirstOrDefault();

        }

        private void saveSkillTree()
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");

        }

        private void loadSkillTree(object obj)
        {
            _logger.Info($"{MethodBase.GetCurrentMethod().Name}");

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
