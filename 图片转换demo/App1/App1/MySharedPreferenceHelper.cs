using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace TravelMobileAndroid.Helpers
{
    enum SharedPreferenceEnum
    {
        LogPhoneNumber,    //登陆手机号码
        IsFirstUse       //获取是否为初次使用
    }
    public class MySharedPreferenceHelper
    {
        static string FilePath ="Test";
        private ISharedPreferences _sharedPreferences;
        private ISharedPreferencesEditor _editor;

        private static MySharedPreferenceHelper _instance = null;
        private static readonly object lockHelper = new object();
        public static MySharedPreferenceHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockHelper)
                    {
                        if (null == _instance)
                        {
                            _instance = new MySharedPreferenceHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        private MySharedPreferenceHelper()
        {
            _sharedPreferences = Application.Context.GetSharedPreferences(FilePath, FileCreationMode.Private);
            _editor = _sharedPreferences.Edit();
        }
        
        public bool IsFirstUse {
            get
            {
                var preference = Application.Context.GetSharedPreferences(FilePath, FileCreationMode.Private);
                return preference.GetBoolean(("IsFirstUse"), true);
            }
            set
            {
                var editor = Application.Context.GetSharedPreferences(FilePath, FileCreationMode.Append).Edit();
                editor.PutBoolean(("IsFirstUse"), value);
                editor.Commit();
            }
        }

        /// <summary>
        /// 当前登录用户手机号
        /// </summary>
        public string LogInPhoneNumber
        {
            get
            {
                return _sharedPreferences.GetString("LogPhoneNumber", "");
            }
            set
            {
                _editor.PutString("LogPhoneNumber", value);
                _editor.Commit();
            }
        }

        /// <summary>
        /// 紧急呼救电话号码和联系人姓名
        /// : 分隔姓名和电话号码   即 姓名:电话号码
        /// </summary>
        public string EmergentPhone
        {
            get
            {
                return _sharedPreferences.GetString("EmergentPhone", "");
            }
            set
            {
                _editor.PutString("EmergentPhone", value);
                _editor.Commit();
            }
        }

        /// <summary>
        /// 紧急呼救短信集合
        /// 格式  姓名:电话号码;姓名:电话号码;姓名:电话号码;姓名:电话号码....;   分号结束
        /// </summary>
        public string EmergentNote
        {
            get
            {
                return _sharedPreferences.GetString("EmergentNote", "");
            }
            set
            {
                _editor.PutString("EmergentNote", value);
                _editor.Commit();
            }
        }
    }
}