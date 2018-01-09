using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.Generic;

namespace TravelMobileApp.DataModels
{
    public class Authenticode
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string PhoneNum { get; set; }

        [MaxLength(20)]
        public string authenticode { get; set; }
    }
}
