using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Models;
using KoK_Source.Areas.Admin.Models.Banner;
using KOKService;
using System.Data;
using System.IO;
using KoK_Source.Areas.Admin.Com;
using KoK_Source.Common;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}