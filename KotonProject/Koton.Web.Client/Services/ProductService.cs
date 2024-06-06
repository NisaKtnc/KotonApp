using AutoMapper;
using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions() {PropertyNameCaseInsensitive = true };

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

        public async Task<Product> AddProduct(ProductDto productDto)
        {
            return null;
        }

        public Task<Product> DeleteProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync("Products/GetAllProducts")).Content;

            var result = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(result, options);

        }

        public Task<Product> GetProductById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
