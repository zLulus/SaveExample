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
        public int Id { get; set; }

        [MaxLength(20)]
        public string Sender { get; set; }

        [MaxLength(20)]
        public string Reciever { get; set; }

        [MaxLength(300)]
        public string Content { get; set; }
    }
}
