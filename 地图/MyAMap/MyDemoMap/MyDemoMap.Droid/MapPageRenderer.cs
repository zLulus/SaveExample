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
            layout1.AddView(mapView); //���ƿ�����Ƹ����Ӳ���!!!!!
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

            aMap.SetLocationSource(this);// ���ö�λ����
            aMap.UiSettings.MyLocationButtonEnabled = true;// ����Ĭ�϶�λ��ť�Ƿ���ʾ
            aMap.MyLocationEnabled = true;// ����Ϊtrue��ʾ��ʾ��λ�㲢�ɴ�����λ��false��ʾ���ض�λ�㲢���ɴ�����λ��Ĭ����false
            //aMap.SetMyLocationType(AMap.LOCATION_TYPE_LOCATE);//���ö�λ������Ϊ����ģʽ��3D��ͼ����;

            // �Զ���ϵͳ��λС����
            MyLocationStyle myLocationStyle = new MyLocationStyle();
            myLocationStyle.InvokeMyLocationIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.location_marker));// ����С�����ͼ��
            myLocationStyle.InvokeStrokeColor(Android.Graphics.Color.Black);// ����Բ�εı߿���ɫ
            myLocationStyle.InvokeRadiusFillColor(Android.Graphics.Color.Argb(100, 0, 0, 180));// ����Բ�ε������ɫ
            myLocationStyle.InvokeStrokeWidth(1.0f);// ����Բ�εı߿��ϸ
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
                 * 1.0.2�汾��������������true��ʾ��϶�λ�а���gps��λ��false��ʾ�����綨λ��Ĭ����true Location
                 * API��λ����GPS�������϶�λ��ʽ
                 * ����һ�������Ƕ�λprovider���ڶ�������ʱ�������2000���룬������������������λ���ף����ĸ������Ƕ�λ������
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
                if (aLocation.AMapException.ErrorCode == 0) //��ֹ��λʧ�ܺ󣬻��(0,0)���꣬�ܵ�����!!!!
                {
                    //aLocation ������õ�ʵʱ����ֵ������ҵ���߼��У��������á�
                    mListener.OnLocationChanged(aLocation);// ��ʾϵͳС����
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