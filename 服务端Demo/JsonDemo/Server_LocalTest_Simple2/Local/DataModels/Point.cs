using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace TravelMobileApp.DataModels
{
    public class Point
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int State { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        [MaxLength(100)]
        public string Time { get; set; }

    }
}
