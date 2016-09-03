using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KoK_Source.Models.Products
{
    public class ProductsModel
    {
        public string NEWS_ID { get; set; }
        [DisplayName("TÊN SẢN PHẨM")]
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
        public float NEWS_PRICE1 { get; set; }
        public float NEWS_PRICE2 { get; set; }
        public float GIA { get; set; }
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