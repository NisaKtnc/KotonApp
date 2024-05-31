using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Microsoft.AspNetCore.Mvc;


namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("GetAllCustomers")]
        public async Task<IEnumerable<Koton.Entities.Models.Customer>> GetAllCustomers()
        {
            var get = await _customerService.GetAllCustomersAsync();
            return get;
        }
        [HttpGet("GetById")]
        public async Task<Koton.Entities.Models.Customer> GetById(int Id)
        {
            var get = await _customerService.GetCustomerById(Id);
            return get;
        }
        [HttpPost("AddCustomer")]
        public async Task<Koton.Entities.Models.Customer> AddCustomer(CustomerDto customerDto)
        {
            return await _customerService.AddCustomer(customerDto);
        }
        [HttpPost("DeleteCustomer")]
        public async Task<Koton.Entities.Models.Customer> DeleteCustomerById(int Id)
        {
            return await _customerService.DeleteCustomerById(Id);   
        }
        [HttpPut("UpdateCustomer")]
        public async Task<Koton.Entities.Models.Customer> UpdateCustomer(CustomerDto customerDto)
        {
            var update = await _customerService.UpdateCustomer(customerDto);
            return update;
        }  

    }
}
