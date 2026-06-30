using DomainModels;
using NetworkProxies.Interfaces;
using ProxyAdapters.Interfaces;

namespace ProxyAdapters.Internal
{
    internal class NetworkProxyAdapter(INetworkProxy networkProxy)
        : INetworkProxyAdapter
    {
        public async Task<BankProduct> GetProductsAsync()
        {
            var result = await networkProxy.GetProductsAsync();

            return new BankProduct();
        }
    }
}
