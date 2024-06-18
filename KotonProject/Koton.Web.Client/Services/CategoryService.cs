using Koton.Entities.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;     
        public const string apiName = "kotonWebApi";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Category/GetAllCategories")).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>(result, options);
        }
    }
}
