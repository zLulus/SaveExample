using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LocationDemo
{
    public class LocationServiceBinder : Binder
    {
        public LocationService Service
        {
            get { return this.service; }
        }
        protected LocationService service;

        public bool IsBound { get; set; }

        public LocationServiceBinder(LocationService service)
        {
            this.service = service; 
            
        }


    }
}