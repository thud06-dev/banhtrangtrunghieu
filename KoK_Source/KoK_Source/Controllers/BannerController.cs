using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Banner;
using KOKService;
using System.Data;
using System.IO;
using KoK_Source.Com;
using KoK_Source.Common;

namespace KoK_Source.Controllers
{
    public class BannerController : Controller
    {
        //private KOK_DATAEntities db = new KOK_DATAEntities();
        private BannerCom _bannerCom = new BannerCom();
        // GET: Banner
        public ActionResult Index()
        {
            try
            {
                nav_Menu.menu_position = "nav_banner";
                List<BannerModel> model = null;
                model = _bannerCom.GetKokBanners();
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }

        }
        public ActionResult Edit(BannerModel model)
        {
            try
            {
                nav_Menu.menu_position = "nav_banner";
                if (!string.IsNullOrEmpty(model.BANNER_ID))
                {
                    model = _bannerCom.GetBannerModelByID(int.Parse(model.BANNER_ID));
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
        [HttpPost]
        public ActionResult SaveData(FormCollection form)
        {
            try
            {
                BannerModel model = new BannerModel();
                model.BANNER_NAME = form["BANNER_NAME"].Trim();
                model.BANNER_DESC = form["BANNER_DESC"].Trim();
                model.BANNER_FILE = form["BANNER_FILE"].Trim();
                model.BANNER_ID = form["BANNER_ID"].Trim();
                if (Request.Files.Count > 0)
                {
                    string result = string.Empty;
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Server.MapPath("~/data/img/banner/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        file.SaveAs(path);
                        result = "~/data/img/banner/" + file.FileName;
                        model.BANNER_FILE = result;
                    }
                }
                if (!string.IsNullOrEmpty(model.BANNER_ID))
                    _bannerCom.UpdateBanner(model);
                else
                    _bannerCom.SaveBanner(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return Json(new { Msg = "Save fail!" });
            }

        }

        //public ActionResult AjaxUploadImg()
        //{
        //    try
        //    {
        //        string result = "";
        //        if (Request.Files.Count > 0)
        //        {
        //            var file = Request.Files[0];
        //            if (file != null && file.ContentLength > 0)
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var path = Server.MapPath("~/data/img/banner/");
        //                if (!Directory.Exists(path))
        //                {
        //                    Directory.CreateDirectory(path);
        //                }
        //                path = Path.Combine(path, fileName);
        //                if (System.IO.File.Exists(path))
        //                {
        //                    System.IO.File.Delete(path);
        //                }
        //                file.SaveAs(path);
        //                result = "~/data/img/banner/"+ file.FileName;
        //            }
        //        }
        //        return Json(new {Msg = result });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Msg = "" });
        //    }
        //}
        [HttpPost]
        public ActionResult AjaxUpdateActive(string id, string active)
        {
            try
            {
                BannerModel model = new BannerModel();
                model.BANNER_ID = id;
                model.ACTIVE = active != "0" ? true : false;
                _bannerCom.UpdateActive(model);
                return Json(new
                {
                    returnCode = 1
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    returnCode = 0
                });
            }
        }
        [HttpPost]
        public ActionResult AjaxDeleteBanner(string id)
        {
            try
            {
                BannerModel model = new BannerModel();
                model.BANNER_ID = id;
                _bannerCom.DeleteBannerByID(model);
                return Json(new
                {
                    returnCode = 1
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    returnCode = 0
                });
            }
        }
    }
}