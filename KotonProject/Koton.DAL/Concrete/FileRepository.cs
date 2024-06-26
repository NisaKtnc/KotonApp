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
    public class FileRepository : Repository<Entities.Models.File>, IFileRepository
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<Entities.Models.File> _dbSet;

        public FileRepository(KotonDbContext kotonDbContext) : base(kotonDbContext)
        {
            _context = kotonDbContext;
            _dbSet = _context.Set<Entities.Models.File>();
        }

        public async Task<IEnumerable<Entities.Models.File>> GetByProductId(int Id)
        {
            var files = await _dbSet.Where(x => x.ProductId == Id).ToListAsync();
            return files;
        }
    }
}
