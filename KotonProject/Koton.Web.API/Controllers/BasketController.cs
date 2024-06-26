using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.Business.Model;
using Koton.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SharedIdentity sharedIdentity;
        public BasketController(IBasketService basketService, SharedIdentity sharedIdentity)
        {
            _basketService = basketService;
            this.sharedIdentity = sharedIdentity;
        }

        [HttpGet("GetBasket")]   
        public BasketDto GetBasket()
        {
            var basket = _basketService.GetBasket(sharedIdentity.Email);
            return basket;
        }

        [HttpPost("AddBasket")]
        public async Task<bool> AddBasket(BasketRequest basketRequest)
        {
            var basket = await _basketService.AddBasket(basketRequest.ProductId);
            return basket;
        }
        
        [HttpPost("DeleteProductById")]
        public async Task<bool> DeleteProductById(BasketRequest basketRequest)
        {
            var basket = await _basketService.DeleteProductById(basketRequest.ProductId);
            return basket;
        }

        [HttpPost("CreateOrder")]
        public async Task<bool> CreateOrder(BasketDto basketDto)
        {
            var basket = await _basketService.CreateOrder(basketDto);
            return basket;
        }

       

    }
}
