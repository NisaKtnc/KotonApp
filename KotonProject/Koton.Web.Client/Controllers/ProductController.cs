using Koton.Business.DTO_s;
using Koton.Entities.Models;
using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Koton.Web.Client.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
       private readonly IColorService _colorService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, IColorService colorService, ICategoryService categoryService)
        {
            _productService = productService;
            _colorService = colorService;
            _categoryService = categoryService;
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
            ViewBag.Colors = new SelectList(colors, "Id", "Name");
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            return View(product);
            
        }

        [HttpPost("CreateOrUpdateProduct")]
        public async Task<IActionResult> CreateOrUpdateProduct(ProductDto productDto, IFormFile formFile)
        {
            var product = await _productService.AddProduct(productDto,formFile);

            return RedirectToAction("Index");
        }
        
       
        
    }
}











