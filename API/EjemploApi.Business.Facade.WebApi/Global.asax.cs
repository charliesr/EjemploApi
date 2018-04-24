using Autofac;
using Autofac.Integration.WebApi;
using EjemploApi.Autofac.Config;
using EjemploApi.Business.Facade.WebApi.App_Start;
using EjemploApi.Business.Logic;
using System.Reflection;
using System.Web.Http;

namespace EjemploApi.Business.Facade.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(
                    IoCConfig.Build(Assembly.GetExecutingAssembly()));

            GlobalConfiguration.Configure(WebApiConfig.Register);


        }
    }
}
