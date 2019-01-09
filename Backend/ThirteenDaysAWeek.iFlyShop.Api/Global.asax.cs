using System.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.ApplicationInsights.Extensibility;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContainer AppContainer { get; private set; }

        protected void Application_Start()
        {
            AppContainer = CreateContainer();
            ConfigureAppInsights();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(AppContainer);
        }

        private IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyModules(typeof(WebApiApplication).Assembly);

            return containerBuilder.Build();
        }

        private void ConfigureAppInsights()
        {
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["iKey"];
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new CloudRoleNameTelemetryInitializer());
        }
    }
}
