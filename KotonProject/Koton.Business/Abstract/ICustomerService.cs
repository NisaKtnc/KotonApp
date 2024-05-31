using Koton.Business.DTO_s;
using Koton.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Entities.Models.Customer> GetCustomerById(int Id);
        Task<Customer> AddCustomer(CustomerDto customerDto);
        Task<Entities.Models.Customer> DeleteCustomerById(int Id);
        Task<Customer> UpdateCustomer(CustomerDto customerDto);
    }
}
