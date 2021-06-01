using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /// <summary>
    /// Just need the name of this, dont need to change anything about it
    /// </summary>
    interface IShipDesignDefinition
    {
        //string NamespaceSchema { get; set; }
        /// <summary>
        /// Maybe I can add custom hull references in the future, eg starting weapon setups
        /// </summary>
        string HullReferenceName { get; set; } //Hull01SmallAdmiralPirate
        string ShipRoleReferenceName { get; set; } //ShipRoleHero
    }
}
