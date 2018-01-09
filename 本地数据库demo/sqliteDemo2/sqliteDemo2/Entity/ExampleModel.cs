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
using Shaolinq;

namespace sqliteDemo2.Entity
{
    /// <summary>
    /// 创建多张表，以下类为集中管理类，即数据库整体
    /// </summary>
    [DataAccessModel]
    public abstract class ExampleModel : DataAccessModel
    {
        [DataAccessObjects]
        public abstract DataAccessObjects<Book> Books { get; }

        /// <summary>
        /// 在这里确定表名
        /// </summary>
        [DataAccessObjects]
        public abstract DataAccessObjects<Person> People { get; }
    }
}