using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Common.Http
{
    public class NHttpClientFactory : NHttpClientFactoryBase<INHttpClient, NHttpClient>, INHttpClientFactory
    {
    }
    public class NHttpClientFactoryBase<IT, T> : INHttpClientFactory<IT, T> where T : class, IT
                                                   where IT : class
    {
        private IHost _host;
        public NHttpClientFactoryBase()
        {
            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHttpClient();
                services.AddTransient<IT, T>();
            }).UseConsoleLifetime();
            _host = builder.Build();
        }
        public IT CreateHttpClient()
        {
            using (var serviceScope = _host.Services.CreateScope())
            {
                var service = serviceScope.ServiceProvider;
                return service.GetRequiredService<IT>();
            }
        }
    }
}
