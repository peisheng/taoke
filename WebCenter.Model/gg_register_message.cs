//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCenter.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gg_Register_Message : BaseModel
    {
        public Gg_Register_Message()
        {
            this.Gg_Download_Record = new HashSet<Gg_Download_Record>();
            this.Gg_Login_Record = new HashSet<Gg_Login_Record>();
            this.Gg_Share_Record = new HashSet<Gg_Share_Record>();
        }
    
    	[EntityPrimKey]
        public string Register_Message_ID { get; set; }
        public string Register_ID { get; set; }
        public string Register_Name { get; set; }
        public string Nick_Name { get; set; }
        public Nullable<System.DateTime> Register_Time { get; set; }
        public string Source_IP { get; set; }
        public Nullable<int> Source_Port { get; set; }
        public string Destination_IP { get; set; }
        public Nullable<int> Destination_Port { get; set; }
        public string Register_Mail { get; set; }
        public string Verify_Mail { get; set; }
        public string Verify_Mobile { get; set; }
        public string IMEI { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<Gg_Download_Record> Gg_Download_Record { get; set; }
        public virtual ICollection<Gg_Login_Record> Gg_Login_Record { get; set; }
        public virtual ICollection<Gg_Share_Record> Gg_Share_Record { get; set; }
    }
}