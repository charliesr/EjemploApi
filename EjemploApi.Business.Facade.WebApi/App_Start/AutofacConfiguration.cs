using Autofac;
using EjemploApi.Business.Logic;
using EjemploApi.Autofac.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace EjemploApi.Business.Facade.WebApi.App_Start
{
    public class AutofacConfiguration
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<UsuarioBlAsync>()
                .As<IUsuarioBlAsync>()
                .InstancePerRequest();

            builder.RegisterModule(new CommonBuilder());

            

            return builder.Build();
        }
    }
}