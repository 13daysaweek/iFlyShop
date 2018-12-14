using Autofac;
using Autofac.Integration.WebApi;
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
        }
    }
}