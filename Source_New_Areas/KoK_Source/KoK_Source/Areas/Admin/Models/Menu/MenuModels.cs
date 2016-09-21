using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace KoK_Source.Areas.Admin.Models.Menu
{
    public class MenuModels
    {
        [DisplayName("ID")]
        public string Id { get; set; }
        [DisplayName("Tên")]
        public string MenuName { get; set; }
        [DisplayName("Liên kết")]
        public string MenuLink { get; set; }
        [DisplayName("Rank")]
        public string MenuRank { get; set; }
        [DisplayName("Menu cha")]
        public string MenuParentId { get; set; }
        [DisplayName("Thứ tự")]
        public string MenuOrder { get; set; }
        [DisplayName("Ngày tạo")]
        public string CreateDate { get; set; }
        [DisplayName("Ngày cập nhật")]
        public string UpdateDate { get; set; }
        [DisplayName("Người tạo")]
        public string CreateUser { get; set; }
        [DisplayName("Người cập nhật")]
        public string UpdateUser { get; set; }
        [DisplayName("Hiển thị")]
        public bool Active { get; set; }
        [DisplayName("Loại Menu")]
        public int? CAT_TYPE { get; set; }

    }
}