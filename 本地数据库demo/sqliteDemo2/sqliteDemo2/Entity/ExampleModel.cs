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
    /// �������ű�������Ϊ���й����࣬�����ݿ�����
    /// </summary>
    [DataAccessModel]
    public abstract class ExampleModel : DataAccessModel
    {
        [DataAccessObjects]
        public abstract DataAccessObjects<Book> Books { get; }

        /// <summary>
        /// ������ȷ������
        /// </summary>
        [DataAccessObjects]
        public abstract DataAccessObjects<Person> People { get; }
    }
}