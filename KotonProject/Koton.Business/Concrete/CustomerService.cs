using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.DAL.Abstract;
using Koton.Entities.Models;


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
            var customer = _mapper.Map<CustomerDto>(customerDto);
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public Task<Customer> DeleteCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomer(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
