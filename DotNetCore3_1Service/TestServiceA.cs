using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceA : ITestServiceA
    {
        public void Show()
        {
            Console.WriteLine("This is  TestServiceA 继承接口：ITestServiceA");
        }
    }
}