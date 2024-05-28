using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.DAL.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly KotonDbContext _dbContext;
       
        public ProductRepository(KotonDbContext kotonDbContext) : base(kotonDbContext)
        {
            _dbContext = kotonDbContext;           
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
        //public async Task<Products> AddAsync()
        //{
        //    return await _dbContext.Product.AddAsync();
        //}
        public async Task<Product> AddAsync(Product product)
        {
            var result = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}