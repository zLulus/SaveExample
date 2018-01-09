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
    [DataAccessObject]
    public abstract class Book : DataAccessObject
    {
        //("$(TYPE_NAME)$(PROPERTY_NAME)")
        [PrimaryKey]
        [PersistedMember]
        public abstract long SerialNumber { get; set; }

        [PrimaryKey]
        [PersistedMember]
        public abstract string PublisherName { get; set; }

        [PersistedMember]
        public abstract string Title { get; set; }

        [RelatedDataAccessObjects]
        public abstract RelatedDataAccessObjects<Person> Borrowers { get; }
    }

}