using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceD_Three : ITestServiceD
    {
        public void Show()
        {
            Console.WriteLine("This is  TestServiceD_Three   继承接口：ITestServiceD");
        }
    }
}