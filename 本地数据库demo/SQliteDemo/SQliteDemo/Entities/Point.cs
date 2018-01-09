using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SQliteDemo.Entities
{
    public class Point
    {
        public int myOrder;
        public string id;
        public string ownerPhoneNum;   //ÅäÖÃÎÄ¼ş¶ÁÈ¡
        public int syncState;
        public double longitude;
        public double latitude;
        public string time;

    }
}