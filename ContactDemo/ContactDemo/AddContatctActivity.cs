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

namespace ContactDemo
{
    [Activity(Label = "AddContatctActivity")]
    public class AddContatctActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddContatctLayout);

            EditText nameTextView = FindViewById<EditText>(Resource.Id.nameEditText);
            EditText phoneNumberTextView = FindViewById<EditText>(Resource.Id.phoneNumberEditText);
            Button addButton = FindViewById<Button>(Resource.Id.AddButton);

            addButton.Click += delegate
            {
                Intent intent=new Intent();
                intent.PutExtra("name", nameTextView.Text);
                intent.PutExtra("phoneNumber", phoneNumberTextView.Text);
                SetResult(Result.Ok,intent);
                Finish();
            };
        }
    }
}