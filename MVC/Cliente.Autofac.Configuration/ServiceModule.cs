using Autofac;
using Cliente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Autofac.Configuration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UsuarioService>()
                .As<IUsuarioService>()
                .InstancePerRequest();

            base.Load(builder); 
        }
    }
}
