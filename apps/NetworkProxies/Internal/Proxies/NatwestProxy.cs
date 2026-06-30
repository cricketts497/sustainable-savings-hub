using NetworkProxies.Interfaces;
using NetworkProxies.Internal.Utilities;
using NetworkProxies.Models;

namespace NetworkProxies.Internal.Proxies
{
    internal class NatwestProxy(HttpClient client)
        : INetworkProxy
    {
        private const string NatwestEndpoint = "https://openapi.natwest.com/open-banking/v2.2/personal-current-accounts";

        public async Task<OpenBankingPcaRoot> GetProductsAsync()
        {
            using var response = await client.GetAsync(NatwestEndpoint);
            var json = await response.Content.ReadAsStringAsync();
            return ProductPayloadParser.Parse(json);
        }
    }
}
