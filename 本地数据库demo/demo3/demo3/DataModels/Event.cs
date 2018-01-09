using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class Event
    {
        [PrimaryKey]
        [MaxLength(50)]
        public string id { get; set; }

        [MaxLength(50)]
        public string journalId { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double latitude { get; set; }

        [MaxLength(50)]
        public string title { get; set; }

        [MaxLength(300)]
        public string text { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [MaxLength(100)]
        public string photo { get; set; }

        [MaxLength(100)]
        public string time { get; set; }

        /// <summary>
        /// 0未同步，1已同步
        /// </summary>
        public int syncState { get; set; }
    }
}
