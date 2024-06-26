using DocumentFormat.OpenXml.Wordprocessing;
using Koton.Business.DTO_s;
using Koton.Business.Model;
using Koton.Web.Client.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";

        public BasketService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<BasketDto> GetBasket()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Basket/GetBasket")).Content;

            var result = await content.ReadAsStreamAsync();
            return await result.DeserializeCustom<BasketDto>();
        }
        public async Task<bool> AddBasket(int productId)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var basketRequest = new BasketRequest {ProductId = productId, Count = 1 };
            var content = (await client.PostAsJsonAsync<BasketRequest>("Basket/AddBasket",basketRequest)).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<bool>(result);
        }

        public async Task<bool> DeleteBasketById(int productId)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var basketRequest = new BasketRequest { ProductId = productId, Count = 1 };
            var content = (await client.PostAsJsonAsync<BasketRequest>("Basket/DeleteProductById", basketRequest)).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<bool>(result);
        }

        public async Task<bool> CreateOrder(BasketDto basketDto)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.PostAsJsonAsync<BasketDto>("Basket/CreateOrder", basketDto)).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<bool>(result);
        }
    }
}

