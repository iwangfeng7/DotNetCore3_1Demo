using DotNetCore3_1Utility;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore3_1Demo.Controllers
{
    [CustomControllerFilter]
    public class FourthController : Controller
    {
        [CustomActionFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}