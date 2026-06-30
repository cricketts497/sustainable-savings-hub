namespace NetworkProxies.Interfaces
{
    public interface INetworkProxy
    {
        public Task<string> GetProductsAsync();
    }
}
