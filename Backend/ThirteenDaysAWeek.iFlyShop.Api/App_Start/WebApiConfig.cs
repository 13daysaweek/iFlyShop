using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using FluentValidation.WebApi;
using Newtonsoft.Json.Serialization;
using ThirteenDaysAWeek.iFlyShop.Api.Configuration;

namespace ThirteenDaysAWeek.iFlyShop.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FluentValidationModelValidatorProvider.Configure(config);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            var appConfig = WebApiApplication.AppContainer.Resolve<IAppConfiguration>();

            var cors = new EnableCorsAttribute(appConfig.CorsAllowedHosts, appConfig.CorsAllowedHeaders,
                appConfig.CorsAllowedMethods);
            config.EnableCors(cors);
        }
    }
}
