using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Models.Account;
using KoK_Source.Areas.Admin.Models.Config;
using KOKService;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class ConfigController : BaseController
    {
        private KOK_DATAEntities db = new KOK_DATAEntities();
        private ConfigModel _config = new ConfigModel();

        // GET: Admin/Config
        public ActionResult Index()
        {
            ConfigModel ls = _config.GetConfig();
            return View(ls);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConfigModel model)
        {
            if (ModelState.IsValid)
            {
                
                KOK_CONFIG config = new KOK_CONFIG
                {
                    CONFIG_TITLE = model.ConfigTitle,
                    CONFIG_KEYWORD = model.ConfigKeyword,
                    CONFIG_DESCRIPTION = model.ConfigDecription,
                    CONFIG_HITCOUNTER = 0,
                    //CONFIG_FAVICON = model.ConfigFavicon
                };
                try
                {
                    db.KOK_CONFIG.Add(config);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigModel config = _config.GetConfigById(id);
            return View(config);
        }

        [HttpPost]
        public ActionResult Edit(ConfigModel model)
        {
            if (ModelState.IsValid)
            {
                //var config = db.KOK_CONFIG.FirstOrDefault(x => x.CONFIG_ID == model.Id);
               

                try
                {
                    var config = new KOK_CONFIG();
                    config = db.KOK_CONFIG.FirstOrDefault();
                    if (config == null)
                    {
                        config = new KOK_CONFIG();
                        config.CONFIG_TITLE = model.ConfigTitle;
                        config.CONFIG_KEYWORD = model.ConfigKeyword;
                        config.CONFIG_DESCRIPTION = model.ConfigDecription;
                        config.CONFIG_FIELD1 = model.ConfigField1;
                        config.CONFIG_FIELD2 = model.ConfigField2;
                        config.CONFIG_FIELD3 = model.ConfigField3;
                        config.CONFIG_FIELD4 = model.ConfigField4;
                        config.CONFIG_FIELD5 = model.ConfigField5;
                        config.CONFIG_KEYWORD_EN = "~" + model.CONFIG_KEYWORD_EN;
                        config.CONFIG_DESCRIPTION_EN = "~" + model.CONFIG_DESCRIPTION_EN;
                        //db.Entry(config).State = EntityState.Modified;
                        db.KOK_CONFIG.Add(config);
                    }
                    else
                    {
                        config.CONFIG_TITLE = model.ConfigTitle;
                        config.CONFIG_KEYWORD = model.ConfigKeyword;
                        config.CONFIG_DESCRIPTION = model.ConfigDecription;
                        config.CONFIG_FIELD1 = model.ConfigField1;
                        config.CONFIG_FIELD2 = model.ConfigField2;
                        config.CONFIG_FIELD3 = model.ConfigField3;
                        config.CONFIG_FIELD4 = model.ConfigField4;
                        config.CONFIG_FIELD5 = model.ConfigField5;
                        config.CONFIG_KEYWORD_EN = model.CONFIG_KEYWORD_EN;
                        config.CONFIG_DESCRIPTION_EN = model.CONFIG_DESCRIPTION_EN;
                        //db.Entry(config).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigModel config = _config.GetConfigById(id);
            return View(config);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            KOK_CONFIG acc = db.KOK_CONFIG.Find(id);
            db.KOK_CONFIG.Remove(acc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}