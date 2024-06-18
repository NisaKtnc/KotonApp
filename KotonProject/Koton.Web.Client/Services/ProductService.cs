using AutoMapper;
using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Controllers;
using Koton.Web.Client.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Koton.Web.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public const string apiName = "kotonWebApi";

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

        public async Task<Product> AddProduct(ProductDto productDto, IFormFile formFile)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.PostAsJsonAsync<ProductDto>("Products/AddProduct",productDto)).Content;

            var result = await content.ReadAsStreamAsync();
            var product = await result.DeserializeCustom<Product>();
            
            if(formFile != null)
            {
                await using var memoryStream = new MemoryStream();
                await formFile.CopyToAsync(memoryStream);

                FileDto fileDto = new ()
                {
                    ProductId = product.Id,
                    ContentType = formFile.ContentType,
                    Name = formFile.FileName,
                    Extension = System.IO.Path.GetExtension(formFile.FileName),
                    Content = memoryStream.ToArray(),
                    Description="dsadasdsa",
                    ContentPath="dsadad"

                };
                var fileContent = (await client.PostAsJsonAsync<FileDto>("File/AddFile", fileDto)).Content;

            }
            return product;

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
            return await result.DeserializeCustom<IEnumerable<Product>>();

        }

        public async Task<Product> GetProductById(int Id)
        {
            var client = _httpClientFactory.CreateClient(apiName);
            var content = (await client.GetAsync($"Products/GetById?Id={Id}")).Content;

            var result = await content.ReadAsStreamAsync();
            return await result.DeserializeCustom<Product>();
        }
    }
}
