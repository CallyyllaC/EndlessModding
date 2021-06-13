using EndlessModding.EndlessSpace2.Common.Interfaces;
using System.Collections.Generic;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroDefinition : IHeroDefinition, ES2XMLClass
    {
        public string NamespaceSchema { get; set; }
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public List<IHeroSkillDefinition> Skills { get; set; }
        public IHeroAffinityDefinition Affinity { get; set; }
        public IHeroClassDefinition Class { get; set; }
        public IHeroPoliticsDefinition Politics { get; set; }
        public IShipDesignDefinition ShipDesign { get; set; }
        public List<IHeroSkillTreeDefinition> SkillTrees { get; set; }
        public ILevelUpRuleDefinitions levelUpRule { get; set; }

        #region XML Generic
        public string RawXMLInner { get; }

        public string RawXMLOuter { get; }

        public bool Custom { get; set; }

        public object Get()
        {
            return new object();
        }
        #endregion
    }
}
