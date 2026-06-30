using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ProxyAdapters.Interfaces;

namespace SustainableSavingsHub.BackendFunctions
{
    public class NatwestAccountsFunction(ILogger<NatwestAccountsFunction> logger, INetworkProxyAdapter proxyAdapter)
    {
        [Function("GetNatwestPersonalCurrentAccounts")]
        public async Task<IActionResult> GetNatwestPersonalCurrentAccounts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "natwest/personal-current-accounts")] HttpRequest req)
        {
            logger.LogInformation("Fetching NatWest personal current accounts via network proxy");

            try
            {
                var responseBody = await proxyAdapter.GetProductsAsync();

                logger.LogInformation("NatWest personal current accounts retrieved");

                return new OkObjectResult(new
                {
                    status = "OK",
                    body = responseBody
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to retrieve NatWest personal current accounts via proxy");
                return new StatusCodeResult(StatusCodes.Status502BadGateway);
            }
        }
    }
}
