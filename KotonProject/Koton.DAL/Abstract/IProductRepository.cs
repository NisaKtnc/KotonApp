﻿using Koton.Entities.Models;


namespace Koton.DAL.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByName(string searchTerm);   
            
    }
}
