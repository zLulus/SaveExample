using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class Journal
    {
        [PrimaryKey]
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(20)]
        public string OwnerPhoneNum { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string CreateTime { get; set; }

        [MaxLength(100)]
        public string LastEditTime { get; set; }

        [MaxLength(100)]
        public string Cover { get; set; }

        public int SyncState { get; set; }
    }
}
