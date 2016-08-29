using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using banhtrangtrunghieu.Com;
using banhtrangtrunghieu.Models;


namespace banhtrangtrunghieu.Controllers
{
    public class HomeController : Controller
    {
        private HomeCom _homeCom = new HomeCom();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            HomeModel model= new HomeModel();
            model.ListNews = _homeCom.getListPost();
            model.ListProducts = _homeCom.getListProducts();
            return View(model);
        }
    }
}
