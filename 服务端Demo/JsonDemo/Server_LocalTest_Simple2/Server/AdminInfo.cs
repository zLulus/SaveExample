//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminInfo
    {
        public AdminInfo()
        {
            this.ServerLogs = new HashSet<ServerLog>();
            this.PushLogs = new HashSet<PushLog>();
        }
    
        public string account { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    
        public virtual ICollection<ServerLog> ServerLogs { get; set; }
        public virtual ICollection<PushLog> PushLogs { get; set; }
    }
}
