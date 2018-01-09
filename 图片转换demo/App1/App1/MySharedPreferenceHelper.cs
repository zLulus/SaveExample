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
        LogPhoneNumber,    //��½�ֻ�����
        IsFirstUse       //��ȡ�Ƿ�Ϊ����ʹ��
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
        /// ��ǰ��¼�û��ֻ���
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
        /// �������ȵ绰�������ϵ������
        /// : �ָ������͵绰����   �� ����:�绰����
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
        /// �������ȶ��ż���
        /// ��ʽ  ����:�绰����;����:�绰����;����:�绰����;����:�绰����....;   �ֺŽ���
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