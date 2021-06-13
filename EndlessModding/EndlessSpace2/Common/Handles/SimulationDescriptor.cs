using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class SimulationDescriptor : ISimulationDescriptor, ES2XMLClass
    {
        public string NamespaceSchema { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

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
