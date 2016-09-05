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
    
    public partial class KOK_NEWS
    {
        public KOK_NEWS()
        {
            this.KOK_NEWS_ATT = new HashSet<KOK_NEWS_ATT>();
            this.KOK_NEWS_IMAGE = new HashSet<KOK_NEWS_IMAGE>();
        }
    
        public int NEWS_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public string NEWS_CODE { get; set; }
        public string NEWS_TITLE { get; set; }
        public string NEWS_DESC { get; set; }
        public string NEWS_SEO_KEYWORD { get; set; }
        public string NEWS_SEO_DESC { get; set; }
        public string NEWS_SEO_URL { get; set; }
        public string NEWS_SEO_TITLE { get; set; }
        public string NEWS_FILEHTML { get; set; }
        public Nullable<System.DateTime> NEWS_PUBLISHDATE { get; set; }
        public Nullable<System.DateTime> NEWS_UPDATE { get; set; }
        public string NEWS_URL { get; set; }
        public string NEWS_TARGET { get; set; }
        public Nullable<int> NEWS_SHOWTYPE { get; set; }
        public Nullable<int> NEWS_SHOWINDETAIL { get; set; }
        public Nullable<int> NEWS_FEEDBACKTYPE { get; set; }
        public Nullable<int> NEWS_TYPE { get; set; }
        public Nullable<int> NEWS_LANGUAGE { get; set; }
        public Nullable<int> NEWS_PRINTTYPE { get; set; }
        public Nullable<int> NEWS_COUNT { get; set; }
        public Nullable<int> NEWS_PERIOD { get; set; }
        public Nullable<int> NEWS_ORDER_PERIOD { get; set; }
        public Nullable<int> NEWS_ORDER { get; set; }
        public string NEWS_IMAGE1 { get; set; }
        public string NEWS_IMAGE2 { get; set; }
        public string NEWS_IMAGE3 { get; set; }
        public string NEWS_IMAGE4 { get; set; }
        public string NEWS_IMAGE5 { get; set; }
        public string NEWS_FIELD1 { get; set; }
        public string NEWS_FIELD2 { get; set; }
        public string NEWS_FIELD3 { get; set; }
        public string NEWS_FIELD4 { get; set; }
        public string NEWS_FIELD5 { get; set; }
        public Nullable<int> NEWS_SENDEMAIL { get; set; }
        public Nullable<System.DateTime> NEWS_SENDDATE { get; set; }
        public Nullable<decimal> NEWS_PRICE1 { get; set; }
        public Nullable<decimal> NEWS_PRICE2 { get; set; }
        public Nullable<decimal> NEWS_PRICE3 { get; set; }
        public Nullable<int> UNIT_ID1 { get; set; }
        public Nullable<int> UNIT_ID2 { get; set; }
        public Nullable<int> UNIT_ID3 { get; set; }
        public string NEWS_PACKAGE { get; set; }
        public string NEWS_KEYWORD_ASCII { get; set; }
        public string NEWS_VIDEO_URL { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string UPDATE_USER { get; set; }
        public string POST_HTML { get; set; }
        public string ANH { get; set; }
    
        public virtual ICollection<KOK_NEWS_ATT> KOK_NEWS_ATT { get; set; }
        public virtual ICollection<KOK_NEWS_IMAGE> KOK_NEWS_IMAGE { get; set; }
    }
}