using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Autofac.Configuration
{
    public static class IoCConfiguration
    {
        public static IContainer Build(Assembly assembly, ViewRegistrationSource viewRegistrationSource)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(assembly);
            builder.RegisterFilterProvider();
            builder.RegisterSource(viewRegistrationSource);
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new HttpClientModule());
            return builder.Build();
        }
    }
}
