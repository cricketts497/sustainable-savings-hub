using NetworkProxies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NetworkProxies.Internal.Utilities
{
    internal static class ProductPayloadParser
    {
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true
        };

        public static OpenBankingPcaRoot Parse(string rawResponse)
        {
            // Step 1: Strip out the infrastructure wrapper if present
            var wrapper = JsonSerializer.Deserialize<OpenBankingApiWrapper>(rawResponse);

            // Step 2: Extract and parse the true, generic Open Banking JSON body
            string standardizedJsonString = wrapper?.Body ?? rawResponse;

            return JsonSerializer.Deserialize<OpenBankingPcaRoot>(standardizedJsonString, _jsonSerializerOptions)!;
        }
    }
}
