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
    
    public partial class KOK_EMAIL
    {
        public int EMAIL_ID { get; set; }
        public Nullable<int> EMAIL_STT { get; set; }
        public string EMAIL_DESC { get; set; }
        public string EMAIL_FROM { get; set; }
        public string EMAIL_TO { get; set; }
        public string EMAIL_CC { get; set; }
        public string EMAIL_BCC { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string UPDATE_USER { get; set; }
    }
}
