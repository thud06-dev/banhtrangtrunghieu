using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KoK_Source.Areas.Admin.Models.Menu;
using KoK_Source.Areas.Admin.Models.File;

namespace KoK_Source.Areas.Admin.Models.Products
{
    public class ProductsModel
    {
        public string NEWS_ID { get; set; }
        public int NEWS_TYPE { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string NEWS_TITLE { get; set; }
        [DisplayName("Mô tả ngắn")]
        public string NEWS_DESC { get; set; }
        [DisplayName("SEO KEYWORD")]
        public string NEWS_SEO_KEYWORD { get; set; }
        [DisplayName("SEO DESCRIPTION")]
        public string NEWS_SEO_DESC { get; set; }
        [DisplayName("SEO URL")]
        public string NEWS_SEO_URL { get; set; }
        [DisplayName("SEO TITLE")]
        public string NEWS_SEO_TITLE { get; set; }
        [DisplayName("Đường dẫn")]
        public string NEWS_URL { get; set; }
        public string NEWS_KEYWORD_ASCII { get; set; }
        [DisplayName("Thứ tự")]
        public int? NEWS_ORDER { get; set; }
        [AllowHtml]
        [DisplayName("Nội dung")]
        public string POST_HTML { get; set; }
        public double? NEWS_PRICE1 { get; set; }
        public double? NEWS_PRICE2 { get; set; }
        [DisplayName("Giá")]
        public double? GIA { get; set; }
        [DisplayName("Thành phần")]
        public string THANH_PHAN { get; set; }
        [DisplayName("Bảo quản")]
        public string BAO_QUAN { get; set; }
        [DisplayName("Ghi chú")]
        public string NOTE { get; set; }
        [DisplayName("Ảnh đại diện")]
        public string ANH { get; set; }
        [DisplayName("Ảnh sản phẩm")]
        public string LIST_ANH { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? CREATE_DATE { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? UPDATE_DATE { get; set; }
        [DisplayName("Người tạo")]
        public string CREATE_USER { get; set; }
        [DisplayName("Người cập nhật")]
        public string UPDATE_USER { get; set; }
        [DisplayName("Ẩn")]
        public bool ACTIVE { get; set; }
        public List<MenuModels> listMenu;
        public List<FileModel> arrMenu;
    }
}