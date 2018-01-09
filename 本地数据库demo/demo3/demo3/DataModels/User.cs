using System.Collections.Generic;
using System.Linq;
using Android.Util;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.Generic;

namespace demo3.DataModels
{
    /// <summary>
    /// 可能登陆多个用户，由SharedPreference决定
    /// </summary>
    public class User
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

        public byte[] avatar { get; set; }


    }
}
