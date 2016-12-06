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
    
    public partial class Hash_File_Info_Upload_Statistics : BaseModel
    {
    	[EntityPrimKey]
        public string File_Info_Upload_Statistics_ID { get; set; }
        public Nullable<int> Total_Amount { get; set; }
        public Nullable<int> SuccessFile_Amount { get; set; }
        public Nullable<int> WaitFirstApprove_Amount { get; set; }
        public Nullable<int> WaitFinalApprove_Amount { get; set; }
        public Nullable<int> NotApprove_Amount { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<System.DateTime> LastUpdateTotalAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateSuccessFileAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateWaitFirstApproveAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateWaitFinalApprove_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateNotApproveAmount_Time { get; set; }
        public string Department_Paths { get; set; }
        public string Area_Paths { get; set; }
        public Nullable<int> RejectApprove_Amount { get; set; }
        public Nullable<System.DateTime> LastRejectApprove_Amount_Time { get; set; }
        public Nullable<int> SuggestApprove_Amount { get; set; }
        public Nullable<System.DateTime> LastSuggestApprove_Amount_Time { get; set; }
    
        public virtual Sys_Department Sys_Department { get; set; }
        public virtual Sys_Area sys_area { get; set; }
    }
}
