using Castle.Core.Logging;
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
    public class EndlessSpace2ViewModel : IEndlessSpace2ViewModel
    {
        //Public View Models
        public IMainViewModel MainViewModel { get; set; }
        public IWorkshopViewModel WorkshopViewModel { get; set; }
        public IHeroViewModel HeroViewModel { get; set; }
        public ISkillViewModel SkillViewModel { get; set; }
        public ISkillTreeViewModel SkillTreeViewModel { get; set; }
        public IQuestViewModel QuestViewModel { get; set; }
        public IPlanetViewModel PlanetViewModel { get; set; }
        public ITechViewModel TechViewModel { get; set; }
        public ITraitViewModel TraitViewModel { get; set; }
        public IMinorFactionViewModel MinorFactionViewModel { get; set; }
        public IMajorFactionViewModel MajorFactionViewModel { get; set; }
        public IGovernmentViewModel GovernmentViewModel { get; set; }
        public ILawViewModel LawViewModel { get; set; }
        public ISystemImprovementViewModel SystemImprovementViewModel { get; set; }

        public bool Tab_Government = false;
        public bool Tab_Hero = false;
        public bool Tab_Law = false;
        public bool Tab_Minor_Faction = false;
        public bool Tab_Major_Faction = false;
        public bool Tab_Planet = false;
        public bool Tab_Quest = false;
        public bool Tab_Skill = false;
        public bool Tab_Skill_Tree = false;
        public bool Tab_System_Improvement = false;
        public bool Tab_Tech = false;
        public bool Tab_Trait = false;
        public bool Tab_Workshop = false;

        //Fields
        private readonly ILogger _logger;

        public EndlessSpace2ViewModel(
            IMainViewModel mainViewModel,
            IWorkshopViewModel workshopViewModel,
            IHeroViewModel heroViewModel,
            ISkillViewModel skillViewModel,
            ISkillTreeViewModel skillTreeViewModel,
            IQuestViewModel questViewModel,
            IPlanetViewModel planetViewModel,
            ITechViewModel techViewModel,
            ITraitViewModel traitViewModel,
            IMinorFactionViewModel minorFactionViewModel,
            IMajorFactionViewModel majorFactionViewModel,
            IGovernmentViewModel governmentViewModel,
            ILawViewModel lawViewModel,
            ISystemImprovementViewModel systemImprovementViewModel)
        {
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
