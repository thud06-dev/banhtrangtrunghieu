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
        [DisplayName("Name")]
        public string MenuName { get; set; }
        [DisplayName("Link")]
        public string MenuLink { get; set; }
        [DisplayName("Rank")]
        public string MenuRank { get; set; }
        [DisplayName("Parent ID")]
        public string MenuParentId { get; set; }
        [DisplayName("Order")]
        public string MenuOrder { get; set; }
        [DisplayName("Create Date")]
        public string CreateDate { get; set; }
        [DisplayName("Update Date")]
        public string UpdateDate { get; set; }
        [DisplayName("Create User")]
        public string CreateUser { get; set; }
        [DisplayName("Update_User")]
        public string UpdateUser { get; set; }
        [DisplayName("State")]
        public bool Active { get; set; }

    }
}