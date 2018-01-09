using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQliteDemo.Entities;

namespace SQliteDemo
{
    [Activity(Label = "SQliteDemo", MainLauncher = true, Icon = "@drawable/icon")]
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
                //TODO 初始化SharedPreferences  登陆成功之后
                //ISharedPreferences shared;
                //shared = GetSharedPreferences("ZL", FileCreationMode.Private);
                //ISharedPreferencesEditor editor = shared.Edit();
                //if (shared != null)
                //{
                //    editor.PutBoolean("HasCreatDB", false);
                //    editor.Commit();
                //}
                DataBaseManager<Point> dbManager=new DataBaseManager<Point>(ApplicationContext, "Point");
                dbManager.CloseDb();
                
            };
        }
    }
}

