using Koton.Entities.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Koton.Web.Client.Extensions;

namespace Koton.Web.Client.Services
{
    public class ColorService : IColorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";
        public ColorService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Color>> GetAllColorAsync()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Color/GetAllColors")).Content;

            var result = await content.ReadAsStreamAsync();
            return await result.DeserializeCustom<IEnumerable<Color>>();
        }
    }
}
