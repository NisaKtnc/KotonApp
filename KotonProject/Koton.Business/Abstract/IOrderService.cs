using Koton.Business.DTO_s;
using Koton.Entities.Models;

namespace Koton.Business.Abstract
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Entities.Models.Order> GetOrderById(int Id);
        Task<Order> AddOrder(OrderDto orderDto);
        Task<Entities.Models.Order> DeleteOrderById(int Id);
        Task<Order> UpdateOrder(OrderDto orderDto);
    }
}
