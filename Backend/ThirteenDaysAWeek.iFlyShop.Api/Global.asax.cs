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
        protected void Application_Start()
        {
            ConfigureAppInsights();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = CreateContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
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
