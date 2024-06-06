using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("GetAllOrders")]
        public async Task<IEnumerable<Koton.Entities.Models.Order>> GetAllOrders()
        {
            var get = await _orderService.GetAllOrdersAsync();
            return get;
        }
        [HttpGet("GetById")]
        public async Task<Koton.Entities.Models.Order> GetById(int Id)
        {
            var get = await _orderService.GetOrderById(Id);
            return get;
        }
        [HttpPost("AddOrder")]
        public async Task<Koton.Entities.Models.Order> AddOrder(OrderDto orderDto)
        {
            return await _orderService.AddOrder(orderDto);
        }
        [HttpPost("DeleteById")]
        public async Task<Koton.Entities.Models.Order> DeleteOrderById(int Id)
        {
            return await _orderService.DeleteOrderById(Id);
        }
        [HttpPut("UpdateOrder")]
        public async Task<Koton.Entities.Models.Order> UpdateOrder(OrderDto orderDto)
        {
            var updt = await _orderService.UpdateOrder(orderDto);
            return updt;
        }
    }
}
