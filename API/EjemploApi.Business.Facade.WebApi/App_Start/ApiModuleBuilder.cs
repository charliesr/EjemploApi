using Autofac;
using EjemploApi.Business.Facade.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EjemploApi.Business.Facade.WebApi.App_Start
{
    public class ApimoduleBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ApiController>()
                .As<UsuarioAsyncController>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}