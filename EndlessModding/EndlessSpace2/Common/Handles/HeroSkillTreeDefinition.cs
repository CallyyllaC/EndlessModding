using EndlessModding.EndlessSpace2.Common.Interfaces;
using System.Collections.Generic;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroSkillTreeDefinition : IHeroSkillTreeDefinition, ES2XMLClass
    {
        public string NamespaceSchema { get; set; }
        public string Name { get; set; }
        public List<IStage> Stages { get; set; }

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
    class Stage : IStage, ES2XMLClass
    {
        public int Level { get; set; }
        public List<IHeroSkillTreeSkillDefinition> Skills { get; set; }

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
    class HeroSkillTreeSkillDefinition : IHeroSkillTreeSkillDefinition, ES2XMLClass
    {
        public IHeroSkillDefinition SkillDefinition { get; set; }
        public List<IHeroSkillDefinition> RequiredSkill { get; set; }

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