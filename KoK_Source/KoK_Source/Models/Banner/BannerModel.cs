using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KOKService;

namespace KoK_Source.Models.Banner
{
    public class BannerModel
    {
        [DisplayName("ID")]
        public string BANNER_ID { get; set; }
        [DisplayName("NAME")]
        public string BANNER_NAME { get; set; }
        [DisplayName("Descreption")]
        public string BANNER_DESC { get; set; }
        [DisplayName("Url")]
        public string BANNER_FILE { get; set; }
        [DisplayName("Type")]
        public string BANNER_TYPE { get; set; }
        [DisplayName("Create Date")]
        public string CREATE_DATE { get; set; }
        [DisplayName("Update Date")]
        public string UPDATE_DATE { get; set; }
        [DisplayName("Create User")]
        public string CREATE_USER { get; set; }
        [DisplayName("Update User")]
        public string UPDATE_USER { get; set; }
        [DisplayName("State")]
        public bool ACTIVE { get; set; }
    }
}