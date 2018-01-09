using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string phoneNum { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
