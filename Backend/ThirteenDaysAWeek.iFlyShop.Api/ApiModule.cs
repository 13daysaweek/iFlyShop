using Autofac;
using Autofac.Integration.WebApi;
using ThirteenDaysAWeek.iFlyShop.Api.Data;

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
        }
    }
}