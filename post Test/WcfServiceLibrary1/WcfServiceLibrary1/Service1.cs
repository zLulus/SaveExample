using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ConsoleApplication1;

namespace WcfServiceLibrary1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        [WebInvoke(Method = "POST", UriTemplate = "Test/{r}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string Test(string r,int memoryStream)
        {
            return memoryStream + "???" + r;
        }

        [WebInvoke(Method = "GET", UriTemplate = "LogIn/{a}/{b}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public bool LogIn(string a, string b)
        {
            return true;
        }

        [WebInvoke(Method = "POST", UriTemplate = "GetUser", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public User GetUser(User u)
        {
            return new User() {name = "bbb", phoneNum = "456"};
        }

        [WebInvoke(Method = "POST", UriTemplate = "GetUser2?value={value}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public User GetUser2(User u,int value)
        {
            return new User() {phoneNum = value.ToString()};
        }

        [WebInvoke(Method = "POST", UriTemplate = "GetStreamAndExtention/{value}", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public string GetStreamAndExtention(string value, Stream stream)
        {
            StreamReader reader=new StreamReader(stream);
            return "stream:"+reader.ReadToEnd()+ " && value:"+ value;
        }
    }
}
