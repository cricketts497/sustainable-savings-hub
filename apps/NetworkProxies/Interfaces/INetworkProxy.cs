using NetworkProxies.Models;

namespace NetworkProxies.Interfaces
{
    public interface INetworkProxy
    {
        public Task<OpenBankingPcaRoot> GetProductsAsync();
    }
}
