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
			public static IMainWindowViewModel MainWindowViewModel
			{
				get;
			} = ResolveMainWindowViewModel();

			private static IMainWindowViewModel ResolveMainWindowViewModel()
			{
				Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

				try
				{
					IMainWindowViewModel mainWindowViewModel = WindsorContainer.Resolve<IMainWindowViewModel>();
					return mainWindowViewModel;
				}
				catch (Exception e)
				{
					Logger.Error($"{MethodBase.GetCurrentMethod().Name}", e);
					throw;
				}
			}

			public static IEndlessSpace2ViewModel EndlessSpace2ViewModel
			{
				get;
			} = ResolveEndlessSpace2ViewModel();

			private static IEndlessSpace2ViewModel ResolveEndlessSpace2ViewModel()
			{
				Logger.Info($"{MethodBase.GetCurrentMethod().Name}");

				try
				{
					IEndlessSpace2ViewModel EndlessSpace2ViewModel = WindsorContainer.Resolve<IEndlessSpace2ViewModel>();
					return EndlessSpace2ViewModel;
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
