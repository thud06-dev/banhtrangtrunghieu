using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Banner;
using KOKService;
using System.Data;
using System.Linq;
using KoK_Source.Common;

namespace KoK_Source.Com
{
    public class Default
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        private CommonCnv _commonCnv = new CommonCnv();
    }
}