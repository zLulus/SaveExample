using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class Event
    {
        public static Event JsonToClass(string jsonStr)
        {
            //本地无法识别反射
            //Json-object
            object obj=JsonConvert.DeserializeObject(jsonStr);
            if (obj == null) return null;
            //object-Dictionary
            //Dictionary-本地Class
            Event result = new Event();
            return JsonConvert.DeserializeObject<Event>(jsonStr);
        }

        public static string ClassToJson(Event _event)
        {
            //本地Class-Json
            return JsonConvert.SerializeObject(_event);
        }

        [PrimaryKey]
        [MaxLength(50)]
        public string id { get; set; }

        [MaxLength(50)]
        public string journalId { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        [MaxLength(300)]
        public string text { get; set; }

        [MaxLength(100)]
        public string photo { get; set; }

        [MaxLength(100)]
        public string time { get; set; }

        public int syncState { get; set; }

    }
}
