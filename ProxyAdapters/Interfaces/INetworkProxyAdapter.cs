using DomainModels;

namespace ProxyAdapters.Interfaces
{
    public interface INetworkProxyAdapter
    {
        public Task<IEnumerable<BankProduct>> GetProductsAsync();
    }
}
