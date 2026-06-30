using NetworkProxies.Interfaces;

namespace NetworkProxies.Internal
{
    internal class NatwestProxy(HttpClient client)
        : INetworkProxy
    {
        private const string NatwestEndpoint = "https://openapi.natwest.com/open-banking/v2.2/personal-current-accounts";

        public async Task<string> GetProductsAsync()
        {
            using var response = await client.GetAsync(NatwestEndpoint);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
