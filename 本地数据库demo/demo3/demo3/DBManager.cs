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
using demo3.DataModels;
using SQLite;
using TravelMobileApp.DataModels;

namespace demo3
{
    /// <summary>
    /// 支持表建立以后修改数据结构，原记录存在
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBManager<T> where T:class
    {
        private SQLite.Net.SQLiteConnection db;
        public DBManager(SQLite.Net.SQLiteConnection con)
        {
            db = con;
            //不存在则建立表，存在表，则没有覆盖
            db.CreateTable<FriendInfo>();
            db.CreateTable<ChatLog>();
            db.CreateTable<Event>();
            db.CreateTable<Journal>();

            db.CreateTable<User>();
            db.CreateTable<Point>();
        }

        /// <summary>
        /// 自增长有效，从id=1开始记录 不必赋值（赋值也无效）
        /// </summary>
        public void InsertOne(T target)
        {
            db.Insert(target);
        }

        public void InsertMany(List<T> target)
        {
            foreach (var t in target)
            {
                db.Insert(t);
            }
        }

        /// <summary>
        /// 覆盖原记录，需要先查询原来的信息，再修改，再覆盖
        /// （必须有PK）
        /// </summary>
        public void UpdateOne(T target)
        {
            db.Update(target);
        }

        /// <summary>
        /// 覆盖原记录，需要先查询原来的信息，再修改，再覆盖
        /// （必须有PK）
        /// </summary>
        /// <param name="target"></param>
        public void UpdateMany(List<T> target)
        {
            foreach (var t in target)
            {
                db.Update(t);
            }
        }

        /// <summary>
        /// 必须有PK
        /// </summary>
        /// <param name="target"></param>
        public void DeleteOne(T target)
        {
            db.Delete(target);
        }

        public void DeleteMany(List<T> target)
        {
            foreach (var t in target)
            {
                db.Delete(t);
            }
        }

        /// <summary>
        /// 使用Linq语句
        /// </summary>
        /// <returns></returns>
        public List<T> QueryAll()
        {
            return (from c in db.Table<T>()
                select c).ToList();
        }

        public List<T> Query(System.Linq.Expressions.Expression<Func<T,bool>> lamdaExpression)
        {
            return db.Table<T>().Where(lamdaExpression).ToList();
        }
    }
}