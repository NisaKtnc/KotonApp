using Koton.Business.DTO_s;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.Client.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetBasket();
            return View(basket);
        }
        public async Task<IActionResult> AddProduct(int Id)
        {
            var basket = await _basketService.AddBasket(Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var basket = await _basketService.DeleteBasketById(Id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(BasketDto basketDto)
        {
            var basket = await _basketService.CreateOrder(basketDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
