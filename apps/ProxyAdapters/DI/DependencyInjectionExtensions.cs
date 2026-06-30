using Microsoft.Extensions.DependencyInjection;
using ProxyAdapters.Interfaces;
using ProxyAdapters.Internal;

namespace ProxyAdapters.DI
{
    public static class DependencyInjectionExtensions
    {
        public static void AddProxyAdapters(this IServiceCollection services)
        {
            services.AddScoped<INetworkProxyAdapter, NetworkProxyAdapter>();
        }
    }
}
