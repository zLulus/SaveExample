using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LocationDemo
{
    [Service]
    //start service
    public class LocationService : Service, ILocationListener
    {
        //IBinder binder;
        public LocationManager LocMgr = Android.App.Application.Context.GetSystemService("location") as LocationManager;
        private string locationProvider;
        private DataBaseManager dbManager=new DataBaseManager(Android.App.Application.Context);
        public event EventHandler<LocationChangedEventArgs> LocationChanged = delegate { };
        public override IBinder OnBind(Intent intent)
        {
            //binder = new LocationServiceBinder(this);
            //return binder;
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            StartLocationUpdates();
            return StartCommandResult.Sticky;
        }

        public void StartLocationUpdates()
        {
            var locationCriteria = new Criteria();
            locationCriteria.Accuracy = Accuracy.NoRequirement;
            locationCriteria.PowerRequirement = Power.NoRequirement;
            locationProvider = LocMgr.GetBestProvider(locationCriteria, true);
            LocMgr.RequestLocationUpdates(locationProvider, 5000, 0, this);        //todo 现在是5s查询一次，正式启动改为2min左右较好
        }

        

        public Location GetLastKnownLocation()
        {
            return LocMgr.GetLastKnownLocation(locationProvider);
        }
        public override void OnDestroy()
        {
            // Stop receiving updates from the location manager:
            LocMgr.RemoveUpdates(this);
        }

        #region ILocationListener
        public void OnProviderEnabled(string provider)
        {

        }
        public void OnProviderDisabled(string provider)
        {

        }
        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {

        }
        public void OnLocationChanged(Android.Locations.Location location)
        {
            this.LocationChanged(this, new LocationChangedEventArgs(location));
            Log.Debug("LocationService", String.Format("Latitude is {0}", location.Latitude));
            Log.Debug("LocationService", String.Format("Longitude is {0}", location.Longitude));
            Log.Debug("LocationService", String.Format("Altitude is {0}", location.Altitude));
            Log.Debug("LocationService", String.Format("Speed is {0}", location.Speed));
            Log.Debug("LocationService", String.Format("Accuracy is {0}", location.Accuracy));
            Log.Debug("LocationService", String.Format("Bearing is {0}", location.Bearing));

            dbManager.Insert(location.Latitude, location.Longitude);
        }
        #endregion
    }
}