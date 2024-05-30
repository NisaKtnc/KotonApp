using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.DAL.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(KotonDbContext kotonDbContext, KotonDbContext context) : base(kotonDbContext)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }
    }
    
}
