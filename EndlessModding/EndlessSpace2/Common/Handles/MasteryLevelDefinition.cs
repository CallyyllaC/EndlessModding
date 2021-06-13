using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class MasteryLevelDefinition : IMasteryLevelDefinition, ES2XMLClass
    {
        public string HeroMasteryDefinition { get; set; }
        public int Levels { get; set; }

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
