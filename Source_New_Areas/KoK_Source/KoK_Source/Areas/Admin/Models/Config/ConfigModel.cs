using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using KoK_Source.Areas.Admin.Models.Account;
using KoK_Source.Common;
using KOKService;

namespace KoK_Source.Areas.Admin.Models.Config
{
    public class ConfigModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tiêu đề website")]
        public string ConfigTitle { get; set; }

        [DisplayName("Keyword")]
        public string ConfigKeyword { get; set; }

        [DisplayName("Mô tả website")]
        public string ConfigDecription { get; set; }

        [DisplayName("Lượt truy cập")]
        public int ConfigHitCounter { get; set; }

        [DisplayName("Icon")]
        public string ConfigFavicon { get; set; }

        //public int ConfigOrder { get; set; }

        //public string ConfigLanguage { get; set; }
        [DisplayName("Trang Facebook")]
        public string ConfigField1 { get; set; }
        [DisplayName("Số điện thoại")]
        public string ConfigField2 { get; set; }
        [DisplayName("Địa chỉ liên hệ")]
        public string ConfigField3 { get; set; }
        [DisplayName("Email liên hệ")]
        public string ConfigField4 { get; set; }
        [DisplayName("Màu background")]
        public string ConfigField5 { get; set; }
        [DisplayName("Logo Website")]
        public string CONFIG_KEYWORD_EN { get; set; }
        [DisplayName("Banner Website")]
        public string CONFIG_DESCRIPTION_EN { get; set; }
        [DisplayName("State")]
        public bool Active { get; set; }

        [DisplayName("Create_Date")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate { get; set; }

        [DisplayName("Create User")]
        public string CreateUser { get; set; }

        [DisplayName("Update User")]
        public string UpdateUser { get; set; }


        private KOK_DATAEntities db = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();

        public ConfigModel GetConfig()
        {
            var data = db.KOK_CONFIG.FirstOrDefault();
            ConfigModel config = new ConfigModel();
            if (data != null)
            {
                config.Id = data.CONFIG_ID;
                config.ConfigTitle = data.CONFIG_TITLE;
                config.ConfigKeyword = data.CONFIG_KEYWORD;
                config.ConfigDecription = data.CONFIG_DESCRIPTION;
                //config.ConfigHitCounter = data.CONFIG_HITCOUNTER.Value;
                config.ConfigFavicon = data.CONFIG_FAVICON;
                config.ConfigField1 = data.CONFIG_FIELD1;
                config.ConfigField2 = data.CONFIG_FIELD2;
                config.ConfigField3 = data.CONFIG_FIELD3;
                config.ConfigField4 = data.CONFIG_FIELD4;
                config.ConfigField5 = data.CONFIG_FIELD5;
                config.CONFIG_KEYWORD_EN = data.CONFIG_KEYWORD_EN;
                config.CONFIG_DESCRIPTION_EN = data.CONFIG_DESCRIPTION_EN;
                config.CreateDate = data.CREATE_DATE;
                config.UpdateDate = data.UPDATE_DATE;
                config.CreateUser = data.CREATE_USER;
                config.UpdateUser = data.UPDATE_USER;
            }
            
            Console.WriteLine(config);
            return config;
        }

        public ConfigModel GetConfigById(int? id)
        {
            var dt = db.KOK_CONFIG.FirstOrDefault(x => x.CONFIG_ID == id);
            ConfigModel config = new ConfigModel();
            if (dt != null)
            {
                config.Id = dt.CONFIG_ID;
                config.ConfigTitle = dt.CONFIG_TITLE;
                config.ConfigKeyword = dt.CONFIG_KEYWORD;
                config.ConfigDecription = dt.CONFIG_DESCRIPTION;
                config.Active = _commonCnv.CnvBool(dt.ACTIVE);
            }
            return config;
        }

       
    }
}