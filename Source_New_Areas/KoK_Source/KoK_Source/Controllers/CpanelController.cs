using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Controllers
{
    public class CpanelController : Controller
    {
        // GET: Cpanel
        public ActionResult Index()
        {
            return RedirectToRoute("Admin_default", new { controller = "Manager", action = "Index" });
        }
    }
}