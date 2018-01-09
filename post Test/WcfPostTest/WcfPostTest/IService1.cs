using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPostTest
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST",BodyStyle = WebMessageBodyStyle.Bare,RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,UriTemplate = "/GetData?value={value}")]
        string GetData(int value, Stream realValue);

        // TODO: 在此添加您的服务操作
    }
}
