using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CallBackDemo
{
    [Activity(Label = "CallBackDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ProgressBar pb1;
        //定义回调
        private delegate void SetProgressBar2ValueCallBack(int value);
        //声明回调
        private SetProgressBar2ValueCallBack setProgressBar2ValueCallBack;

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        //设置进度条2的值 的线程
        private void SetProgressBar2Value()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                pb1(setProgressBar2ValueCallBack, i);
            }
        }
        //设置进度条2的值 被委托的方法
        private void SetProgressBar2ValueMethod(int value)
        {
            pb1.Progress = value;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            pb1= FindViewById<ProgressBar>(Resource.Id.progressBar1);
            button.Click += delegate
            {
                //初始化回调
                setProgressBar2ValueCallBack = new SetProgressBar2ValueCallBack(SetProgressBar2ValueMethod);


                Thread progressBar2Thread = new Thread(SetProgressBar2Value);
                progressBar2Thread.Start();

                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    pb1.Progress = i;
                }
            };
        }
    }
}

