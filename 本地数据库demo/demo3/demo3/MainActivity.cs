using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using demo3.DataModels;
using SQLite;
using SQLite.Net.Platform.Generic;

namespace demo3
{
    [Activity(Label = "demo3", MainLauncher = true, Icon = "@drawable/icon")]
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
                var sqliteFilename = "TodoSQLite.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = System.IO.Path.Combine(documentsPath, sqliteFilename);
                // Create the connection
                SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLitePlatformGeneric(), path);

                DBManager<Stock> manager=new DBManager<Stock>(conn);
                manager.InsertOne(new Stock() {test = "ttt"});
                List<Stock> ss = manager.QueryAll();

                manager.InsertMany(new List<Stock>() {new Stock() {test = "111"} , new Stock() { test = "1222" } });
                ss = manager.QueryAll();
            };
        }
    }
}

