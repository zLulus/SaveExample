using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Java.IO;
using TravelMobileAndroid.Helpers;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
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
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                //Bitmap-byte
                Bitmap bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.photo3);
                MemoryStream stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                stream.Flush();
                stream.Close();
                byte[] bitmapBytes = stream.ToArray();

                //bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.photo5);
                //stream = new MemoryStream();
                //bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                //stream.Flush();
                //stream.Close();
                //bitmapBytes = stream.ToArray();

                //bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.photo6);
                //stream = new MemoryStream();
                //bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                //stream.Flush();
                //stream.Close();
                //bitmapBytes = stream.ToArray();


                //bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.photo4);
                //stream = new MemoryStream();
                //bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                //stream.Flush();
                //stream.Close();
                //bitmapBytes = stream.ToArray();

                //byte-Bitmap
                Bitmap b =BitmapFactory.DecodeByteArray(bitmapBytes, 0, bitmapBytes.Length);
            };
        }

        public static String byteToBit(byte b)
        {

            return ""
                + (byte)((b >> 7) & 0x1) + (byte)((b >> 6) & 0x1)
                + (byte)((b >> 5) & 0x1) + (byte)((b >> 4) & 0x1)
                + (byte)((b >> 3) & 0x1) + (byte)((b >> 2) & 0x1)
                + (byte)((b >> 1) & 0x1) + (byte)((b >> 0) & 0x1);
        }
    }
}

