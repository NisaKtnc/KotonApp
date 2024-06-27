using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Koton.DAL.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(KotonDbContext kotonDbContext) : base(kotonDbContext)
        {
            _context = kotonDbContext;
            _dbSet = _context.Set<Product>();   
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string searchTerm)
        {

  
                var products = await _dbSet.Include(f=> f.Files).Where(fi => fi.ProductName.ToLower().Contains(searchTerm)).ToListAsync();

                return products;  
           
        }
        //bu repositorye bir şey eklemek gerekiyorsa eğer : 

        //Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);
        //Task AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);

        // bu yukarıdakilerden mantıken farklı bir amaca hizmet ediyor olması lazım. bunlar zaten productrepository içerisinde         
    }
}

