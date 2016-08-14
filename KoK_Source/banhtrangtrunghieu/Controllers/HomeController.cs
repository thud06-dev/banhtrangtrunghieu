using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Banner;
using KOKService;
using System.Data;
using System.IO;
using KoK_Source.Com;
using KoK_Source.Common;
namespace banhtrangtrunghieu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
