using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Controllers
{
    public class DefaultPageController : Controller
    {
        // GET: DefaultPage
        public ActionResult Index()
        {
            return RedirectToRoute("banhtrangtrunghieu_default", new { controller = "Home", action = "Index" });
        }
    }
}