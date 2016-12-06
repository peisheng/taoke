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
    
    public partial class Sys_Menu : BaseModel
    {
        public Sys_Menu()
        {
            this.Sys_Role_Right = new HashSet<Sys_Role_Right>();
        }
    
    	[EntityPrimKey]
        public string Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public string Menu_Image { get; set; }
        public string Menu_Type { get; set; }
        public string Parent_ID { get; set; }
        public Nullable<int> Open_Type { get; set; }
        public string Buttons { get; set; }
        public string Url { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Create_Time { get; set; }
        public string Creator_ID { get; set; }
        public Nullable<System.DateTime> Update_Time { get; set; }
        public string Updater_ID { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<Sys_Role_Right> Sys_Role_Right { get; set; }
    }
}
