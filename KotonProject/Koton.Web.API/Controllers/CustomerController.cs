using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ITokenService _tokenService;
        public CustomerController(ICustomerService customerService, ITokenService tokenService)
        {
            _customerService = customerService;
            _tokenService = tokenService;
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
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<LoginModelDto> Login (LoginModelDto loginModelDto)
        {
            var isSuccesed = await _customerService.Login(loginModelDto);
            if (isSuccesed)
            {
                var token = _tokenService.CreateToken();
                loginModelDto.Token = token;
                loginModelDto.IsLogged = true;
            }
            else
                loginModelDto.IsLogged = false;    
           
            
            return loginModelDto;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<Customer> Register(CustomerDto customerDto)
        {
            var customer = await _customerService.AddCustomer(customerDto);
            return customer;
        }
    }
}
