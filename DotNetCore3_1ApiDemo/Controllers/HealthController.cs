using Microsoft.AspNetCore.Mvc;

namespace DotNetCore3_1ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}