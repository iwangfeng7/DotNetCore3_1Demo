using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCore3_1Demo.Controllers
{
    public class ApiShowController : Controller
    {
        public IActionResult Index()
        {
            List<Person> list = new List<Person>();

            #region 直接调用

            //string url = "http://localhost:2020/api/First/get";
            //var result = WebApiExtend.InvokeApi(url);
            //list = JsonConvert.DeserializeObject<List<Person>>(result);

            #endregion 直接调用

            return View(list);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}