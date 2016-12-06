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
    
    public partial class Hash_Collect_Statistics : BaseModel
    {
        public Hash_Collect_Statistics()
        {
            this.hash_collect_statistics_details = new HashSet<Hash_Collect_Statistics_Details>();
        }
    
    	[EntityPrimKey]
        public string Collect_Statistics_ID { get; set; }
        public Nullable<int> Collect_Set_Key_Amount { get; set; }
        public Nullable<int> Collect_Cell_Phone_Amount { get; set; }
        public Nullable<int> Collect_Comuputer_Amount { get; set; }
        public Nullable<int> Collect_Storage_Amount { get; set; }
        public Nullable<int> Collect_Other_Amount { get; set; }
        public Nullable<int> Levels_First_Amount { get; set; }
        public Nullable<int> Levels_Second_Amount { get; set; }
        public Nullable<int> Levels_Third_Amount { get; set; }
        public Nullable<int> Levels_Forth_Amount { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<System.DateTime> LastUpdateSetKeyAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateCollectCellPhoneAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateCollectComputerAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateCollectStorageAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateCollectOtherAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateLevelFirstAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateLevelSecondAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateLevelThirdAmount_Time { get; set; }
        public Nullable<System.DateTime> LastUpdateLevelForthAmount_Time { get; set; }
        public Nullable<int> DongYuyun_Amount { get; set; }
        public Nullable<int> WuYuyun_Amount { get; set; }
        public Nullable<int> ShiWeiHui_Amount { get; set; }
        public Nullable<int> ISIS_Amount { get; set; }
        public Nullable<int> Other_Amount { get; set; }
        public string Department_Paths { get; set; }
        public string Area_Paths { get; set; }
        public Nullable<int> Audio_Amount { get; set; }
        public Nullable<int> Video_Amount { get; set; }
        public Nullable<int> Ebook_Amount { get; set; }
        public Nullable<int> Application_Amount { get; set; }
        public Nullable<int> Image_Amount { get; set; }
        public Nullable<int> OtherType_Amount { get; set; }
    
        public virtual Sys_Department sys_department { get; set; }
        public virtual Sys_Area sys_area { get; set; }
        public virtual ICollection<Hash_Collect_Statistics_Details> hash_collect_statistics_details { get; set; }
    }
}