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
using Java.Util.Jar;
using sqliteDemo2.Entity;
using Shaolinq;

namespace sqliteDemo2
{
    public class SQLiteManager
    {
        private volatile static SQLiteManager _instance = null;
        private static readonly object lockHelper = new object();

        private SQLiteManager()
        {
            
        }
        public static SQLiteManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (_instance == null)
                            _instance = new SQLiteManager();
                    }
                }
                return _instance;
            }
        }


        private ExampleModel model;
        public void CreatDataBase()
        {
            var configuration = Shaolinq.Sqlite.SqliteConfiguration.Create(":memory:");
            model = DataAccessModel.BuildDataAccessModel<ExampleModel>(configuration);
            //如果不存在则创建
            model.Create(DatabaseCreationOptions.IfDatabaseNotExist);
        }

        public void InsertOne()
        {
            using (var scope = new DataAccessScope())
            {
                var person = model.Books.Create();
                var p=model.GetDataAccessObjects<Person>().Create();
                person.PublisherName = "Penguin";
                

                scope.Complete();
            }
        }

        public void Update()
        {
            using (var scope = new DataAccessScope())
            {
                // Gets a reference to an object with a composite primary key without hitting the database

                var book = model.Books.GetReference(new { PublisherName = "Penguin" });
                //var s=model.GetDataAccessObjects<Book>().GetReference(new {Id = 100, PublisherName = "Penguin"});
                book.Title = "Expert Shaolinq";

                // Will throw if the book (above) does not exist on commit in a single trip to the database

                scope.Complete();
            }
        }


    }
}