using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroPoliticsDefinition : IHeroPoliticsDefinition, ES2XMLClass
    {
        public string NamespaceSchema { get; set; }
        public string Name { get; set; }
        public string Politics { get; set; }
        public ISimulationDescriptor ISimulationDescriptorReference { get; set; }

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
