using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Areas.banhtrangtrunghieu.Models
{
    public class ProductsModel
    {
        public string NEWS_ID { get; set; }
        [DisplayName("Tiêu đề bài viết")]
        public string NEWS_TITLE { get; set; }
        [DisplayName("Mô tả")]
        public string NEWS_DESC { get; set; }
        public string NEWS_SEO_KEYWORD { get; set; }
        public string NEWS_SEO_DESC { get; set; }
        public string NEWS_SEO_URL { get; set; }
        public string NEWS_SEO_TITLE { get; set; }
        public string NEWS_URL { get; set; }
        public string NEWS_KEYWORD_ASCII { get; set; }
        public int? NEWS_ORDER { get; set; }
        [AllowHtml]
        public string POST_HTML { get; set; }
        public double? NEWS_PRICE1 { get; set; }
        public double? NEWS_PRICE2 { get; set; }
        public double? GIA { get; set; }
        public string THANH_PHAN { get; set; }
        public string BAO_QUAN { get; set; }
        public string NOTE { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string ANH { get; set; }
        [DisplayName("Ảnh sản phẩm")]
        public string LIST_ANH { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        [DisplayName("Update Date")]
        public DateTime? UPDATE_DATE { get; set; }
        [DisplayName("Create User")]
        public string CREATE_USER { get; set; }
        [DisplayName("Update User")]
        public string UPDATE_USER { get; set; }
        [DisplayName("State")]
        public bool ACTIVE { get; set; }
    }
}