using System.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.ApplicationInsights.Extensibility;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["iKey"];
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
    }
}
