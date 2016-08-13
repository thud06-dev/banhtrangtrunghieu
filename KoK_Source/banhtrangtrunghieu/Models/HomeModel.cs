using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KOKService;

namespace banhtrangtrunghieu.Models
{
    public class HomeModel
    {
        public string BANNER_DESC { get; set; }
        public string BANNER_FILE { get; set; }
    }
}