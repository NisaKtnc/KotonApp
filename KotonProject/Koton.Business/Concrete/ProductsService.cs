using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Business.DTO_s;
using AutoMapper;

namespace Koton.Business.Concrete
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductsService(IMapper mapper,IProductRepository productRepository)
        {
            this._productRepository = productRepository; 
            this._mapper = mapper;
        }      
        public async Task<Product> AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);                      
            await _productRepository.AddAsync(product);

            return product;
        }
        public async Task<IEnumerable<Entities.Models.Product>> GetAllProductsAsync()
        {

            return await _productRepository.GetAllAsync(c=> c.Files);
        }
        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetByIdAsync(Id,c=> c.Files);
        }
        public async Task<Product> DeleteProductById (int Id)
        {
           var product =  await _productRepository.GetByIdAsync(Id); // id ile ilgili kaydı getir.
           if (product == null)
                throw new Exception("Product is not found"); // kayıt dönmüyorsa uyarı var çünkü yok zaten.
           
           await _productRepository.DeleteAsync(product); // buraya geldiyse kod, demek ki kayıt var ve silebiliriz.
           return product; // en son da sildiğimiz kaydı dönüyoruz.
        }
        public async Task<Product> UpdateProduct (ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
            return product;

        }
    }
}
