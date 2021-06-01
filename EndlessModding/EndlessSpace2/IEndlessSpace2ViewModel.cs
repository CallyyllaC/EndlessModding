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
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2
{
    public interface IEndlessSpace2ViewModel : INotifyPropertyChanged
    {
        IMainViewModel MainViewModel { get; set; }
        IWorkshopViewModel WorkshopViewModel { get; set; }
        IHeroViewModel HeroViewModel { get; set; }
        ISkillViewModel SkillViewModel { get; set; }
        ISkillTreeViewModel SkillTreeViewModel { get; set; }
        IQuestViewModel QuestViewModel { get; set; }
        IPlanetViewModel PlanetViewModel { get; set; }
        ITechViewModel TechViewModel { get; set; }
        ITraitViewModel TraitViewModel { get; set; }
        IMinorFactionViewModel MinorFactionViewModel { get; set; }
        IMajorFactionViewModel MajorFactionViewModel { get; set; }
        IGovernmentViewModel GovernmentViewModel { get; set; }
        ILawViewModel LawViewModel { get; set; }
        ISystemImprovementViewModel SystemImprovementViewModel { get; set; }

        /*bool Tab_Government { get; set; }
        bool Tab_Hero { get; set; }
        bool Tab_Law { get; set; }
        bool Tab_Minor_Faction { get; set; }
        bool Tab_Major_Faction { get; set; }
        bool Tab_Planet { get; set; }
        bool Tab_Quest { get; set; }
        bool Tab_Skill { get; set; }
        bool Tab_Skill_Tree { get; set; }
        bool Tab_System_Improvement { get; set; }
        bool Tab_Tech { get; set; }
        bool Tab_Trait { get; set; }
        bool Tab_Workshop { get; set; }*/
    }
}
