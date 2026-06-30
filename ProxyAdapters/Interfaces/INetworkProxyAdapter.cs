using DomainModels;

namespace ProxyAdapters.Interfaces
{
    public interface INetworkProxyAdapter
    {
        public Task<BankProduct> GetProductsAsync();
    }
}
