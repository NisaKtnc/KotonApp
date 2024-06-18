using System.Text.Json;

namespace Koton.Web.Client.Extensions
{
    public class HttpExtensions : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken token)
        {
            if (request.RequestUri.Scheme == "https")
                request.RequestUri = new Uri(
                     request.RequestUri.OriginalString.Replace("https:", "http:"));

            return base.SendAsync(request, token);
        }
    }

    public static class DeserializeExtensions
    {
        // set this up how you need to!
        private static JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

      
        public static async Task<T> DeserializeCustom<T>(this Stream stream)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, options);
        }

    }
}
