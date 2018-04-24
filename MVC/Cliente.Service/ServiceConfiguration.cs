using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Service
{
    public static class ServiceConfiguration
    {
        public static HttpClient InitClient (HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

    }
}
