using Koton.DAL.Abstract;
using Koton.DAL.Extensions;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Koton.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly KotonDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(KotonDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            return await _dbSet.IncludeMultiple(includes).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync2(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _dbSet.IncludeMultiple2(include).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            return await _dbSet.AsNoTracking().IncludeMultiple(includes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync2(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            return await _dbSet.AsNoTracking().IncludeMultiple2(include).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> AddAsync(T entity)
        {
            T result = entity;

            if(entity.Id != default)
            _context.Entry(entity).State = EntityState.Modified;         
            else
            result = (await _dbSet.AddAsync(entity)).Entity;

            await _context.SaveChangesAsync();

            return result;
        }
        public async Task AddBulkAsync(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task BulkDeleteAsync(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            await _context.SaveChangesAsync();
        }
    }


}
