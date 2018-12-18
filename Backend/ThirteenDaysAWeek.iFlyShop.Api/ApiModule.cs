using System.Configuration;
using Autofac;
using Autofac.Integration.WebApi;
using ThirteenDaysAWeek.iFlyShop.Api.Caching;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;
using ThirteenDaysAWeek.iFlyShop.Api.Data;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using ThirteenDaysAWeek.iFlyShop.Api.Services;
using ThirteenDaysAWeek.iFlyShop.Api.Telemetry;

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
                .InstancePerRequest();

            builder.RegisterType<CacheAccessor>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .WithParameter((p, c) => p.Name == "cacheConnectionString",
                    (p, c) => ConfigurationManager.ConnectionStrings["cacheConnectionString"].ConnectionString);

            builder.RegisterType<DependencyTracker>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<TelemetryService>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .WithParameter((p, c) => p.Name == "instrumentationKey",
                    (p, c) => ConfigurationManager.AppSettings["iKey"]);

            builder.RegisterType<OrderPublisher>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<AppConfiguration>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(_ => _.Instance.Initialize());
        }
    }
}