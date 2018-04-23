using Autofac;
using EjemploApi.DataAccess.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.Autofac.Config
{
    public class CommonBuilder : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(RedisDaoAsync<>))
                .As(typeof(IGetAsync<>))
                .As(typeof(ISetAsync<>))
                .InstancePerRequest();


            base.Load(builder);
        }

    }
}
