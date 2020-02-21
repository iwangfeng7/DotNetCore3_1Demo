using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCore3_1Demo.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public FirstController(ILogger<FirstController> logger,
            ILoggerFactory loggerFactory)
        {
            _logger = logger;
            this._loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            this._logger.LogWarning("This is FirstController-Index");
            this._loggerFactory.CreateLogger<FirstController>().LogWarning("This is FirstController-Index 1");

            base.ViewBag.User1 = "ViewBag_iwangfeng7";
            base.ViewData["User2"] = "ViewData_iwangfeng7";
            base.TempData["User3"] = "TempData_iwangfeng7";
            //session需要配置
            string result = base.HttpContext.Session.GetString("User4");
            if (string.IsNullOrWhiteSpace(result))
            {
                base.HttpContext.Session.SetString("User4", "Session_iwangfeng7");
            }

            object name = "Model_iwangfeng7";

            return View(name);
        }
    }
}