using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client service1Client=new ServiceReference1.Service1Client();
            Console.WriteLine(service1Client.GetData(1));
            Console.Read();
        }
    }
}
