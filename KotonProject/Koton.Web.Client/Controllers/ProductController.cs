using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;



namespace Koton.Web.Client.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
        private readonly IColorService _colorService;
        public ProductController(IProductService productService,IColorService colorService) 
        { 
            _productService = productService;
            _colorService = colorService;
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
            var colors = await _colorService.GetAllColorAsync();
            ViewBag.Colors = colors;
            return View(product);
            
        }

        [HttpPost("CreateOrUpdateProduct")]
        public async Task<IActionResult> CreateOrUpdateProduct(ProductDto productDto)
        {
            var product = await _productService.AddProduct(productDto);

            return View(product);
        }
        [HttpGet("GetAllColors")]
        public async Task<IActionResult> GetAllColorsAsync()
        {
            var allcolors = await _colorService.GetAllColorAsync();
            return View(allcolors);
        }
        
    }
}











