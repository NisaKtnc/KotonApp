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

        }
    }
}
