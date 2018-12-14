using Autofac;
using ThirteenDaysAWeek.iFlyShop.Api.Data;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContextFactory>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}