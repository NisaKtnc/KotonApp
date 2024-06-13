using Koton.DAL.Abstract;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Koton.DAL.Concrete
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Color> _dbSet;

        public ColorRepository(KotonDbContext kotonDbContext) : base(kotonDbContext)
        {

        }
    }
}
