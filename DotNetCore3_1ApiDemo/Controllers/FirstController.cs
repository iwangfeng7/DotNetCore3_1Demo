using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace DotNetCore3_1ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new[]
            {
                new Person()
                {
                    Name = "iwangfeng7",
                    Age = 25
                },
                new Person()
                {
                    Name = "iwangfeng7",
                    Age = 25
                },
            };
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}