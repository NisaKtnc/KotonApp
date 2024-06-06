using Koton.Business.Abstract;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;


namespace Koton.Web.Client.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        { 
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            var allProducts = await _productService.GetAllProductsAsync();

            return View(allProducts);
        }
        public async Task<IActionResult> AddProduct()
        {
            var allProducts = await _productService.GetAllProductsAsync();

            return View(allProducts);
        }

    }
}











