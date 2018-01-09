using System.Net;
using System.Net.Security;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Java.IO;
using Java.Lang;
using Java.Net;
using Org.Apache.Http;
using Org.Apache.Http.Client.Methods;
using Org.Apache.Http.Entity;
using Org.Apache.Http.Impl.Client;
using Org.Apache.Http.Message;
using HttpStatus = Java.Net.HttpStatus;
using String = System.String;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                //记住打开权限

                //String path = "http://localhost:8733/WcfService/Service1/AddUser";
                //// 新建一个URL对象 
                //URL url = new URL(path);
                //// 打开一个HttpURLConnection连接 
                //HttpURLConnection urlConn = (HttpURLConnection)url.OpenConnection();
                //// 设置连接超时时间 
                //urlConn.ConnectTimeout = 5*1000;
                //// 开始连接 
                //urlConn.Connect();
                //// 判断请求是否成功 
                //if (urlConn.ResponseCode==HttpStatus.Ok)
                //{
                //    // 获取返回的数据 

                //}
                //else {
                //    Log.Info("OnCreate", "Get方式请求失败");
                //}
                //// 关闭连接 
                //urlConn.Disconnect();




                //Uri uri =new Uri("http://localhost:8733/WcfService/Service1/AddUser");
                //Intent it = new Intent(Intent.ActionView, uri);
                //StartActivity(it);


                //访问百度的html文件的源码
                //URL url = new URL("http://www.baidu.com/");
                //HttpURLConnection urlConnection = (HttpURLConnection)url.OpenConnection();

                //try
                //{
                //    InputStream inputStream = new BufferedInputStream(urlConnection.InputStream);
                //}
                //finally

                //{
                //    urlConnection.Disconnect();
                //}

                // Creating HTTP client
                DefaultHttpClient httpClient = new DefaultHttpClient();

                // Creating HTTP Post
                HttpPost httpPost = new HttpPost("http://localhost:8733/WcfService/Service1/AddUser/1/1/1/1");
                //httpPost.Entity=new BasicHttpEntity();
                // Making HTTP Request
                try
                {
                    IHttpResponse response = httpClient.Execute(httpPost);

                    // writing response to log
                    Log.Debug("Http Response:", response.ToString());

                }
                catch (Exception e)
                {
                    

                }
            };
        }
    }
}

