using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Com;
using KoK_Source.Models;


namespace KoK_Source.Controllers
{
    public class HomeController : Controller
    {
        private HomeCom _homeCom = new HomeCom();
        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Home Page";
                HomeModel model = new HomeModel();
                model.ListNews = _homeCom.getListPost();
                model.ListProducts = _homeCom.getListProducts();
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
    }
}
