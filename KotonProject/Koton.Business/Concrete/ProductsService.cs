using Koton.Business.Abstract;
using Koton.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Koton.Entities.Models;
using Koton.DAL.Concrete;
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

            return await _productRepository.GetAllAsync();

        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetByIdAsync(Id);
        }
    }
}
