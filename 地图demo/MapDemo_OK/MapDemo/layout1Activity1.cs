using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MapDemo
{
    [Activity(Label = "layout1Activity1", MainLauncher = true)]
    public class layout1Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.layout1);
            Button bt = FindViewById<Button>(Resource.Id.MyButton);
            bt.Click += delegate
            {
                MainActivity m=new MainActivity();
                m.AddPolylines();
                //todo StartActivity(new Intent(this,m))
            };
        }
    }
}