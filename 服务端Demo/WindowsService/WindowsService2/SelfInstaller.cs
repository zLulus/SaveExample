using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService2
{
    public static class SelfInstaller
    {
        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;
        //获取当前服务的.exe文件的路径
        public static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] {_exePath});
                //使用ManagedInstallerClass类的静态方法InstallHelper方法

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] {"/u", _exePath});
                //调用同样的方法，传参数时在前面加"/u"，表示非安装，而是卸载
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
