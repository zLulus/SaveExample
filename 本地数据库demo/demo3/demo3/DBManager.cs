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
    /// ֧�ֱ����Ժ��޸����ݽṹ��ԭ��¼����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBManager<T> where T:class
    {
        private SQLite.Net.SQLiteConnection db;
        public DBManager(SQLite.Net.SQLiteConnection con)
        {
            db = con;
            //���������������ڱ���û�и���
            db.CreateTable<FriendInfo>();
            db.CreateTable<ChatLog>();
            db.CreateTable<Event>();
            db.CreateTable<Journal>();

            db.CreateTable<User>();
            db.CreateTable<Point>();
        }

        /// <summary>
        /// ��������Ч����id=1��ʼ��¼ ���ظ�ֵ����ֵҲ��Ч��
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
        /// ����ԭ��¼����Ҫ�Ȳ�ѯԭ������Ϣ�����޸ģ��ٸ���
        /// ��������PK��
        /// </summary>
        public void UpdateOne(T target)
        {
            db.Update(target);
        }

        /// <summary>
        /// ����ԭ��¼����Ҫ�Ȳ�ѯԭ������Ϣ�����޸ģ��ٸ���
        /// ��������PK��
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
        /// ������PK
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
        /// ʹ��Linq���
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