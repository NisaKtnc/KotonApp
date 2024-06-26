using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.Client.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders);
        }
        public async Task<IActionResult> GetOrderById(int Id)
        {
            var order = await _orderService.GetOrderById(Id);
            return View("OrderDetail",order);
        }

    }
}
