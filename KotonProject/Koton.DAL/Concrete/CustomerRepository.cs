using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.DAL.Concrete
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Customer> _dbSet;
        public CustomerRepository(KotonDbContext kotonDbContext,KotonDbContext context) : base(kotonDbContext)
        {
            _context = context;
            _dbSet = _context.Set<Customer>();
        }
    }
    
}
