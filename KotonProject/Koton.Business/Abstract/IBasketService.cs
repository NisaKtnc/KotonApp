using Koton.Business.DTO_s;
using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Abstract
{
    public interface IBasketService
    {
        Task<bool> AddBasket(int productId);
        BasketDto GetBasket(string email);

        Task<bool> CreateOrder(BasketDto basketDto);
        Task<bool> DeleteProductById(int productId);
    }
}
