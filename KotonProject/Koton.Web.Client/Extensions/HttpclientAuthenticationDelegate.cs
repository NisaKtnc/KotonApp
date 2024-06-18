using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Koton.Web.Client.Extensions
{
    public class HttpClientAuthenticationDelegate
    : DelegatingHandler
    {
        private readonly IMemoryCache _memoryCache;
        public HttpClientAuthenticationDelegate(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _ = _memoryCache.TryGetValue<string>("KotonWebApiToken", out string token);
            if (token != null)
            {
                request.Headers.Add("Authorization", $"Bearer {token}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
