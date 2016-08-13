﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KOKService;

namespace KoK_Source.Models.Post
{
    public class PostModel
    {
        public string NEWS_ID { get; set; }
        public string NEWS_TITLE { get; set; }
        public string NEWS_DESC { get; set; }
        public string NEWS_SEO_KEYWORD { get; set; }
        public string NEWS_SEO_DESC { get; set; }
        public string NEWS_SEO_URL { get; set; }
        public string NEWS_SEO_TITLE { get; set; }

        public int NEWS_ORDER { get; set; }

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