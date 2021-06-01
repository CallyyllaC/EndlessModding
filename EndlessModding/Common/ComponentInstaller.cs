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
			container.Register(Component.For<IMainWindowViewModel>().ImplementedBy<MainWindowViewModel>());
			container.Register(Component.For<IEndlessSpace2ViewModel>().ImplementedBy<EndlessSpace2ViewModel>());
			container.Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModel>());
			container.Register(Component.For<IWorkshopViewModel>().ImplementedBy<WorkshopViewModel>());
			container.Register(Component.For<IHeroViewModel>().ImplementedBy<HeroViewModel>());
			container.Register(Component.For<ISkillViewModel>().ImplementedBy<SkillViewModel>());
			container.Register(Component.For<ISkillTreeViewModel>().ImplementedBy<SkillTreeViewModel>());
			container.Register(Component.For<IQuestViewModel>().ImplementedBy<QuestViewModel>());
			container.Register(Component.For<IPlanetViewModel>().ImplementedBy<PlanetViewModel>());
			container.Register(Component.For<ITechViewModel>().ImplementedBy<TechViewModel>());
			container.Register(Component.For<ITraitViewModel>().ImplementedBy<TraitViewModel>());
			container.Register(Component.For<IMinorFactionViewModel>().ImplementedBy<MinorFactionViewModel>());
			container.Register(Component.For<IMajorFactionViewModel>().ImplementedBy<MajorFactionViewModel>());
			container.Register(Component.For<IGovernmentViewModel>().ImplementedBy<GovernmentViewModel>());
			container.Register(Component.For<ILawViewModel>().ImplementedBy<LawViewModel>());
			container.Register(Component.For<ISystemImprovementViewModel>().ImplementedBy<SystemImprovementViewModel>());
	}
}
}
