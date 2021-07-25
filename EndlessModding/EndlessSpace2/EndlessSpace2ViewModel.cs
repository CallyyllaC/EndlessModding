using Castle.Core.Logging;
using EndlessModding.Common.Import;
using EndlessModding.EndlessSpace2.Government;
using EndlessModding.EndlessSpace2.Hero;
using EndlessModding.EndlessSpace2.Law;
using EndlessModding.EndlessSpace2.Main;
using EndlessModding.EndlessSpace2.MajorFaction;
using EndlessModding.EndlessSpace2.MinorFaction;
using EndlessModding.EndlessSpace2.Planet;
using EndlessModding.EndlessSpace2.Quest;
using EndlessModding.EndlessSpace2.Skill;
using EndlessModding.EndlessSpace2.SkillTree;
using EndlessModding.EndlessSpace2.SystemImprovment;
using EndlessModding.EndlessSpace2.Tech;
using EndlessModding.EndlessSpace2.Trait;
using EndlessModding.EndlessSpace2.Workshop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2
{
    public class EndlessSpace2ViewModel : INotifyPropertyChanged
    {
        //Public View Models
        public MainViewModel MainViewModel { get; set; }
        public WorkshopViewModel WorkshopViewModel { get; set; }
        public HeroViewModel HeroViewModel { get; set; }
        public SkillViewModel SkillViewModel { get; set; }
        public SkillTreeViewModel SkillTreeViewModel { get; set; }
        public QuestViewModel QuestViewModel { get; set; }
        public PlanetViewModel PlanetViewModel { get; set; }
        public TechViewModel TechViewModel { get; set; }
        public TraitViewModel TraitViewModel { get; set; }
        public MinorFactionViewModel MinorFactionViewModel { get; set; }
        public MajorFactionViewModel MajorFactionViewModel { get; set; }
        public GovernmentViewModel GovernmentViewModel { get; set; }
        public LawViewModel LawViewModel { get; set; }
        public SystemImprovementViewModel SystemImprovementViewModel { get; set; }
        public bool Tab_Government
        {
            get => tab_Government; set
            {
                tab_Government = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Hero
        {
            get => tab_Hero; set
            {
                tab_Hero = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Law
        {
            get => tab_Law; set
            {
                tab_Law = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Minor_Faction
        {
            get => tab_Minor_Faction; set
            {
                tab_Minor_Faction = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Major_Faction
        {
            get => tab_Major_Faction; set
            {
                tab_Major_Faction = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Planet
        {
            get => tab_Planet; set
            {
                tab_Planet = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Quest
        {
            get => tab_Quest; set
            {
                tab_Quest = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Skill
        {
            get => tab_Skill; set
            {
                tab_Skill = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Skill_Tree
        {
            get => tab_Skill_Tree; set
            {
                tab_Skill_Tree = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_System_Improvement
        {
            get => tab_System_Improvement; set
            {
                tab_System_Improvement = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Tech
        {
            get => tab_Tech; set
            {
                tab_Tech = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Trait
        {
            get => tab_Trait; set
            {
                tab_Trait = value;
                RaisePropertyChanged();
            }
        }
        public bool Tab_Workshop
        {
            get => tab_Workshop; set
            {
                tab_Workshop = value;
                RaisePropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;

                ToggleTabs(!value);

                RaisePropertyChanged();
            }
        }
        public bool ShouldBeEnabled
        {
            get => !IsBusy;
        }

        private bool _isBusy = false;
        private bool tab_Government = false;
        private bool tab_Hero = false;
        private bool tab_Law = false;
        private bool tab_Minor_Faction = false;
        private bool tab_Major_Faction = false;
        private bool tab_Planet = false;
        private bool tab_Quest = false;
        private bool tab_Skill = false;
        private bool tab_Skill_Tree = false;
        private bool tab_System_Improvement = false;
        private bool tab_Tech = false;
        private bool tab_Trait = false;
        private bool tab_Workshop = false;

        //Fields
        private readonly ILogger _logger;
        private Import _import;

        public EndlessSpace2ViewModel(
            Import import,
            MainViewModel mainViewModel,
            WorkshopViewModel workshopViewModel,
            HeroViewModel heroViewModel,
            SkillViewModel skillViewModel,
            SkillTreeViewModel skillTreeViewModel,
            QuestViewModel questViewModel,
            PlanetViewModel planetViewModel,
            TechViewModel techViewModel,
            TraitViewModel traitViewModel,
            MinorFactionViewModel minorFactionViewModel,
            MajorFactionViewModel majorFactionViewModel,
            GovernmentViewModel governmentViewModel,
            LawViewModel lawViewModel,
            SystemImprovementViewModel systemImprovementViewModel)
        {
            _import = import;
            MainViewModel = mainViewModel;
            WorkshopViewModel = workshopViewModel;
            HeroViewModel = heroViewModel;
            SkillViewModel = skillViewModel;
            SkillTreeViewModel = skillTreeViewModel;
            QuestViewModel = questViewModel;
            PlanetViewModel = planetViewModel;
            TechViewModel = techViewModel;
            TraitViewModel = traitViewModel;
            MinorFactionViewModel = minorFactionViewModel;
            MajorFactionViewModel = majorFactionViewModel;
            GovernmentViewModel = governmentViewModel;
            LawViewModel = lawViewModel;
            SystemImprovementViewModel = systemImprovementViewModel;

            MainViewModel.MainWindow = this;
            WorkshopViewModel.MainWindow = this;
            HeroViewModel.MainWindow = this;
            SkillViewModel.MainWindow = this;
            SkillTreeViewModel.MainWindow = this;
            QuestViewModel.MainWindow = this;
            PlanetViewModel.MainWindow = this;
            TechViewModel.MainWindow = this;
            TraitViewModel.MainWindow = this;
            MinorFactionViewModel.MainWindow = this;
            MajorFactionViewModel.MainWindow = this;
            GovernmentViewModel.MainWindow = this;
            LawViewModel.MainWindow = this;
            SystemImprovementViewModel.MainWindow = this;

            RaisePropertyChanged();
        }
        public void ToggleTabs(bool enable)
        {
            Tab_Government = enable;
            Tab_Hero = enable;
            Tab_Law = enable;
            Tab_Minor_Faction = enable;
            Tab_Major_Faction = enable;
            Tab_Planet = enable;
            Tab_Quest = enable;
            Tab_Skill = enable;
            Tab_Skill_Tree = enable;
            Tab_System_Improvement = enable;
            Tab_Tech = enable;
            Tab_Trait = enable;
            Tab_Workshop = enable;
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
