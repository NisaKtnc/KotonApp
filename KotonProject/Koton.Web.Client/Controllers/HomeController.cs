using Koton.Business.Abstract;
using Koton.Web.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koton.Web.Client.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IProductService _productService;
        //public HomeController(ILogger<HomeController> logger, IProductService productService)
        //{
        //    _logger = logger;
        //    _productService = productService;  //dependecy injection
        //}

        public IActionResult Index()
        {
            //httpclient ->   localhost4541/api/products/getallproducts;
            //httpclient
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}


        //public IActionResult ProductSave()
        //{
        //    _productService.SaveProduct();
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}