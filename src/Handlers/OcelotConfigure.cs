using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_api_main.src.Handlers
{
    /// <summary>
    /// Ocelot configuration handler to add API key to outgoing requests.
    /// </summary>
    public class OcelotConfigure : DelegatingHandler
    {
        // Configuration instance to access app settings
        private readonly IConfiguration _config;
        // Constructor to initialize configuration
        public OcelotConfigure(IConfiguration config)
        {
            _config = config;
        }
        /// <summary>
        /// Override SendAsync to add API key header to outgoing requests.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Retrieve API key from configuration
            var apiKey = _config["API_KEY"];
            // Add API key to request headers if it exists
            if (!string.IsNullOrEmpty(apiKey))
            {   
                // Remove existing header if present
                if (request.Headers.Contains("x-api-key")) request.Headers.Remove("x-api-key");
                // Add the API key header
                request.Headers.Add("x-api-key", apiKey);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}