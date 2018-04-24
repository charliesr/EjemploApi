using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Cliente.Autofac.Configuration
{
    public class HttpClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<HttpClient>()
                .AsSelf()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
