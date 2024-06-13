using Koton.Web.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Koton.Web.Client.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }   
    }
    
}
