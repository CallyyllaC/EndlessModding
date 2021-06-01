using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*
     * <Datatable xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xsi:noNamespaceSchemaLocation="../Schemas/HeroDefinition.xsd">
     *
     *      <!-- Vaulters -->
     *      <HeroDefinition Name="HeroVaulters01">
     *          <Skill Name="HeroSkill01Vaulters01"/>
     *          <Skill Name="HeroSkill02Vaulters01"/>
     *
     *          <Affinity Name="HeroAffinityVaulters"/>
     *          <Class Name="HeroClassAdministrator"/>
     *          <Politics Name="HeroPolitics02"/>
     *
     *          <ShipDesign Name="ShipDesignHeroSmall04Defender"/>
     *
     *          <SkillTree Name="HeroSkillTreeGeneric"/>
     *          <SkillTree Name="HeroSkillTreeVaulters"/>
     *          <SkillTree Name="HeroSkillTreeAdministrator"/>
     *          <LevelUpRuleReference Name="HeroLevelUpRule"/>
     *      </HeroDefinition>
     *
     *      <!-- MINOR FACTIONS -->
     *      <HeroDefinition Name="HeroSistersOfMercy01">
     *      <Skill Name="HeroSkill01SistersOfMercy01"/>
     *      <Skill Name="HeroSkill02SistersOfMercy01"/>
     *
     *      <Affinity Name="HeroAffinityPrimitives"/>
     *      <Class Name="HeroClassCorporate"/>
     *      <Politics Name="HeroPolitics03"/>
     *
     *      <ShipDesign Name="ShipDesignHeroSmall03Supporter"/>
     *
     *      <SkillTree Name="HeroSkillTreeGeneric"/>
     *      <SkillTree Name="HeroSkillTreeMinorFaction04"/>
     *      <SkillTree Name="HeroSkillTreeCorporate"/>
     *      <LevelUpRuleReference Name="HeroLevelUpRule"/>
     *      </HeroDefinition>
     *
     *      <!--PIRATE LEADER HERO-->
     *      <HeroDefinition Name="HeroPirateLeader01" Hidden="true" IgnoreInstanceNumber="true">
     *          <Skill Name="HeroSkill01PirateLeader01"/>
     *          <Skill Name="HeroSkill02PirateLeader01"/>
     *
     *          <Affinity Name="HeroAffinityPirates"/>
     *          <Class Name="HeroClassAdmiral"/>
     *          <Politics Name="HeroPolitics06"/>
     *
     *          <ShipDesign Name="ShipDesignHeroSmall01AttackerPirate"/>
     *
     *          <SkillTree Name="HeroSkillTreeGeneric"/>
     *          <SkillTree Name="HeroSkillTreeMinorFaction01"/>
     *          <SkillTree Name="HeroSkillTreeAdmiral"/>
     *          <LevelUpRuleReference Name="HeroLevelUpRule"/>
     *      </HeroDefinition>
     *
     *  </Datatable>
     */
    interface IHeroDefinition
    {
        string NamespaceSchema { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IHeroDefinition"/> is hidden.
        /// </summary>
        bool Hidden { get; set; }
        /// <summary>
        /// The hero skills
        /// </summary>
        List<IHeroSkillDefinition2> Skills {get; set;}
        /// <summary>
        /// Gets or sets the faction affinity.
        /// </summary>
        IHeroAffinityDefinition Affinity { get; set; }
        /// <summary>
        /// Gets or sets the hero class.
        /// </summary>
        IHeroClassDefinition Class { get; set; }
        /// <summary>
        /// Gets or sets the heros political party.
        /// </summary>
        IHeroPoliticsDefinition Politics { get; set; }
        /// <summary>
        /// Gets or sets the heros ship design.
        /// </summary>
        IShipDesignDefinition ShipDesign { get; set; }
        /// <summary>
        /// Gets or sets the hero skill trees.
        /// </summary>
        List<IHeroSkillTreeDefinition> SkillTrees { get; set; }
        /// <summary>
        /// Gets or sets the level up rule. (basically just the max level)
        /// </summary>
        ILevelUpRuleDefinitions levelUpRule { get; set; }

    }
}
