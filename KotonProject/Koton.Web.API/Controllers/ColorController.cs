using Koton.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }      
        [HttpGet("GetAllColors")]
        public async Task<IEnumerable<Koton.Entities.Models.Color>> GetAllColors()
        { 
            var res = await _colorService.GetAllColorAsync();
            return res;
            //Tüm verileri çekmek için kullanılan metot
        }
    }
}
