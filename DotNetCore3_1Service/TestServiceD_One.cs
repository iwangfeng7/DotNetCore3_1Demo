using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceD_One : ITestServiceD
    {
        public void Show()
        {
            Console.WriteLine("This is  TestServiceD_One   继承接口：ITestServiceD");
        }
    }
}