using DotNetCore3_1Interface;
using System;

namespace DotNetCore3_1Service
{
    public class TestServiceF : ITestServiceF
    {
        public void Show()
        {
            Console.WriteLine("This is  TestServiceF 继承接口：ITestServiceF");
        }
    }
}
