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
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly SharedIdentity _sharedIdentity;
        private readonly IProductsService _productsService;
        private readonly IOrderService _orderService;
        public BasketService(IMemoryCache memoryCache, SharedIdentity sharedIdentity, IProductsService productsService, IOrderService orderService)
        {
            _memoryCache = memoryCache;
            _sharedIdentity = sharedIdentity;
            _productsService = productsService;
            _orderService = orderService;
        }

        public async Task<bool> AddBasket(int productId)
        {
            var userEmail = _sharedIdentity.Email;
            var basket = GetBasket(userEmail);
 
            var product = await _productsService.GetProductById(productId);

            var basketItem = new BasketItemModel { Price = product.ProductPrice,ProductId = product.Id, ProductName = product.ProductName,Content = product.Files?.FirstOrDefault()?.Content };

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
                        {
                            item.Count++;
                            item.Price = product.ProductPrice * item.Count;
                        }
                    }
                    
                }

            }
            _memoryCache.Set<BasketDto>(userEmail, basket);
            return true;
        }

        public BasketDto GetBasket(string email)
        {
            var result = _memoryCache.TryGetValue<BasketDto>(email, out var basketData);
            return result ? basketData : new BasketDto();
        }

        public async Task<bool> CreateOrder(BasketDto basketDto)
        {
            var userEmail = _sharedIdentity.Email;
            var basket = GetBasket(userEmail);

            var orderDto = new OrderDto()
            {
                OrderNote = basketDto.OrderNote,
                OrderAddress = basketDto.OrderAddress,
                OrderTotalPrice = basket.TotalPrice,
            };
            orderDto.Basket = basket;
            await _orderService.AddOrder(orderDto);

            return await Task.FromResult(true);
        }


        public async Task<bool> DeleteProductById(int productId)
        {
            var userEmail = _sharedIdentity.Email;
            var basket = GetBasket(userEmail);

            if(basket.BasketItems.Any(x=> x.ProductId == productId))
            {
                var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                if(basketItem.Count > 1)
                {
                    var quantityPrice = basketItem.Price / basketItem.Count;
                    basketItem.Count --;
                    basketItem.Price = quantityPrice * basketItem.Count;
                }
                else
                basket.BasketItems.Remove(basketItem);
            }

            _memoryCache.Set<BasketDto>(userEmail, basket);
            return await Task.FromResult(true);
        }
    }
}
