using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using EndlessModding.EndlessSpace2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel;

namespace EndlessModding.Common
{
	public static class BootStrapper
	{
		/// <summary>
		/// ApplicationBootStrapper
		/// </summary>
		public static class ApplicationBootStrapper
		{

			#region Logger

			private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

			#endregion


			private static readonly IWindsorContainer WindsorContainer = BuildWindsorContainer();

			/// <summary>
			/// Gets the main window view model.
			/// </summary>
			/// <value>
			/// The main window view model.
			/// </value>
			public static MainWindowViewModel MainWindowViewModel
			{
				get;
			} = ResolveMainWindowViewModel();

			private static MainWindowViewModel ResolveMainWindowViewModel()
			{
				Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

				try
				{
					MainWindowViewModel mainWindowViewModel = WindsorContainer.Resolve<MainWindowViewModel>();
					return mainWindowViewModel;
				}
				catch (Exception e)
				{
					Logger.Error($"{MethodBase.GetCurrentMethod().Name}", e);
					throw;
				}
			}

			private static IWindsorContainer BuildWindsorContainer()
			{
				Logger.Info("");
				Logger.Info("=============================================================================================================================================");
				Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

				IWindsorContainer windsorContainer = new WindsorContainer();

				windsorContainer.AddFacility<TypedFactoryFacility>();

				windsorContainer.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithAppConfig());

				windsorContainer.Install(Configuration.FromAppConfig());
				windsorContainer.Install(FromAssembly.This());

				return windsorContainer;
			}
		}
	}

}
