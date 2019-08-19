using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp1.Core.Services
{
    public interface IHelloService
    {
        string HelloWorld();
    }
    public class HelloService : IHelloService
    {
        public string HelloWorld()
        {
            return "hello world";
        }
    }
}