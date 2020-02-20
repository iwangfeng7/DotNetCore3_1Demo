using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceB : ITestServiceB
    {
        public TestServiceB(ITestServiceA iTestService)
        {
        }

        public void Show()
        {
            Console.WriteLine("This is  TestServiceB  继承接口：ITestServiceB");
        }
    }
}