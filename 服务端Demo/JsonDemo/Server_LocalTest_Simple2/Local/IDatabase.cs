using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace TravelMobileApp.DataModels
{
    public abstract class IDatabase<T> where T:class
    {
        protected SQLiteConnection conn = null;

        public int CreateTable()                     //创建表
        {
            return conn.CreateTable<T>();
        }
        public abstract int Insert(T model);      //插入
        public abstract int Delete(string filter);    //删除：根据候选键
        public abstract int Update(T model);        //更新

        public abstract T GetModel(string filter); //查询：根据候选键

        public IEnumerable<T> GetModelList() //返回所有对象（记录）
        {
            //return from s in conn.Table<T>()
            //       select s;
            return null;
        }

        public abstract int GetMaxId();    //得到自生长ID最大值
        //新方法
    }
}
