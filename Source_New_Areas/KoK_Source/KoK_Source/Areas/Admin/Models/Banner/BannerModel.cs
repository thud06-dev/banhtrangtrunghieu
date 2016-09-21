using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KOKService;

namespace KoK_Source.Areas.Admin.Models.Banner
{
    public class BannerModel
    {
        [DisplayName("ID")]
        public string BANNER_ID { get; set; }
        [DisplayName("Tên")]
        public string BANNER_NAME { get; set; }
        [DisplayName("Mô tả")]
        public string BANNER_DESC { get; set; }
        [DisplayName("Đường dẫn")]
        public string BANNER_FILE { get; set; }
        [DisplayName("Loại")]
        public string BANNER_TYPE { get; set; }
        [DisplayName("Ngày tạo")]
        public string CREATE_DATE { get; set; }
        [DisplayName("Ngày cập nhật")]
        public string UPDATE_DATE { get; set; }
        [DisplayName("Người tạo")]
        public string CREATE_USER { get; set; }
        [DisplayName("Người cập nhật")]
        public string UPDATE_USER { get; set; }
        [DisplayName("Hiển thị")]
        public bool ACTIVE { get; set; }
        [DisplayName("Liên kết")]
        public string BANNER_LINK { get; set; }
    }
}