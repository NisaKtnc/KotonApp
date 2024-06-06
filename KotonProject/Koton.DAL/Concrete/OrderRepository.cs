using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.DAL.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(KotonDbContext kotonDbContext, KotonDbContext context) : base(kotonDbContext)
        {
            _context = context;
            _dbSet = _context.Set<Order>(); 
        }   
    }
}
