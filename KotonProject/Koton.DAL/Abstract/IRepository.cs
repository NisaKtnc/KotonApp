﻿using Koton.Entities.Models;


namespace Koton.DAL.Abstract
{
    public interface IRepository<T> where T : BaseEntity, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
