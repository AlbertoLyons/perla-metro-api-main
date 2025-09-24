using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace perla_metro_api_main.src.Handlers
{
    public class OcelotConfigure : DelegatingHandler
    {
        private readonly IConfiguration _config;

        public OcelotConfigure(IConfiguration config)
        {
            _config = config;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var apiKey = _config["API_KEY"];
            if (!string.IsNullOrEmpty(apiKey))
            {
                if (request.Headers.Contains("x-api-key"))
                    request.Headers.Remove("x-api-key");
                request.Headers.Add("x-api-key", apiKey);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}