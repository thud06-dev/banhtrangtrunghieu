//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KOKService
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENU
    {
        public int ID { get; set; }
        public string MENU_NAME { get; set; }
        public string MENU_LINK { get; set; }
        public Nullable<int> MENU_RANK { get; set; }
        public Nullable<int> MENU_PARENT_ID { get; set; }
        public Nullable<int> MENU_ORDER { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string UPDATE_USER { get; set; }
    }
}
