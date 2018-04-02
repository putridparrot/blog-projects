using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Refit;

namespace RefitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = RestService.For<IHelloService>("http://localhost:59744");
            var response = svc.SayHello("World").Result;

            Console.WriteLine(response.Result);
        }
    }
}
