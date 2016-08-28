using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using banhtrangtrunghieu.Models;

namespace banhtrangtrunghieu.Models
{
    public class HomeModel
    {
        public List<NewsModel> ListNews;
        public NewsModel News;
        public string a { get; set; }
    }
}