using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*
     * <Datatable xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xsi:noNamespaceSchemaLocation="../Schemas/HeroAffinityDefinition.xsd">
     *
     *      <HeroAffinityDefinition Name="HeroAffinityVaulters" Affinity="AffinityVaulters">
     *          <SimulationDescriptorReference Name="HeroAffinityVaulters"/>
     *      </HeroAffinityDefinition>
     *
     *    <HeroAffinityDefinition Name="HeroAffinitySistersOfMercy" Affinity="AffinitySistersOfMercy">
     *      <SimulationDescriptorReference Name="HeroAffinitySistersOfMercy"/>
     *    </HeroAffinityDefinition>
     *
     *  </Datatable>
     */

    /// <summary>
    /// These define the Faction that a hero is part of eg, Minor or Major faction
    /// </summary>
    interface IHeroAffinityDefinition
    {
        string NamespaceSchema { get; set; }
        /// <summary>
        /// Should return Affinity+Faction name
        /// </summary>
        string Affinity { get; set; }
        /// <summary>
        /// Should return Hero+Affinity<see cref="Affinity"/>
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// we only need the name of this, and that should be the same as Name<see cref="Name"/>
        /// </summary>
        ISimulationDescriptor ISimulationDescriptorReference { get; set; }
    }
}
