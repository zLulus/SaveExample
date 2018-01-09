using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class ChatLog
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(20)]
        public string sender { get; set; }

        [MaxLength(20)]
        public string reciever { get; set; }

        [MaxLength(300)]
        public string content { get; set; }
    }
}
