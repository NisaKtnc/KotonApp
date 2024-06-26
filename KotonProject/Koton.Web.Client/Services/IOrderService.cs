using Koton.Entities.Models;

namespace Koton.Web.Client.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int Id);
    }
}
