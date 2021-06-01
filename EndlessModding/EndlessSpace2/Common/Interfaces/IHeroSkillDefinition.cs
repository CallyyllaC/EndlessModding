using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*<HeroSkillDefinition Name="HeroSkill01BranchAdmiral">
     *	<Tags>ColonizedStarSystem</Tags>
	 *	<SkillLevel Name="HeroSkill01BranchAdmiral_01">
	 *		<SystemSimulationDescriptorReference Name="HeroSkillSystem71_Industry_PerPlanetFlat_1"/>
	 *		<MasteryLevel Class="HeroMasteryLabour" Levels="1"/>
	 *	</SkillLevel>
	 *	<SkillLevel Name="HeroSkill01BranchAdmiral_02">
     *		<HeroSimulationDescriptorReference Name="HeroSkillComplete"/>
     *		<SystemSimulationDescriptorReference Name="HeroSkillSystem71_Industry_PerPlanetFlat_2"/>
	 *		<MasteryLevel Class="HeroMasteryLabour" Levels="2"/>
	 * 	 </SkillLevel>
	 *</HeroSkillDefinition>
	 */
    interface IHeroSkillDefinition
    {
        string NamespaceSchema { get; set; }
        string Name { get; set; }
        string[] Tags { get; set; } //ColonizedStarSystem
        IHeroSkillLevelDefinition HeroSkillLevel { get; set; }
    }
    interface IHeroSkillLevelDefinition
    {
        string Name { get; set; }
        ISimulationDescriptor HeroSimulationDescriptor { get; set; }
        ISimulationDescriptor SenateSimulationDescriptor { get; set; }
        ISimulationDescriptor ShipSimulationDescriptor { get; set; }
        ISimulationDescriptor SystemSimulationDescriptor { get; set; }
        /// <summary>
        /// Does this skill unlock a Fortilla card
        /// </summary>
        IEncounterPlayDefinition EncounterPlay { get; set; }
        IMasteryLevelDefinition MasteryLevel { get; set; }

    }
}
