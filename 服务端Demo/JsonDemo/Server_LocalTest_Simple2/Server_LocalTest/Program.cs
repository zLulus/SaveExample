using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Newtonsoft.Json;
using TravelMobileApp.DataModels;

namespace Server_LocalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server-Local
            DAL.Event newEvent = new DAL.Event();
            newEvent.journalId = "123";
            newEvent.id = "1234";
            newEvent.text = "aaaaa";
            newEvent.x = 12;
            newEvent.y = 123;
            newEvent.time = DateTime.Now;
            //string jsonStr=DAL.Event.ClassToJson(newEvent);
            //Console.WriteLine(jsonStr);

            //服务器->本地
            string str1 = JsonConvert.SerializeObject(newEvent);
            Console.WriteLine(str1);
            TravelMobileApp.DataModels.Event e2=JsonConvert.DeserializeObject<TravelMobileApp.DataModels.Event>(str1);
            //本地->服务器
            string str2 = JsonConvert.SerializeObject(e2);
            Console.WriteLine(str2);
            DAL.Event e3 = JsonConvert.DeserializeObject<DAL.Event>(str2);

            //Local处理
            //TravelMobileApp.DataModels.Event localEvent = TravelMobileApp.DataModels.Event.JsonToClass(jsonStr);


            //Local-Server
            //string jsonStr2=TravelMobileApp.DataModels.Event.ClassToJson(localEvent);
            //Server处理
            //DAL.Event e2=DAL.Event.JsonToClass(jsonStr2);


            //List测试

            Console.Read();
        }
    }
}
