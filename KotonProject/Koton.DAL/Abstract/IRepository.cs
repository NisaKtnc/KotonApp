using Koton.Entities.Models;
using System.Linq.Expressions;


namespace Koton.DAL.Abstract
{
    public interface IRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task AddBulkAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
       
    }
}
