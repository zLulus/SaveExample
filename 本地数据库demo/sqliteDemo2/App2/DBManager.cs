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
using SQLite;

namespace App2
{
    public class DBManager
    {
        private volatile static DBManager _instance = null;
        private static readonly object lockHelper = new object();
        private SQLiteConnection db;
        private DBManager()
        {
            SQLiteDatabase.OpenOrCreateDatabase("foofoo.db3",)
            db = new SQLiteConnection("foofoo.db3");
            db.CreateTable<Stock>();
            db.CreateTable<Valuation>();
        }
        public static DBManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new DBManager();
                    }
                }
                return _instance;
            }
        }


        public void Insert()
        {
            db.Insert(new Stock() {Symbol = "ZL"});
            db.Insert(new Stock() { Symbol = "ZHL" });
        }

        /// <summary>
        /// 覆盖原记录，需要先查询，更改之后再覆盖
        /// </summary>
        public void Update()
        {
            Stock s = Query("ZL");
            s.Symbol = "III";
            db.Update(s);
            s = Query("ZL");
            s = Query("III");
        }

        public void Delete()
        {
            
        }

        public Stock Query(string str)
        {
            //todo linq
            return db.Query<Stock>("select * from Stock where Symbol=?", str).FirstOrDefault();
        }
    }
}