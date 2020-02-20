using DotNetCore3_1Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore3_1Demo.Controllers
{
    public class SecondController : Controller
    {
        #region 注入

        private readonly ITestServiceA _iTestServiceA;
        private readonly ITestServiceB _iTestServiceB;
        private readonly ITestServiceC _iTestServiceC;
        private readonly ITestServiceD _iTestServiceD;

        public SecondController(
              ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD)
        {
            this._iTestServiceA = testServiceA;
            this._iTestServiceB = testServiceB;
            this._iTestServiceC = testServiceC;
            this._iTestServiceD = testServiceD;
        }

        #endregion 注入

        public IActionResult Index()
        {
            return View();
        }
    }
}