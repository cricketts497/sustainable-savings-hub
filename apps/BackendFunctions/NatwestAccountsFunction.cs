using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SustainableSavingsHub.BackendFunctions
{
    public class NatwestAccountsFunction(ILogger<NatwestAccountsFunction> logger, IHttpClientFactory httpClientFactory)
    {
        private const string NatwestEndpoint = "https://openapi.natwest.com/open-banking/v2.2/personal-current-accounts";

        [Function("GetNatwestPersonalCurrentAccounts")]
        public async Task<IActionResult> GetNatwestPersonalCurrentAccounts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "natwest/personal-current-accounts")] HttpRequest req)
        {
            logger.LogInformation("Fetching NatWest personal current accounts from {Endpoint}", NatwestEndpoint);

            using var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                using var response = await client.GetAsync(NatwestEndpoint);
                var responseBody = await response.Content.ReadAsStringAsync();

                logger.LogInformation(
                    "NatWest personal current accounts response status: {StatusCode}. Body: {ResponseBody}",
                    response.StatusCode,
                    responseBody);

                if (response.IsSuccessStatusCode)
                {
                    return new OkObjectResult(new
                    {
                        status = response.StatusCode.ToString(),
                        body = responseBody
                    });
                }

                return new ObjectResult(new
                {
                    status = response.StatusCode.ToString(),
                    body = responseBody
                })
                {
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to retrieve NatWest personal current accounts");
                return new StatusCodeResult(StatusCodes.Status502BadGateway);
            }
        }
    }
}
