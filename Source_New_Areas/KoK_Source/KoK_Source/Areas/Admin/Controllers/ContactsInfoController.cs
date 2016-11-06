using KoK_Source.Areas.Admin.Com;
using KoK_Source.Areas.Admin.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class ContactsInfoController : Controller
    {
        private ContactCom _contactsCom = new ContactCom();
        // GET: Admin/ContactsInfo
        public ActionResult Index()
        {
            List<ProductsModel> model = null;
            model = _contactsCom.GetAllPost();
            return View(model);
        }
    }
}