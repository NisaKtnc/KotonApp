using Koton.Business.DTO_s;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.Client.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModelDto loginModelDto) 
        {
            var user = await _customerService.LoginAsync(loginModelDto);
            return View(user);
        }
    }
}
