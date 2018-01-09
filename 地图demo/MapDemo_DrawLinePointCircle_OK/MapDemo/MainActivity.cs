using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Com.Amap.Api.Location;
using Com.Amap.Api.Maps2d;
using Com.Amap.Api.Maps2d.Model;
using Java.Util;

namespace MapDemo
{
    [Activity(Label = "MapDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationSource, IAMapLocationListener,
        AMap.IOnMapScreenShotListener, AMap.IInfoWindowAdapter,
        AMap.IOnMapClickListener,AMap.IOnMarkerClickListener
    {
        private MapView mapView;
        private AMap aMap;
        private ILocationSourceOnLocationChangedListener mListener;
        private LocationManagerProxy mAMapLocationManager;
        private bool isFirst = true;
        private Marker currentMarker; //当前Marker

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mapView = FindViewById<MapView>(Resource.Id.mapView);
            mapView.OnCreate(bundle); // 必须要写!!!!!!!!!!! *.*to lulu
            if (aMap == null)
            {
                aMap = mapView.Map;
                setUpMap();
            }
        }

        private void setUpMap()
        {
            //地图监听
            InitMapListener();
            //图片覆盖层
            BitmapOverLay();
            //添加折线
            AddPolylines();
            //绘制圆形 
            DrawCircle();
            // 设置监听
            SetLocation();
            //标记动画
            MarkAnimation();

        }

       //设置监听
        private void InitMapListener()
        {
            // 设置自定义InfoWindow样式
            aMap.SetInfoWindowAdapter(this);
            //设置Marker点击监听事件
            aMap.SetOnMarkerClickListener(this);
            aMap.SetOnMapClickListener(this);  
        }

        #region 设置监听

        private void SetLocation()
        {

            aMap.SetLocationSource(this); // 设置定位监听
            aMap.UiSettings.MyLocationButtonEnabled = true; // 设置默认定位按钮是否
            aMap.MyLocationEnabled = true; // 设置为true表示显示定位层并可触发定位，false表示隐藏定位层并不可触发定位，默认是false
            //aMap.SetMyLocationType(AMap.LOCATION_TYPE_LOCATE);//设置定位的类型为跟随模式，3D地图才有;
            // 自定义系统定位小蓝点
            MyLocationStyle myLocationStyle = new MyLocationStyle();
            myLocationStyle.InvokeMyLocationIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.Icon));
                // 设置小蓝点的图标
            myLocationStyle.InvokeStrokeColor(Android.Graphics.Color.Red); // 设置圆形的边框颜色
            myLocationStyle.InvokeRadiusFillColor(Android.Graphics.Color.Argb(100, 0, 0, 180)); // 设置圆形的填充颜色
            myLocationStyle.InvokeStrokeWidth(1.0f); // 设置圆形的边框粗细
            aMap.SetMyLocationStyle(myLocationStyle);
            aMap.MapType = AMap.MapTypeNormal;
        }

        #endregion

        #region 添加折线

        private void AddPolylines()
        {
            // 绘制一个虚线三角形
            var polylineOptions = new PolylineOptions();
            //添加坐标点，按照点的顺序依次连接
            // 如果点已经在列表中，您可以调用 PolylineOptions.addAll() 方法
            polylineOptions.Add(new LatLng(30.779879, 104.064855));
            polylineOptions.Add(new LatLng(39.936713, 116.386475));
            polylineOptions.Add(new LatLng(39.02, 120.51));
            //InvokeWidth :设置宽度； 
            //SetDottedLine:设置虚线;
            polylineOptions.InvokeWidth(10).SetDottedLine(true).Geodesic(true).InvokeColor(Color.Argb(255, 1, 1, 1));
            aMap.AddPolyline(polylineOptions);
        }

        #endregion

        #region 图片覆盖层

        private void BitmapOverLay()
        {
            // 设置当前地图显示为北京市恭王府
            aMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(39.936713, 116.386475), 19));
            //设置图片的显示区域。
            var bounds = new LatLngBounds.Builder()
                .Include(new LatLng(39.935029, 116.384377))
                .Include(new LatLng(39.949577, 116.398331)).Build();
            var groundoverlay = aMap.AddGroundOverlay(new GroundOverlayOptions()
                .Anchor(0.5f, 0.5f).InvokeTransparency(0.1f)
                .InvokeImage(BitmapDescriptorFactory.FromResource(Resource.Drawable.dashboard_queue_text))
                .PositionFromBounds(bounds));
        }

        #endregion

        #region Marker标记

        private void MarkAnimation()
        {
            List<BitmapDescriptor> giflist = new List<BitmapDescriptor>();
            //添加每一帧图片。
            giflist.Add(BitmapDescriptorFactory.FromResource(Resource.Drawable.red_location));
            var CHENGDU = aMap.AddMarker(new MarkerOptions().Anchor(0.5f, 0.5f)
                .InvokePosition(new LatLng(30.679879, 104.064855)).InvokeTitle("成都市")
                .InvokeSnippet("成都欢迎你:30.679879, 104.064855").InvokeIcons(giflist)
                .Draggable(true).InvokePeriod(30));
            // CHENGDU.ShowInfoWindow(); // 设置默认显示一个infowinfow
        }

        #endregion

        #region 绘制圆形
        private void DrawCircle()
        {
            CircleOptions circleOptions = new CircleOptions();
            circleOptions.InvokeCenter(new LatLng(30.679879, 104.064855));
            circleOptions.InvokeRadius(9000);
            circleOptions.InvokeStrokeColor(Color.Black);
            circleOptions.InvokeFillColor(Color.Transparent);
            circleOptions.InvokeStrokeWidth(3);
            aMap.AddCircle(circleOptions);
        }


        #endregion

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
                    mListener.OnLocationChanged(aLocation); // 显示系统小蓝点

                    if (isFirst)
                    {
                        aMap.MoveCamera(
                            CameraUpdateFactory.NewLatLngZoom(new LatLng(aLocation.Latitude, aLocation.Longitude), 14));
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

        #region 定制InforWindow
        /**
     * 自定义infowinfow窗口
     */

        public void render(Marker marker, View view)
        {


        }

        public View GetInfoContents(Marker p0)
        {
            return null;
        }

        /// <summary>
        /// 定制InforWindow
        /// Test版
        /// </summary>
        /// <param name="marker"></param>
        /// <returns></returns>
        public View GetInfoWindow(Marker marker)
        {
            Log.Error("marker", marker.Object + "getInfoWindow: " + marker.Id);
            View infoWindow = LayoutInflater.Inflate(
                Resource.Layout.MarkerItem, null);
            var locationName = infoWindow.FindViewById<TextView>(Resource.Id.setting_location_name);
            var locationDescription = infoWindow.FindViewById<TextView>(Resource.Id.setting_location_description);
            locationName.Text = marker.Title;//将标记的Title赋给自定义窗口的标题
            locationDescription.Text = marker.Snippet;//将标记的Snippet赋给自定义窗口的description
            render(marker, infoWindow);
            return infoWindow;
        }


        /// <summary>
        /// 地图点击事件:点击时应该隐藏信息弹窗
        /// </summary>
        /// <param name="p0"></param>
        public void OnMapClick(LatLng p0)
        {
            if (currentMarker != null)
            {
                currentMarker.HideInfoWindow();
            }
        }

        public bool OnMarkerClick(Marker p0)
        {
            currentMarker = p0;
            return false;
        }

        #endregion
    
    }
}

