using Koton.Web.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        //public CartController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        ////private List<int> cart = new List<int>(); 
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        //{
        //    return await _context.Carts.ToListAsync();            
        //}
    }
}
