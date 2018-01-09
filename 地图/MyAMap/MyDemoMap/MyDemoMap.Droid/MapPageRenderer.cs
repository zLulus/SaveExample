using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Amap.Api.Maps2d;
using Com.Amap.Api.Maps2d.Model;
using MyMapNS;
using MyMapNS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using com.priest119;
using Com.Amap.Api.Location;

[assembly: ExportRenderer(typeof(MapPage), typeof(MapPageRenderer))]
namespace MyMapNS.Droid {
    public class MapPageRenderer : PageRenderer,ILocationSource,IAMapLocationListener  {

        private MapPage myAMapPage;
        private LinearLayout layout1;
        private MapView mapView;
        private AMap aMap;
        private Bundle bundle;

        private ILocationSourceOnLocationChangedListener mListener;
        private LocationManagerProxy mAMapLocationManager;
        private bool isFirst = true;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e) 
        {
            base.OnElementChanged(e);
            myAMapPage = e.NewElement as MapPage;
            layout1 = new LinearLayout(this.Context);
            this.AddView(layout1);
            IniMapView();
            layout1.AddView(mapView); //类似可以设计更复杂布局!!!!!
        }

        private void IniMapView()
        {
            mapView = new MapView(this.Context)
            {
                LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };
            mapView.OnCreate(bundle);

            if (aMap == null)
            {
                aMap = mapView.Map;
                setUpMap();
            }
          
        }

        private void setUpMap()
        {
            LatLng SHANGHAI = new LatLng(31.238068, 121.501654);
            aMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(SHANGHAI, 14));
            aMap.MapType = AMap.MapTypeNormal;

            var pins = myAMapPage.Pins;

            Drawable d = Resources.GetDrawable(Resource.Drawable.red_location);
            Bitmap bitmap = ((BitmapDrawable)d).Bitmap;
            LatLng latLng1;
            foreach (UserTaskEntInfo pin in pins)
            {
                latLng1 = new LatLng(pin.Longitude ?? 31.238068, pin.Latitude ?? 121.501654);
                var markOption = new MarkerOptions();
                markOption.InvokeIcon(BitmapDescriptorFactory.FromBitmap(bitmap));
                markOption.InvokeTitle(pin.Name);
                markOption.InvokePosition(latLng1);
                var fix = aMap.AddMarker(markOption);
                fix.ShowInfoWindow();
            }

            aMap.SetLocationSource(this);// 设置定位监听
            aMap.UiSettings.MyLocationButtonEnabled = true;// 设置默认定位按钮是否显示
            aMap.MyLocationEnabled = true;// 设置为true表示显示定位层并可触发定位，false表示隐藏定位层并不可触发定位，默认是false
            //aMap.SetMyLocationType(AMap.LOCATION_TYPE_LOCATE);//设置定位的类型为跟随模式，3D地图才有;

            // 自定义系统定位小蓝点
            MyLocationStyle myLocationStyle = new MyLocationStyle();
            myLocationStyle.InvokeMyLocationIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.location_marker));// 设置小蓝点的图标
            myLocationStyle.InvokeStrokeColor(Android.Graphics.Color.Black);// 设置圆形的边框颜色
            myLocationStyle.InvokeRadiusFillColor(Android.Graphics.Color.Argb(100, 0, 0, 180));// 设置圆形的填充颜色
            myLocationStyle.InvokeStrokeWidth(1.0f);// 设置圆形的边框粗细
            aMap.SetMyLocationStyle(myLocationStyle);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b) {
            base.OnLayout(changed, l, t, r, b);
            var msw = View.MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = View.MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            layout1.Measure(msw, msh);
            layout1.Layout(0, 0, r - l, b - t);
        }

        public void Activate(ILocationSourceOnLocationChangedListener listener)
        {
            mListener = listener;
            if (mAMapLocationManager == null)
            {
                mAMapLocationManager = LocationManagerProxy.GetInstance(this.Context);
                /*
                 * mAMapLocManager.setGpsEnable(false);
                 * 1.0.2版本新增方法，设置true表示混合定位中包含gps定位，false表示纯网络定位，默认是true Location
                 * API定位采用GPS和网络混合定位方式
                 * ，第一个参数是定位provider，第二个参数时间最短是2000毫秒，第三个参数距离间隔单位是米，第四个参数是定位监听者
                 */
                mAMapLocationManager.RequestLocationData(LocationProviderProxy.AMapNetwork, 2000, 10, this);
            }
        }

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
                if (aLocation.AMapException.ErrorCode == 0) //防止定位失败后，获得(0,0)坐标，跑到海里!!!!
                {
                    //aLocation 包含获得的实时坐标值，可在业务逻辑中，加以利用。
                    mListener.OnLocationChanged(aLocation);// 显示系统小蓝点
                    if (isFirst)
                    {
                        mapView.Map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(aLocation.Latitude, aLocation.Longitude), 14));
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

    }
}