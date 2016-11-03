using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using KoK_Source.Areas.Admin.Com;
using KoK_Source.Common;
using KoK_Source.Areas.Admin.Models.Account;
using KOKService;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private KOK_DATAEntities db = new KOK_DATAEntities();
        private AccountModel _account = new AccountModel();
        Sha1 _sha1 = new Sha1();

        // GET: Account
        public ActionResult Index()
        {
            List<AccountModel> ls = _account.GetAllAccount();
            return View(ls);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                //Check tài khoản đã có hay chưa
                var dt = _account.CheckAccount(model.UserName);
                if (dt != null)
                {
                    ModelState.AddModelError("UserName", "Tài khoản đã tồn tại");
                }
                else
                {
                    KOK_ACCOUNT acc = new KOK_ACCOUNT
                    {
                        UserName = model.UserName,
                        UserPass = _sha1.Mahoa(model.UserPass),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        ACTIVE = model.Active,
                        CREATE_USER = "addmin",
                        CREATE_DATE = DateTime.Now
                    };
                    try
                    {
                        db.KOK_ACCOUNT.Add(acc);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = _account.GetAccountById(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Edit(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var account = db.KOK_ACCOUNT.FirstOrDefault(x => x.ID == model.Id);
                if (account != null)
                {
                    account.UserName = model.UserName;
                    account.FirstName = model.FirstName;
                    account.LastName = model.LastName;
                    account.UserPass = _sha1.Mahoa(model.UserPass);
                    account.UPDATE_USER = "admin";
                    account.UPDATE_DATE = DateTime.Now;
                }

                try
                {
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }


        public ActionResult ResetPass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = _account.GetAccountById(id);
            account.UserPass = _sha1.Mahoa("123456");
            try
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountModel account = _account.GetAccountById(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            KOK_ACCOUNT acc =  db.KOK_ACCOUNT.Find(id);
            db.KOK_ACCOUNT.Remove(acc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Login(AccountModel model)
        //{
        //    var pass = _sha1.Mahoa(model.UserPass);
        //    if (ModelState.IsValid)
        //    {
        //        var dt = db.KOK_ACCOUNT.FirstOrDefault(u => u.UserName == model.UserName && u.UserPass == pass && u.ACTIVE == true);

        //        if (dt != null)
        //        {
        //            Session["UserId"] = dt.ID.ToString();
        //            Session["UserName"] = dt.UserName;
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "User or pass không đúng");
        //        }
        //    }
        //    return View();
        //}
    }
}