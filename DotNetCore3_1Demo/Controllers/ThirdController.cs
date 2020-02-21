using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetCore3_1Demo.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Test customException");
            return View();
        }
    }
}