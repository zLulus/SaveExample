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
    
    public partial class Message
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string reciever { get; set; }
        public Nullable<int> messageType { get; set; }
        public string content { get; set; }
        public Nullable<int> state { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
