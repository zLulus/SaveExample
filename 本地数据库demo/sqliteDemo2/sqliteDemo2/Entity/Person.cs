using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [DataAccessObject]
    public abstract class Person : DataAccessObject
    {
            [AutoIncrement]
            [PersistedMember]
            public abstract Guid Id { get; set; }

            [PersistedMember]
            public DateTime? Birthdate { get; set; }

            [PersistedMember]
            public abstract int Age { get; set; }

            [PersistedMember]
            public abstract string Name { get; set; }

            [PersistedMember]
            public abstract Person BestFriend { get; set; }

            [BackReference]
            public abstract Book BorrowedBook { get; set; }

            [Description]
            [Index(LowercaseIndex = true)]
            [ComputedTextMember("{Name} of age {Age}")]
            public abstract string Description { get; set; }
    }

}