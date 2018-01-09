using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Amap.Api.Location;
using Com.Amap.Api.Maps2d;
using Com.Amap.Api.Maps2d.Model;
using Javax.Crypto;

namespace MapDemo
{
    [Activity(Label = "MapDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationSource, IAMapLocationListener, AMap.IOnMapScreenShotListener
    {
        private MapView mapView;
        private AMap aMap;
        private ILocationSourceOnLocationChangedListener mListener;
        private LocationManagerProxy mAMapLocationManager;
        private bool isFirst = true;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            mapView = FindViewById<MapView>(Resource.Id.mapView);
            mapView.OnCreate(bundle);   //不可少
            aMap = mapView.Map;
            setUpMap();

            
        }

        private void setUpMap()
        {
            aMap.SetLocationSource(this);// 设置定位监听
            aMap.UiSettings.MyLocationButtonEnabled = true;// 设置默认定位按钮是否
            aMap.MyLocationEnabled = true;// 设置为true表示显示定位层并可触发定位，false表示隐藏定位层并不可触发定位，默认是false
            //aMap.SetMyLocationType(AMap.LOCATION_TYPE_LOCATE);//设置定位的类型为跟随模式，3D地图才有;
            // 自定义系统定位小蓝点
            MyLocationStyle myLocationStyle = new MyLocationStyle();
            myLocationStyle.InvokeMyLocationIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.Icon));// 设置小蓝点的图标
            myLocationStyle.InvokeStrokeColor(Android.Graphics.Color.Black);// 设置圆形的边框颜色
            myLocationStyle.InvokeRadiusFillColor(Android.Graphics.Color.Argb(100, 0, 0, 180));// 设置圆形的填充颜色
            myLocationStyle.InvokeStrokeWidth(1.0f);// 设置圆形的边框粗细
            aMap.SetMyLocationStyle(myLocationStyle);
            aMap.MapType = AMap.MapTypeNormal;

            //todo http://lbs.amap.com/api/android-sdk/guide/mapcontrol/

        }

        #region 
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="listener"></param>
        public void Activate(ILocationSourceOnLocationChangedListener listener)
        {
            mListener = listener;
            if (mAMapLocationManager == null)
            {
                mAMapLocationManager = LocationManagerProxy.GetInstance(Application.Context);
                /*
                 * mAMapLocManager.setGpsEnable(false);
                 * 1.0.2版本新增方法，设置true表示混合定位中包含gps定位，false表示纯网络定位，默认是true Location
                 * API定位采用GPS和网络混合定位方式
                 * ，第一个参数是定位provider，第二个参数时间最短是2000毫秒，第三个参数距离间隔单位是米，第四个参数是定位监听者
                 */
                mAMapLocationManager.RequestLocationData(LocationProviderProxy.AMapNetwork, 2000, 10, this);
            }
        }
        /// <summary>
        /// 销毁
        /// </summary>
        public void Deactivate()
        {
            mListener = null;
            if (mAMapLocationManager != null)
            {
                mAMapLocationManager.RemoveUpdates(this);
                mAMapLocationManager.Destroy();
            }
            mAMapLocationManager = null;
        }

        public void OnLocationChanged(AMapLocation aLocation)
        {
            if (mListener != null && aLocation != null)
            {
                mAMapLocationManager.StartSocket();
                if (aLocation.AMapException.ErrorCode == 0) //防止定位失败后，获得(0,0)坐标，跑到海里!!!!
                {
                    mListener.OnLocationChanged(aLocation);// 显示系统小蓝点

                    if (isFirst)
                    {
                        aMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(aLocation.Latitude, aLocation.Longitude), 14));
                        isFirst = false;

                    }
                }
            }
        }

        public void OnLocationChanged(Android.Locations.Location location)
        {

        }

        public void OnProviderDisabled(string provider)
        {

        }

        public void OnProviderEnabled(string provider)
        {

        }

        public void OnStatusChanged(string provider, Android.Locations.Availability status, Bundle extras)
        {

        }
        public void StopLocation()
        {
            if (mAMapLocationManager != null)
            {
                mAMapLocationManager.RemoveUpdates(this);
                mAMapLocationManager.Destory();
            }
            mAMapLocationManager = null;
        }
        public void getMapScreenShot(View v)
        {
            // 设置截屏监听接口，截取地图可视区域
            aMap.GetMapScreenShot(this);
        }

        public void OnMapScreenShot(Android.Graphics.Bitmap p0)
        {

        }

        #endregion
    }
}

