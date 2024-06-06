using Koton.Business.DTO_s;
using Koton.Entities.Models;

namespace Koton.Web.Client.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Entities.Models.Product> GetProductById(int Id);
        Task<Product> AddProduct(ProductDto productDto);
        Task<Entities.Models.Product> DeleteProductById(int Id);
        Task<Product> UpdateProduct(ProductDto productDto);
    }
}
