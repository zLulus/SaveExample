using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.Generic;

namespace TravelMobileApp.DataModels
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string PhoneNum { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Nickname { get; set; }

        [MaxLength(5)]
        public string Sex { get; set; }

        public byte[] Avatar { get; set; }

        public override string ToString()
        {
            return this.PhoneNum;
        }
    }
}
