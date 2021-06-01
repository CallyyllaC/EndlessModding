using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessModding.EndlessSpace2.Common.Interfaces
{
    /*
     *<Datatable xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xsi:noNamespaceSchemaLocation="../Schemas/Amplitude.Unity.Simulation.SimulationDescriptor.xsd">
     *
     *  <SimulationDescriptor Name="HeroAffinityVaulters"             Type="HeroAffinity"/>
     *
     *  <SimulationDescriptor Name="HeroAffinitySistersOfMercy"       Type="HeroAffinity"/>
     *
     *  <SimulationDescriptor Name="HeroSkill_HeroOpbot"             Type="HeroSkill" IsSerializable="false"/>
     *
     *</Datatable>
     */
    class ISimulationDescriptor
    {
        string NamespaceSchema { get; set; }
        string Name { get; set; }
        string Type { get; set; } //HeroAffinity, HeroSkill etc.
    }
}
