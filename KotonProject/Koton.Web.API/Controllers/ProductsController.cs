using AutoMapper;
using Koton.Business.Abstract;
using Koton.Business.Concrete;
using Koton.Business.DTO_s;
using Koton.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductsService _productsService;
        IMapper _mapper;


        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<Koton.Entities.Models.Product>> GetAllProducts()
        {
            var res = await _productsService.GetAllProductsAsync();
            return res;
            //Tüm verileri çekmek için kullanılan method
        }
        [HttpGet("GetById")]
        public async Task<Koton.Entities.Models.Product> GetById(int Id)
        {
            var res = await _productsService.GetProductById(Id);

            return res;
        }

        [HttpPost("AddProduct")]
        public async Task<Koton.Entities.Models.Product> AddProducts(ProductDto productDto)
        {
            return await _productsService.AddProduct(productDto);

        }
       
    }
}
