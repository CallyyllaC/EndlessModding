using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class HeroSimulationDescriptor : IHeroSimulationDescriptor, ES2XMLClass
    {

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