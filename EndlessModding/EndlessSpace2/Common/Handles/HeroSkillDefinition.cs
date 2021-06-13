using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroSkillDefinition : IHeroSkillDefinition, ES2XMLClass
    {
        public string NamespaceSchema { get; set; }
        public string Name { get; set; }
        public string[] Tags { get; set; }
        public IHeroSkillLevelDefinition HeroSkillLevel { get; set; }

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
    class HeroSkillLevelDefinition : IHeroSkillLevelDefinition, ES2XMLClass
    {
        public string Name { get; set; }
        public ISimulationDescriptor HeroSimulationDescriptor { get; set; }
        public ISimulationDescriptor SenateSimulationDescriptor { get; set; }
        public ISimulationDescriptor ShipSimulationDescriptor { get; set; }
        public ISimulationDescriptor SystemSimulationDescriptor { get; set; }
        public IEncounterPlayDefinition EncounterPlay { get; set; }
        public IMasteryLevelDefinition MasteryLevel { get; set; }

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
