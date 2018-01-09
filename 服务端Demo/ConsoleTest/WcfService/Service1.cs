using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DAL;
using System.ServiceModel.Web;    //需要引用DLL

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        //写在服务、接口里面均可
        [WebInvoke(Method = "GET", UriTemplate = "GetUsers", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public List<User> GetUsers()
        {
            UserDAL dal=new UserDAL();
            return dal.GetUsers();
        }

        //[WebInvoke(Method = "GET", UriTemplate = "AddUser/{json}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //public void AddUser(string json)
        //{
        //    UserDAL dal = new UserDAL();

        //    dal.AddUser(json);

        //}

        [WebInvoke(Method = "GET", UriTemplate = "AddUser/{id}/{phoneNum}/{name}/{passWord}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public void AddUser(string id, string phoneNum, string name, string passWord)
        {
            UserDAL dal = new UserDAL();
            dal.AddUser(id,phoneNum,name,passWord);
        }
    }
}
