using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NetworkProxies.Interfaces;

namespace SustainableSavingsHub.BackendFunctions
{
    public class NatwestAccountsFunction(ILogger<NatwestAccountsFunction> logger, INetworkProxy natwestProxy)
    {
        [Function("GetNatwestPersonalCurrentAccounts")]
        public async Task<IActionResult> GetNatwestPersonalCurrentAccounts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "natwest/personal-current-accounts")] HttpRequest req)
        {
            logger.LogInformation("Fetching NatWest personal current accounts via network proxy");

            try
            {
                var responseBody = await natwestProxy.GetProductsAsync();

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
