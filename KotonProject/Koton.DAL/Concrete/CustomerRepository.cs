using Koton.DAL.Abstract;
using Koton.DAL.Extensions;
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

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var response = await _dbSet.Include(x=> x.CustomerRoles).ThenInclude(x=> x.Role).FirstOrDefaultAsync(x => x.CustomerEmail == email);
            return response;
        }

        public async Task<Customer>LoginAsync(string email,string password)
        {
            var response= await _dbSet.FirstOrDefaultAsync(x => x.CustomerEmail == email &&x.CustomerPassword==password);
            return response;
        }
    }
    
}
