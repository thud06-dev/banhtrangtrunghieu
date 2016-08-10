using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models.Banner;
using KOKService;
using KoK_Source.Com;
using KoK_Source.Common;
using KoK_Source.Models.Menu;

namespace KoK_Source.Controllers
{
    public class MenuController : Controller
    {
        private KOK_DATAEntities db = new KOK_DATAEntities();
        private MenuCom _MenuCom = new MenuCom();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Menu
        public ActionResult Index()
        {
            try
            {
                nav_Menu.menu_position = "nav_menu";
                List<MenuModels> models = new List<MenuModels>();
                models = _MenuCom.GetAllMenu();
                return View(models);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuModels model)
        {
            if (string.IsNullOrEmpty(model.MenuName))
            {
                ModelState.AddModelError("MENU_NAME", "chua nhap menu name");
            }
            if (string.IsNullOrEmpty(model.MenuLink))
            {
                ModelState.AddModelError("MENU_LINK", "chua nhap MENU_LINK");
            }
            if (string.IsNullOrEmpty(model.MenuRank))
            {
                ModelState.AddModelError("MENU_RANK", "chua nhap MENU_RANK");
            }
            if (string.IsNullOrEmpty(model.MenuParentId))
            {
                ModelState.AddModelError("MENU_PARENT_ID", "chua nhap MENU_PARENT_ID");
            }
            if (ModelState.IsValid)
            {
                model.CreateUser = " ";
                model.UpdateUser = " ";


                MENU dbMenu = new MENU
                {
                    MENU_NAME = model.MenuName,
                    MENU_LINK = model.MenuLink,
                    MENU_RANK = int.Parse(model.MenuRank),
                    MENU_PARENT_ID = int.Parse(model.MenuParentId),
                    MENU_ORDER = model.MenuOrder == null ? 1 : int.Parse(model.MenuOrder),
                    ACTIVE = model.Active,
                    CREATE_USER = model.CreateUser,
                    CREATE_DATE = DateTime.Now,
                    UPDATE_USER = model.UpdateUser,
                    UPDATE_DATE = DateTime.Now
                };
                try
                {
                    db.MENU.Add(dbMenu);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.Message);
                }
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU menu = db.MENU.Find(id);

            MenuModels modelMenu = new MenuModels
            {
                Id = menu.ID.ToString(),
                MenuName = menu.MENU_NAME,
                MenuLink = menu.MENU_LINK,
                MenuRank = menu.MENU_RANK.ToString(),
                MenuParentId = menu.MENU_PARENT_ID.ToString(),
            };


            if (modelMenu.Id == null)
            {
                return HttpNotFound();
            }
            return View(modelMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuModels model)
        {
            if (string.IsNullOrEmpty(model.MenuName))
            {
                ModelState.AddModelError("MENU_NAME", "chua nhap menu name");
            }
            if (string.IsNullOrEmpty(model.MenuLink))
            {
                ModelState.AddModelError("MENU_LINK", "chua nhap MENU_LINK");
            }
            if (string.IsNullOrEmpty(model.MenuRank))
            {
                ModelState.AddModelError("MENU_RANK", "chua nhap MENU_RANK");
            }
            if (string.IsNullOrEmpty(model.MenuParentId))
            {
                ModelState.AddModelError("MENU_PARENT_ID", "chua nhap MENU_PARENT_ID");
            }
            if (ModelState.IsValid)
            {
                model.CreateUser = " ";
                model.UpdateUser = " ";
                MENU dbMenu = new MENU
                {
                    ID = Int32.Parse(model.Id),
                    MENU_NAME = model.MenuName,
                    MENU_LINK = model.MenuLink,
                    MENU_RANK = int.Parse(model.MenuRank),
                    MENU_PARENT_ID = int.Parse(model.MenuParentId),
                    MENU_ORDER = model.MenuOrder == null ? 1 : int.Parse(model.MenuOrder),
                    ACTIVE = model.Active,
                    CREATE_USER = model.CreateUser,
                    CREATE_DATE = DateTime.Now,
                    UPDATE_USER = model.UpdateUser,
                    UPDATE_DATE = DateTime.Now
                };
                try
                {
                    db.Entry(dbMenu).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.Message);
                }
            }
            return View(model);

        }
    }
}