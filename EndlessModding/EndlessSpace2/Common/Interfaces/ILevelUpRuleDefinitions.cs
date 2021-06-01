using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    interface ILevelUpRuleDefinitions
    {
        string NamespaceSchema { get; set; }
        string Name { get; set; }
        /// <summary>
        /// we only need the name of this, and that should be the same as Name<see cref="Name"/>
        /// </summary>
        ISimulationDescriptor ISimulationDescriptorReference { get; set; }
    }
}
