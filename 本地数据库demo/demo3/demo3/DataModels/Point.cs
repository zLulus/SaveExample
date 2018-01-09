using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace demo3.DataModels
{
    public class Point
    {
        /// <summary>
        /// GUID
        /// </summary>
        [PrimaryKey]
        [MaxLength(20)]
        public string id { get; set; }

        //[AutoIncrement]
        //public int myOrder { get; set; }

        /// <summary>
        /// 存储，考虑登陆多个账号
        /// </summary>
        [MaxLength(20)]
        public string ownPhoneNum { get; set; }

        /// <summary>
        /// 0未同步，1已同步
        /// </summary>
        public int syncState { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }

        [MaxLength(100)]
        public string time { get; set; }

    }
}
