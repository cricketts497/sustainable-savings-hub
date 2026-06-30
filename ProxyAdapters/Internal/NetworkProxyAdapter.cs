using DomainModels;
using NetworkProxies.Interfaces;
using ProxyAdapters.Interfaces;

namespace ProxyAdapters.Internal
{
    internal class NetworkProxyAdapter(INetworkProxy networkProxy)
        : INetworkProxyAdapter
    {
        public async Task<IEnumerable<BankProduct>> GetProductsAsync()
        {
            var response = await networkProxy.GetProductsAsync();

            return response.Data
                .SelectMany(brandContainer => brandContainer.Brand)
                .SelectMany(brand => brand.Pca.Select(product => new BankProduct
                {
                    Id = product.Identification,
                    ProviderId = brand.BrandName,
                    Name = product.Name,
                    Features = product.PcaMarketingState
                        .SelectMany(state => state.FeaturesAndBenefits?.FeatureBenefitItem ?? [])
                        .Select(feature => feature.Name)
                        .Where(name => !string.IsNullOrWhiteSpace(name))
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList()
                }));
        }
    }
}
