using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.DAL.Concrete
{
    public class OrderDetailRepository : Repository<OrderDetail> , IOrderDetailRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<OrderDetail> _dbSet;

        public OrderDetailRepository(KotonDbContext context) : base(context)
        {
            _context = context; 
            _dbSet= _context.Set<OrderDetail>();    
        }
        
    }
}
