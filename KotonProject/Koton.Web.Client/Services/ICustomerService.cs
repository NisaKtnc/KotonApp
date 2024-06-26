﻿using Koton.Business.DTO_s;
using Koton.Entities.Models;

namespace Koton.Web.Client.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Entities.Models.Customer> GetCustomerById(int Id);
        Task<Customer> AddCustomer(CustomerDto customerDto);
        Task<Entities.Models.Customer> DeleteCustomerById(int Id);
        Task<Customer> UpdateCustomer(CustomerDto customerDto);
        Task<LoginModelDto> LoginAsync (LoginModelDto loginModel);
        Task<bool> CustomerIsInRole(string role);
    }
}
