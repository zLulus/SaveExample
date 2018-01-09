using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MD5 md5 = MD5.Create();
            md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("input"));

            Console.WriteLine(md5.Hash.Aggregate("", (str, byt) => str += byt.ToString("X2")));
            Console.ReadKey();
        }
    }
}
