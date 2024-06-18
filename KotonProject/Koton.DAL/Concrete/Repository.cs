using Koton.DAL.Abstract;
using Koton.DAL.Extensions;
using Koton.Entities.Context;
using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            return await _dbSet.IncludeMultiple(includes).FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task AddBulkAsync(List<T> entity)
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

        //public async Task<T> LoginAsync(T entity)
        //{
        //    return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        //    return await _dbSet.FirstOrDefaultAsync();
        //}
    }


}
