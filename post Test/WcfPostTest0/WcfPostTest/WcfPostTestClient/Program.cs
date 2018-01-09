using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WcfPostTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var data = client.PostAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/GetData?value=8",new StringContent(2.ToString(),Encoding.UTF8,"text/json"));
            Console.WriteLine(data.Result.Content.ReadAsStringAsync().Result);
            Console.ReadKey();
        }
    }
}
