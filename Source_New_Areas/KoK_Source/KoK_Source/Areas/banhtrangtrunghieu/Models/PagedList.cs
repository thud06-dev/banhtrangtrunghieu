using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KoK_Source.Areas.banhtrangtrunghieu.Models
{
    public class PagedList
    {
        public int? numberPage { get; set; }
        public int? numberPost { get; set; }
        public int? currentPage { get; set; }
    }
}