using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Koton.Business.DTO_s;
using AutoMapper;
using Koton.Entities.Context;

namespace Koton.Business.Concrete
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IFileRepository _fileRepository;
        public ProductsService(IMapper mapper, IProductRepository productRepository, IFileRepository fileRepository)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
            _fileRepository = fileRepository;
        }
        public async Task<Product> AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);                      
            await _productRepository.AddAsync(product);

            if (product.Id != default)
            {
                var files = await _fileRepository.GetByProductId(product.Id);
                await _fileRepository.BulkDeleteAsync(files);
            }
            return product;
        }
        public async Task<IEnumerable<Entities.Models.Product>> GetAllProductsAsync()
        {

            return await _productRepository.GetAllAsync(c=> c.Files);
        }
        public async Task<IEnumerable<Entities.Models.Product>> GetAllProductsByNameAsync(string searchTerm)
        {

            return await _productRepository.GetProductsByName(searchTerm);
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
