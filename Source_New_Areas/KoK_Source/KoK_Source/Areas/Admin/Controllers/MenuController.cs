﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Models.Banner;
using KOKService;
using KoK_Source.Areas.Admin.Com;
using KoK_Source.Common;
using KoK_Source.Areas.Admin.Models.Menu;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class MenuController : BaseController
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
                List<MenuModels> lisMenuModels = new List<MenuModels>();
                lisMenuModels = _MenuCom.GetAllMenu();
                return View(lisMenuModels);
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
            var a = model;

            if (string.IsNullOrEmpty(model.MenuName))
            {
                ModelState.AddModelError("MENU_NAME", "chua nhap menu name");
            }
            if (string.IsNullOrEmpty(model.MenuLink))
            {
                ModelState.AddModelError("MENU_LINK", "chua nhap MENU_LINK");
            }
         

            if (ModelState.IsValid)
            {
                model.CreateUser = " ";
                model.UpdateUser = " ";

                KOK_CATEGORIES cat = new KOK_CATEGORIES
                {
                    CAT_NAME = model.MenuName,
                    CAT_URL =  model.MenuLink,
                    CAT_RANK = 1,
                    CAT_PARENT_ID = 0,
                    CAT_ORDER = 0,
                    ACTIVE = model.Active,
                    CAT_TYPE = model.CAT_TYPE,
                    CREATE_USER = model.CreateUser,
                    CREATE_DATE = DateTime.Now,
                    UPDATE_USER = model.UpdateUser,
                    UPDATE_DATE = DateTime.Now
                };
                try
                {
                    db.KOK_CATEGORIES.Add(cat);
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
            KOK_CATEGORIES categories = db.KOK_CATEGORIES.Find(id);

            MenuModels modelMenu = new MenuModels
            {
                Id = categories.CAT_ID.ToString(),
                MenuName = categories.CAT_NAME,
                MenuLink = categories.CAT_URL,
                CAT_TYPE = categories.CAT_TYPE
                //MenuRank = categories.CAT_RANK.ToString(),
                //MenuParentId = categories.CAT_PARENT_ID.ToString(),
                //MenuOrder= categories.CAT_ORDER?.ToString()
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
            //if (string.IsNullOrEmpty(model.MenuRank))
            //{
            //    ModelState.AddModelError("MENU_RANK", "chua nhap MENU_RANK");
            //}
            //if (string.IsNullOrEmpty(model.MenuParentId))
            //{
            //    ModelState.AddModelError("MENU_PARENT_ID", "chua nhap MENU_PARENT_ID");
            //}
            if (ModelState.IsValid)
            {
                model.CreateUser = " ";
                model.UpdateUser = " ";

                KOK_CATEGORIES categories = db.KOK_CATEGORIES.Find(Int32.Parse(model.Id));
                categories.CAT_NAME = model.MenuName;
                categories.CAT_URL = model.MenuLink;
                categories.ACTIVE = model.Active;
                //categories.CAT_ORDER = 0;
                //categories.CAT_RANK = 1;
                //categories.CAT_PARENT_ID = 0;
                categories.CAT_TYPE = model.CAT_TYPE;
                categories.CREATE_USER = model.CreateUser;
                categories.CREATE_DATE = DateTime.Now;
                categories.UPDATE_USER = model.UpdateUser;
                categories.UPDATE_DATE = DateTime.Now;

                try
                {
                    db.Entry(categories).State = EntityState.Modified;
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

        [HttpPost]
        public void Saverank(string ar)
        {

            var array = JArray.Parse(ar);//JObject.Parse(ar);
            List<MenuModels> listmenu = new List<MenuModels>();
            listmenu = _MenuCom.GetAllMenu();
            var pos = 0;
            foreach (var item in array)
            {
                var obj = listmenu.Where(t => t.Id == item["id"].ToString()).ToList();
                obj[0].MenuRank = "1";
                obj[0].MenuParentId = "0";
                obj[0].MenuOrder = pos.ToString();
                KOK_CATEGORIES dbCategorys = new KOK_CATEGORIES
                {
                    CAT_ID = Int32.Parse(obj[0].Id),
                    CAT_NAME = obj[0].MenuName,
                    CAT_URL = obj[0].MenuLink,
                    CAT_RANK = int.Parse(obj[0].MenuRank),
                    CAT_PARENT_ID = int.Parse(obj[0].MenuParentId),
                    CAT_ORDER = obj[0].MenuOrder == null ? 1 : int.Parse(obj[0].MenuOrder),
                    ACTIVE = obj[0].Active,
                    CAT_TYPE = obj[0].CAT_TYPE,
                    CREATE_USER = obj[0].CreateUser,
                    CREATE_DATE = DateTime.Now,
                    UPDATE_USER = obj[0].UpdateUser,
                    UPDATE_DATE = DateTime.Now
                };
                try
                {
                    db.Entry(dbCategorys).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ec)
                {
                    Console.WriteLine(ec.Message);
                }
                pos++;
                if (item["children"] != null)
                {
                    foreach (var childItem1 in item["children"])
                    {
                        obj = listmenu.Where(t => t.Id == childItem1["id"].ToString()).ToList();
                        obj[0].MenuRank = "2";
                        obj[0].MenuOrder = pos.ToString();
                        obj[0].MenuParentId = (item["id"].ToString());
                        dbCategorys = new KOK_CATEGORIES
                        {
                            CAT_ID = Int32.Parse(obj[0].Id),
                            CAT_NAME = obj[0].MenuName,
                            CAT_URL = obj[0].MenuLink,
                            CAT_RANK = int.Parse(obj[0].MenuRank),
                            CAT_PARENT_ID = int.Parse(obj[0].MenuParentId),
                            CAT_ORDER = obj[0].MenuOrder == null ? 1 : int.Parse(obj[0].MenuOrder),
                            ACTIVE = obj[0].Active,
                            CAT_TYPE = obj[0].CAT_TYPE,
                            CREATE_USER = obj[0].CreateUser,
                            CREATE_DATE = DateTime.Now,
                            UPDATE_USER = obj[0].UpdateUser,
                            UPDATE_DATE = DateTime.Now
                        };
                        try
                        {
                            db.Entry(dbCategorys).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ec)
                        {
                            Console.WriteLine(ec.Message);
                        }
                        pos++;
                        if (childItem1["children"] != null)
                        {
                            foreach (var childitem2 in childItem1["children"])
                            {
                                obj = listmenu.Where(t => t.Id == childitem2["id"].ToString()).ToList();
                                obj[0].MenuRank = "3";
                                obj[0].MenuOrder = pos.ToString();
                                obj[0].MenuParentId = childItem1["id"].ToString();
                                dbCategorys = new KOK_CATEGORIES
                                {
                                    CAT_ID = Int32.Parse(obj[0].Id),
                                    CAT_NAME = obj[0].MenuName,
                                    CAT_URL = obj[0].MenuLink,
                                    CAT_RANK = int.Parse(obj[0].MenuRank),
                                    CAT_PARENT_ID = int.Parse(obj[0].MenuParentId),
                                    CAT_ORDER = obj[0].MenuOrder == null ? 1 : int.Parse(obj[0].MenuOrder),
                                    ACTIVE = obj[0].Active,
                                    CAT_TYPE = obj[0].CAT_TYPE,
                                    CREATE_USER = obj[0].CreateUser,
                                    CREATE_DATE = DateTime.Now,
                                    UPDATE_USER = obj[0].UpdateUser,
                                    UPDATE_DATE = DateTime.Now
                                };
                                try
                                {
                                    db.Entry(dbCategorys).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                                catch (Exception ec)
                                {
                                    Console.WriteLine(ec.Message);
                                }
                                pos++;
                            }
                        }
                    }
                        
                    
                }
            }
        }
    }
}