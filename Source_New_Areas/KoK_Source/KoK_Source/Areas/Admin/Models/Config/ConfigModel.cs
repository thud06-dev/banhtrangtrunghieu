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

        [DisplayName("Tiêu đề")]
        public string ConfigTitle { get; set; }

        [DisplayName("Tiêu đề")]
        public string ConfigKeyword { get; set; }

        [DisplayName("Mô tả website")]
        public string ConfigDecription { get; set; }

        [DisplayName("Lượt truy cập")]
        public int ConfigHitCounter { get; set; }

        [DisplayName("Icon")]
        public string ConfigFavicon { get; set; }

        //public int ConfigOrder { get; set; }

        //public string ConfigLanguage { get; set; }

        //public string ConfigField1 { get; set; }

        //public string ConfigField2 { get; set; }

        //public string ConfigField3 { get; set; }

        //public string ConfigField4 { get; set; }

        //public string ConfigFielf5 { get; set; }

        [DisplayName("State")]
        public bool Active { get; set; }

        [DisplayName("Create_Date")]
        public string CreateDate { get; set; }

        [DisplayName("Update Date")]
        public string UpdateDate { get; set; }

        [DisplayName("Create User")]
        public string CreateUser { get; set; }

        [DisplayName("Update User")]
        public string UpdateUser { get; set; }


        private KOK_DATAEntities db = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();

        public List<ConfigModel> GetAllConfig()
        {
            var data = db.KOK_CONFIG.ToList();
            List<ConfigModel> config = new List<ConfigModel>();
            foreach (var item in data)
            {
                config.Add(new ConfigModel
                {
                    Id = item.CONFIG_ID,
                    ConfigTitle = item.CONFIG_TITLE ?? string.Empty,
                    ConfigKeyword = item.CONFIG_KEYWORD ?? string.Empty,
                    ConfigDecription = item.CONFIG_DESCRIPTION ?? string.Empty,
                    ConfigHitCounter = item.CONFIG_HITCOUNTER ?? 0,
                    ConfigFavicon = item.CONFIG_FAVICON ?? string.Empty,
                    CreateDate = item.CREATE_DATE?.ToString() ?? string.Empty,
                    CreateUser = item.CREATE_USER ?? string.Empty,
                    UpdateDate = item.UPDATE_DATE?.ToString() ?? string.Empty,
                    UpdateUser = item.UPDATE_USER ?? string.Empty,
                    Active = _commonCnv.CnvBool(item.ACTIVE)
                });
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