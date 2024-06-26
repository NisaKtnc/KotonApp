using Koton.Entities.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Koton.DAL.Abstract
{
    public interface IRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync2(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync2(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> AddAsync(T entity);
        Task AddBulkAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task BulkDeleteAsync(IEnumerable<T> entity);
       
    }
}
