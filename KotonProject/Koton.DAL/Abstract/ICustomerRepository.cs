using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.DAL.Abstract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Task<Customer> LoginAsync(string email, string password); 
        public Task<Customer> GetCustomerByEmail(string email);
    }
}
