using EndlessModding.EndlessSpace2.Common.Interfaces;

namespace EndlessModding.EndlessSpace2.Common.Handles
{
    class ShipDesignDefinition : IShipDesignDefinition, ES2XMLClass
    {
        public string HullReferenceName { get; set; }
        public string ShipRoleReferenceName { get; set; }

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
