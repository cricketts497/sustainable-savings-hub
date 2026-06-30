using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SustainableSavingsHub.BackendFunctions
{
    public class ProductsFunction(ILogger<ProductsFunction> logger)
    {
        [Function("GetProducts")]
        public IActionResult GetProducts(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
        {
            logger.LogInformation("GetProducts function called");

            var mockProducts = new[]
            {
                new { Id = 1, Name = "Eco-Saver ISA", Provider = "Green Bank", Rate = 4.50 },
                new { Id = 2, Name = "Sustained Growth Bond", Provider = "Ethical Trust", Rate = 4.85 }
            };

            return new OkObjectResult(mockProducts);
        }
    }
}
