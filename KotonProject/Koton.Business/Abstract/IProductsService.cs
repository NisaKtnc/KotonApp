using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koton.DAL.Concrete;
using Koton.Business.DTO_s;


namespace Koton.Business.Abstract
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Entities.Models.Product> GetProductById(int Id);
        Task<Product> AddProduct(ProductDto productDto);

    }
}
