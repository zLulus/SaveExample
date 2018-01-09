using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace demo3.DataModels
{
    public class FriendInfo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(20)]
        public string phoneNum { get; set; }

        [MaxLength(20)]
        public string name { get; set; }

        [MaxLength(30)]
        public string nickname { get; set; }

        [MaxLength(5)]
        public string sex { get; set; }

        /// <summary>
        /// 直接存图像
        /// </summary>
        public byte[] avatar { get; set; }

        [MaxLength(20)]
        public string remark { get; set; }
    }
}
