using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*
     * <HeroPoliticsDefinition Name="HeroPolitics04" Politics="Politics04">
     *     <SimulationDescriptorReference Name="Politics04"/>
     * </HeroPoliticsDefinition>
     */
    interface IHeroPoliticsDefinition
    {
        string NamespaceSchema { get; set; }
        string Name { get; set; }
        /// <summary>
        /// The default ones need naming, currently they're 01,02,03,04,05,06
        /// </summary>
        string Politics { get; set; }
        /// <summary>
        /// we only need the name of this, and that should be the same as Name<see cref="Name"/>
        /// </summary>
        ISimulationDescriptor ISimulationDescriptorReference { get; set; }
    }
}
