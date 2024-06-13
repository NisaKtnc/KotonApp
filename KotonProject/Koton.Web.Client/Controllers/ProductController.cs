using Koton.Business.Abstract;
using Koton.Business.DTO_s;
using Koton.Entities.Models;
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


        public async Task<IActionResult> ProductInformation(int Id)
        {
            var product = await _productService.GetProductById(Id);

            return View(product);
        }

        public async Task<IActionResult> CreateOrUpdateProduct(int? Id)
        {
            Product product = null;
            if(Id.HasValue)
               product = await _productService.GetProductById(Id.Value);

            return View(product);
        }

        [HttpPost("CreateOrUpdateProduct")]
        public async Task<IActionResult> CreateOrUpdateProduct(ProductDto productDto)
        {
            var product = await _productService.AddProduct(productDto);

            return View(product);
        }
        public async Task<IActionResult> GetColor()
        {
            var color = await _productService.
        }
    }
}











