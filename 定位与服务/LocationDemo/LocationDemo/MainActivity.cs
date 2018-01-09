using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace LocationDemo
{
    [Activity(Label = "LocationDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //todo http://docs.mono-android.net/guides/android/application_fundamentals/backgrounding/part_3_android_backgrounding_walkthrough/
        //todo 打开两个权限
        private TextView latText;
        private TextView longText;
        private Button stopBt;
        private Button gotoBt;

        LocationService locationService=new LocationService();
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            stopBt = FindViewById<Button>(Resource.Id.stop);
            gotoBt= FindViewById<Button>(Resource.Id.Goto);
            latText = FindViewById<TextView>(Resource.Id.lat);
            longText = FindViewById<TextView>(Resource.Id.longx);

            cancellationTokenSource=new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            Intent serviceIntent = new Intent(this, typeof(LocationService));
            StartService(serviceIntent);      //todo 在服务里面记录数据库
            Task.Run (() =>
            {
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested || cancellationTokenSource.IsCancellationRequested)    //停止服务
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }

                    Location location = locationService.GetLastKnownLocation();
                    //if (location != null)
                    //{
                        //longText.Text = location.Longitude.ToString();
                        //latText.Text = location.Latitude.ToString();
                    //}
                }
            }, cancellationToken);

            stopBt.Click += delegate       //todo 没有进if
            {
                cancellationTokenSource.Cancel();
            };

            gotoBt.Click += delegate
            {
                StartActivity(new Intent(this,typeof(Activity1)));
            };


            //GetBestProvider();
            //if (locMgr != null)
            //{
            //    if (locMgr.IsProviderEnabled(Provider))
            //    {

            //        locMgr.RequestLocationUpdates(Provider, 2000, 0, this);    //实现ILocationListener
            //        Location location = locMgr.GetLastKnownLocation(Provider);
            //        Toast.MakeText(this, string.Format("{0},{1}", location.Latitude, location.Longitude), ToastLength.Short).Show();
            //    }
            //    else
            //    {
            //        Toast.MakeText(this, string.Format(Provider + " is not available. Does the device have location services enabled?"), ToastLength.Short).Show();
            //    }
            //}


        }

        /// <summary>
        /// 获取最佳的provider
        /// </summary>
        //public void GetBestProvider()
        //{
        //    Criteria locationCriteria = new Criteria();

        //    locationCriteria.Accuracy = Accuracy.Coarse;
        //    locationCriteria.PowerRequirement = Power.Medium;

        //    Provider = locMgr.GetBestProvider(locationCriteria, true);

        //    if (Provider != null)
        //    {
        //        locMgr.RequestLocationUpdates(Provider, 2000, 1, this);
        //    }
        //    else
        //    {
        //        Log.Info("GetBestProvider", "No location providers available");
        //    }
        //}

        protected override void OnResume()
        {
            base.OnResume();
            //string Provider = LocationManager.GpsProvider;
            //GetBestProvider();
            //if (locMgr != null)    //防错
            //{
            //    if (locMgr.IsProviderEnabled(Provider))
            //    {
            //        locMgr.RequestLocationUpdates(Provider, 2000, 1, this);
            //    }
            //    else
            //    {
            //        Toast.MakeText(this.ApplicationContext, Provider + " is not available. Does the device have location services enabled?", ToastLength.Short);
            //    }
            //}

        }

        protected override void OnPause()
        {
            base.OnPause();
            //locMgr.RemoveUpdates(this);
        }


    }
}

