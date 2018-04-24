using Autofac;
using EjemploApi.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Autofac.Config
{
    public class UsuarioBlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UsuarioBlAsync>()
                .As<IUsuarioBlAsync>()
                .InstancePerRequest();
            base.Load(builder);
        }
    }
}
