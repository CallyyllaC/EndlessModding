using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EndlessModding.EndlessSpace2;
using EndlessModding.EndlessSpace2.Government;
using EndlessModding.EndlessSpace2.Hero;
using EndlessModding.EndlessSpace2.Law;
using EndlessModding.EndlessSpace2.Main;
using EndlessModding.EndlessSpace2.MajorFaction;
using EndlessModding.EndlessSpace2.MinorFaction;
using EndlessModding.EndlessSpace2.Planet;
using EndlessModding.EndlessSpace2.Quest;
using EndlessModding.EndlessSpace2.Skill;
using EndlessModding.EndlessSpace2.SkillTree;
using EndlessModding.EndlessSpace2.SystemImprovment;
using EndlessModding.EndlessSpace2.Tech;
using EndlessModding.EndlessSpace2.Trait;
using EndlessModding.EndlessSpace2.Workshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndlessModding.EndlessSpace2.Common.Files;
using EndlessModding.EndlessSpace2.SimulationDescriptor;

namespace EndlessModding.Common
{
	/// <summary>
	/// ComponentInstaller
	/// </summary>
	/// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
	public class ComponentInstaller : IWindsorInstaller
	{
		/// <summary>
		///   Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="store">The configuration store.</param>
		public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Data>().ImplementedBy<Data>());
			container.Register(Component.For<MainWindowViewModel>().ImplementedBy<MainWindowViewModel>());
			container.Register(Component.For<EndlessSpace2ViewModel>().ImplementedBy<EndlessSpace2ViewModel>());
			container.Register(Component.For<MainViewModel>().ImplementedBy<MainViewModel>());
			container.Register(Component.For<WorkshopViewModel>().ImplementedBy<WorkshopViewModel>());
			container.Register(Component.For<HeroViewModel>().ImplementedBy<HeroViewModel>());
			container.Register(Component.For<SkillViewModel>().ImplementedBy<SkillViewModel>());
			container.Register(Component.For<SkillTreeViewModel>().ImplementedBy<SkillTreeViewModel>());
			container.Register(Component.For<QuestViewModel>().ImplementedBy<QuestViewModel>());
			container.Register(Component.For<SimulationDescriptorViewModel>().ImplementedBy<SimulationDescriptorViewModel>());
			container.Register(Component.For<PlanetViewModel>().ImplementedBy<PlanetViewModel>());
			container.Register(Component.For<TechViewModel>().ImplementedBy<TechViewModel>());
			container.Register(Component.For<TraitViewModel>().ImplementedBy<TraitViewModel>());
			container.Register(Component.For<MinorFactionViewModel>().ImplementedBy<MinorFactionViewModel>());
			container.Register(Component.For<MajorFactionViewModel>().ImplementedBy<MajorFactionViewModel>());
			container.Register(Component.For<GovernmentViewModel>().ImplementedBy<GovernmentViewModel>());
			container.Register(Component.For<LawViewModel>().ImplementedBy<LawViewModel>());
			container.Register(Component.For<SystemImprovementViewModel>().ImplementedBy<SystemImprovementViewModel>());
	}
}
}
