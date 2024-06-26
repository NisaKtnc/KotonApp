﻿using Koton.Business.Abstract;
using Koton.Web.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koton.Web.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        //private readonly ILogger<HomeController> _logger;
        //private readonly IProductService _productService;
        //public HomeController(ILogger<HomeController> logger, IProductService productService)
        //{
        //    _logger = logger;
        //    _productService = productService;  //dependecy injection
        //}

        public async Task<IActionResult> Index()
        {
            //httpclient ->   localhost4541/api/products/getallproducts;
            return View();
        }

        public async Task<IActionResult> GetByIdProduct()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> ProductInformation()
        {
            return View();
        }
        public async Task<IActionResult> CreateOrUpdateProduct()
        {
            return View();
        }
        public async Task<IActionResult> GetAllColorAsync()
        {
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