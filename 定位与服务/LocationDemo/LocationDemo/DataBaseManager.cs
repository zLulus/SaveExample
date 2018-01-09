using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LocationDemo
{
    public class DataBaseManager    //todo <T> where T : class
    {
        private Context context;
        private SQLiteDatabase db;

        public DataBaseManager(Context con)
        {
            context = con;
            OpenDb();
        }

        public void OpenDb()
        {
            db = context.OpenOrCreateDatabase("TravelMobileDataBase", FileCreationMode.Private, null);
			//仅第一次需要创建
            //db.ExecSQL("create table Points(ID varchar(50) primary key,myOrder int, state int,longitude double,latitude double,time varchar(50))");
        }

        public void CloseDb()
        {
            db.Close();
        }

        public void DeleteDb()
        {
            context.DeleteDatabase("TravelMobileDataBase");
        }

        public void Insert(double Latitude,double Longitude)
        {
            if (db != null)
            {
                db.BeginTransaction();
                ContentValues values=new ContentValues();
                values.Put("ID",Guid.NewGuid().ToString());
                values.Put("latitude", Latitude);
                values.Put("longitude", Longitude);
                db.Insert("Points", null, values);
                db.EndTransaction();
            }
        }

        public void Modify()
        {
            
        }

        public void Delete()
        {
            
        }

        public void Query()
        {
            
        }
    }
}