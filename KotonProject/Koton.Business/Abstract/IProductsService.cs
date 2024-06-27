using Koton.Entities.Models;
using Koton.Business.DTO_s;


namespace Koton.Business.Abstract
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Entities.Models.Product> GetProductById(int Id);
        Task<Product> AddProduct(ProductDto productDto);
        Task<Entities.Models.Product> DeleteProductById (int Id);
        Task<Product> UpdateProduct (ProductDto productDto);
        Task<IEnumerable<Entities.Models.Product>> GetAllProductsByNameAsync(string searchTerm);


    }
}
