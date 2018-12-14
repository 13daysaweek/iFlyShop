using System.Configuration;
using Autofac;
using Autofac.Integration.WebApi;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly);

            builder.RegisterType<ContextFactory>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ProductRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CacheAccessor>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .WithParameter((p, c) => p.Name == "cacheConnectionString",
                    (p, c) => ConfigurationManager.ConnectionStrings["cacheConnectionString"].ConnectionString);
        }
    }
}