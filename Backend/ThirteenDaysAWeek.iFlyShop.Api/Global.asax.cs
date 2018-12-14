using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
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
