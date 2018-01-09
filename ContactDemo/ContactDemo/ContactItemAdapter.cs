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
using TestApp;

namespace ContactDemo
{
    public class ContactItemAdapter:BaseAdapter<UserContact>
    {
        private Activity activity;
        private UserContact[] userContacts;

        public ContactItemAdapter(Activity act, UserContact[] users)
        {
            activity = act;
            userContacts = users;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
                convertView = activity.LayoutInflater.Inflate(Resource.Layout.ContactItem, null);
            TextView nameTextView = convertView.FindViewById<TextView>(Resource.Id.nameTextView);
            nameTextView.Text = userContacts[position].name;
            TextView phoneNumberTextView = convertView.FindViewById<TextView>(Resource.Id.phoneNumberTextView);
            phoneNumberTextView.Text = userContacts[position].phoneNum;
            //Button deleteButton = convertView.FindViewById<Button>(Resource.Id.DeleteButton);
            //deleteButton.Click += delegate
            //{
            //    //todo 有问题
            //    List<UserContact> uc = userContacts.ToList();
            //    uc.RemoveAt(position);
            //    userContacts = uc.ToArray();
            //    //通知UI刷新数据
            //    NotifyDataSetChanged();
            //};
            return convertView;
        }

        public override int Count
        {
            get { return userContacts.Count(); }
        }

        public override UserContact this[int position]
        {
            get { return userContacts[position]; }
        }
    }
}