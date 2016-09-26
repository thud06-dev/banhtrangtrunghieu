using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Common;
using KoK_Source.Areas.Admin.Models.Account;
using KOKService;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private KOK_DATAEntities db = new KOK_DATAEntities();
        private AccountModel _account = new AccountModel();
        Sha1 _sha1 = new Sha1();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            var pass = _sha1.Mahoa(model.UserPass);
            if (ModelState.IsValid)
            {
                var dt = db.KOK_ACCOUNT.FirstOrDefault(u => u.UserName == model.UserName && u.UserPass == pass && u.ACTIVE == true);

                if (dt != null)
                {
                    Session["UserId"] = dt.ID.ToString();
                    Session["UserName"] = dt.UserName;
                    return RedirectToAction("Index","Account");
                }
                else
                {
                    ModelState.AddModelError("", "User or pass không đúng");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Session["UserId"] = dt.ID.ToString();
            //Session["UserName"] = dt.UserName;
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }

    }
}