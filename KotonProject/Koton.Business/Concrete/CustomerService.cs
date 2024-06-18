using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;
using Koton.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<Customer> AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public async Task<Customer> DeleteCustomerById(int Id)
        {
            var customer = await _customerRepository.GetByIdAsync(Id);
            if (customer == null)
                throw new Exception("Customer is not found");

            await _customerRepository.DeleteAsync(customer);
            return customer;            
        }

        public async Task<IEnumerable<Koton.Entities.Models.Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await _customerRepository.GetByIdAsync(Id);
        }

     

        public async Task<Customer> UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.UpdateAsync(customer);
            return customer;
        }

        public async Task<bool> Login(LoginModelDto loginModel)
        {          
           var res=await _customerRepository.LoginAsync(loginModel.Email, loginModel.Password);
           return res!=null;
        }
    }
}
