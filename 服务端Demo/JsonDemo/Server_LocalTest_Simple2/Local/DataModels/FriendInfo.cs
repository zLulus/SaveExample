using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class FriendInfo
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

        [MaxLength(20)]
        public string Remark { get; set; }
    }
}
