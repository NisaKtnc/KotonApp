using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.Business.Model;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly SharedIdentity _sharedIdentity;
        private readonly IProductsService _productsService;
        public BasketService(IMemoryCache memoryCache, SharedIdentity sharedIdentity, IProductsService productsService)
        {
            _memoryCache = memoryCache;
            _sharedIdentity = sharedIdentity;
            _productsService = productsService;
        }

        public async Task<bool> AddBasket(int productId)
        {
            var userEmail = _sharedIdentity.Email;
            var basket = GetBasket(userEmail);
 
            var product = await _productsService.GetProductById(productId);

            var basketItem = new BasketItemModel { Price = product.ProductPrice, ProductName = product.ProductName,Content = product.Files?.FirstOrDefault()?.Content };

            if (!basket.BasketItems.Any())
            {           
                basket.BasketItems.Add(basketItem);
            }
            else
            {
                if (!basket.BasketItems.Any(x => x.ProductId == productId))
                {
                    basket.BasketItems.Add(basketItem);
                }
                else
                {
                    foreach (var item in basket.BasketItems)
                    {
                        if(item.ProductId == productId)
                            item.Count++;
                    }
                }

            }
            _memoryCache.Set<BasketDto>(userEmail, basket);
            return true;
        }

        public Task<bool> DeleteBasketById(int productId)
        {
            var userEmail = _sharedIdentity.Email;
            var basket = GetBasket(userEmail);

            if (basket.BasketItems.Any())
            {
                var product = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                basket.BasketItems.Remove(product);
                _memoryCache.Set(userEmail, basket);
            }


            return Task.FromResult(true);

        }

        public BasketDto GetBasket(string email)
        {
            var result = _memoryCache.TryGetValue<BasketDto>(email, out var basketData);
            return result ? basketData : new BasketDto();
        }
    }
}
