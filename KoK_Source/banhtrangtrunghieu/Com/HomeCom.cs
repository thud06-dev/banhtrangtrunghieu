using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using banhtrangtrunghieu.Models;
using KOKService;
using System.Data;
using System.Linq;

namespace banhtrangtrunghieu.Com
{
    public class HomeCom
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        public List<HomeModel> GetBanners()
        {
            List<HomeModel> modal = new List<HomeModel>();
            var dt = _kokDataEntities.KOK_BANNER;
            return null;
        }
    }
}