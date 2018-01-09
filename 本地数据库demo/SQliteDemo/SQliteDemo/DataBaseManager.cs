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

namespace SQliteDemo
{
    public class DataBaseManager<T> where T : class
    {
        private Context context;
        private SQLiteDatabase db;
        private string tableName;

        public DataBaseManager(Context con,string tableName)
        {
            context = con;
            this.tableName = tableName;
            OpenDb();
        }

        public void OpenDb()
        {
            db = context.OpenOrCreateDatabase("TravelMobileDataBase", FileCreationMode.Private, null);

            //仅第一次需要创建,使用SharedPreference进行判断，独立的SharedPreference
            ISharedPreferences shared;
            shared = context.GetSharedPreferences("ZL", FileCreationMode.Private);
            ISharedPreferencesEditor editor = shared.Edit();
            if (!shared.GetBoolean("HasCreatDB", false))
            {
                //先删除之前的数据库，如果有
                context.DeleteDatabase("TravelMobileDataBase");
                db.ExecSQL("create table Points(ID varchar(50) primary key,myOrder int, state int,longitude double,latitude double,time varchar(50))");
                editor.PutBoolean("HasCreatDB", true);
                editor.Commit();
            }
            
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
                //TODO 反射   保证字段一致
                values.Put("ID",Guid.NewGuid().ToString());
                values.Put("latitude", Latitude);
                values.Put("longitude", Longitude);

                db.Insert(tableName, null, values);
                db.EndTransaction();
            }
        }

        public void Modify()
        {
            //db.Update()
        }

        public void Delete()
        {
            
        }

        public void Query()
        {
            //db.Query()
        }
    }
}