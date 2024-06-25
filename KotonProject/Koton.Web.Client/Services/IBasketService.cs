using Koton.Business.DTO_s;

namespace Koton.Web.Client.Services
{
    public interface IBasketService
    {
        Task<bool> AddBasket(int productId);
        Task<bool> DeleteBasketById(int productId);
        Task<BasketDto> GetBasket();
    }
}
