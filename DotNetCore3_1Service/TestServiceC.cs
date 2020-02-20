using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceC : ITestServiceC
    {

        private ITestServiceB testServiceB = null;


        public TestServiceC(ITestServiceB iTestServiceB)
        {
            testServiceB = iTestServiceB;
        } 
        public void Show()
        {
            Console.WriteLine("This is  TestServiceC 继承接口：ITestServiceC");
        }
    }
}
