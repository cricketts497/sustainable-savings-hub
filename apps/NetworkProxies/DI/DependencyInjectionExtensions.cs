using Microsoft.Extensions.DependencyInjection;
using NetworkProxies.Interfaces;
using NetworkProxies.Internal.Proxies;

namespace NetworkProxies.DI
{
    public static class DependencyInjectionExtensions
    {
        public static void AddProxies(this IServiceCollection services)
        {
            services.AddProxy<NatwestProxy>();
        }

        private static IHttpClientBuilder AddProxy<T>(this IServiceCollection services)
            where T : class, INetworkProxy
        {
            return services.AddHttpClient<INetworkProxy, T>();
        }
    }
}
