using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            //GetTest(client);
            //PostString(client);
            //PostTarget(client);
            //PostTargetAndExtend(client);
            PostStream(client);
        }

        private static void PostStream(HttpClient client)
        {
            HttpContent content = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(3.ToString())));
            var rr = client.PostAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/GetStreamAndExtention/8", content);
            string result = rr.Result.Content.ReadAsStringAsync().Result;
        }

        private static void PostTargetAndExtend(HttpClient client)
        {
            User u = new User() { name = "aaa", phoneNum = "123123" };
            string str = JsonConvert.SerializeObject(u);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            var rr = client.PostAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/GetUser2?value=3", content);
            string result = rr.Result.Content.ReadAsStringAsync().Result;
        }

        private static void PostTarget(HttpClient client)
        {
            User u=new User() {name = "aaa",phoneNum = "123"};
            string str = JsonConvert.SerializeObject(u);
            HttpContent content = new StringContent(str, Encoding.UTF8, "application/json");
            var rr = client.PostAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/GetUser", content);
            string result = rr.Result.Content.ReadAsStringAsync().Result;
        }

        private static void PostString(HttpClient client)
        {
            //application/json!!!
            HttpContent content = new StringContent("111", Encoding.UTF8, "application/json");
            var rr = client.PostAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/Test/1", content);
            string result = rr.Result.Content.ReadAsStringAsync().Result;
        }

        private static void GetTest(HttpClient client)
        {
            string r =
                client.GetAsync("http://localhost:8733/Design_Time_Addresses/WcfPostTest/Service1/LogIn/123456/111")
                    .Result.Content.ReadAsStringAsync()
                    .Result;
        }
    }
}
