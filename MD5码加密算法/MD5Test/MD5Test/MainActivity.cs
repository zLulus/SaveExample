using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MD5Test
{
    [Activity(Label = "MD5Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            TextView tv1 = FindViewById<TextView>(Resource.Id.tv1);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView tv2 = FindViewById<TextView>(Resource.Id.tv2);
            button.Click += delegate
            {
                tv2.Text = GetDM5Str(tv1.Text);
            };
        }

        private string GetDM5Str(string preStr)
        {
            MD5 md5= MD5.Create();
            md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(preStr));
            //通过解密已测试，加密正确
            string result= md5.Hash.Aggregate("", (str, byt) => str += byt.ToString("X2"));
            return result;
        }
    }
}

