using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroAffinityDefinition : IHeroAffinityDefinition, ES2XMLClass
    {
        string IHeroAffinityDefinition.NamespaceSchema { get; set; }
        string IHeroAffinityDefinition.Affinity { get; set; }
        string IHeroAffinityDefinition.Name { get; set; }
        ISimulationDescriptor IHeroAffinityDefinition.ISimulationDescriptorReference { get; set; }

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
