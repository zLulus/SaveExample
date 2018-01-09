using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfPostTest
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public string GetData(int value,string realValue)
        {
            return $"You entered: {value}, real is {realValue}";
        }

        public string GetData2(string realValue)
        {
            return "This is " + realValue;
        }
    }
}
