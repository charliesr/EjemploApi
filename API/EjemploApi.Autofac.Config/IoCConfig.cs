using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Autofac.Config
{
    public class IoCConfig
    {
        public static IContainer Build(Assembly apiAssembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(apiAssembly); // Coje solo las clases que acaban em controller..

            builder.RegisterModule(new UsuarioBlModule());

            builder.RegisterModule(new RedisModule());

            return builder.Build();
        }
    }
}
