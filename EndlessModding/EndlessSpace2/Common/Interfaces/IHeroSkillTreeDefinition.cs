using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*
     *  <HeroSkillTreeDefinition Name="HeroSkillTreeVaulters">
     *      <Stage Level="0">
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill01BranchVaulters"/>
     *          </Skill>
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill02BranchVaulters"/>
     *          </Skill>
     *      </Stage>
     *      <Stage Level="4">
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill03BranchVaulters"/>
     *          </Skill>
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill04BranchVaulters"/>
     *          </Skill>
     *      </Stage>
     *      <Stage Level="8">
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill05BranchVaulters"/>
     *          </Skill>
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill06BranchVaulters"/>
     *          </Skill>
     *      </Stage>
     *      <Stage Level="12">
     *          <Skill>
     *              <SkillDefinition Name="HeroSkill07BranchVaulters"/>
     *          </Skill>
     *      </Stage>
     *  </HeroSkillTreeDefinition>
     */
    interface IHeroSkillTreeDefinition
    {
        string NamespaceSchema { get; set; }
        string Name { get; set; }
        List<IStage> Stages { get; set; }
    }
    interface IStage
    {
        int Level { get; set; }
        List<IHeroSkillTreeSkillDefinition> Skills { get; set; }
    }
    interface IHeroSkillTreeSkillDefinition
    {
        IHeroSkillDefinition SkillDefinition { get; set; }
        List<IHeroSkillDefinition> RequiredSkill { get; set; }
    }
}