using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceG : ITestServiceG
    {

        private ITestServiceB testServiceB = null;
         
        public TestServiceG(ITestServiceB iTestServiceB)
        {
            testServiceB = iTestServiceB;
        }
        public void Show()
        {
            Console.WriteLine("This is  TestServiceG 继承接口：TestServiceG");
        }
    }
}
