using Koton.Business.Abstract;
using Koton.Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Runtime.CompilerServices;
using Koton.Web.API.Models;

namespace Koton.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;
    }
}
    //public OrderController(IOrderService orderService)
    //{
    //    _orderService = orderService;
    //}
