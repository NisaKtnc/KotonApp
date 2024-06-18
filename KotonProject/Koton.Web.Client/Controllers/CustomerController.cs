using Koton.Business.DTO_s;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Koton.Web.Client.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMemoryCache _memoryCache;
        public CustomerController(ICustomerService customerService,IMemoryCache memoryCache)
        {
            _customerService = customerService;
            _memoryCache = memoryCache;
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
            var customer = await _customerService.LoginAsync(loginModelDto);
            if(customer!=null && customer.IsLogged)
            {
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                    Priority = CacheItemPriority.Normal
                };
            _memoryCache.Set("KotonWebApiToken", customer.Token, cacheExpOptions);
            return RedirectToAction("Index", "Product", "");

            }
            else return View(loginModelDto);
        }
    }
}
