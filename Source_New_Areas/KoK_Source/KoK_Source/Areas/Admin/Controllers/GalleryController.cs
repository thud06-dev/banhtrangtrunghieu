using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Com;
using KoK_Source.Areas.Admin.Models.Banner;
using KoK_Source.Common;
using System.IO;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        private GalleryCom _galleryCom = new GalleryCom();
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            try
            {
                nav_Menu.menu_position = "nav_banner";
                List<BannerModel> model = null;
                model = _galleryCom.getAll();
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message });
            }
        }
        public ActionResult Edit(BannerModel model)
        {
            try
            {
                nav_Menu.menu_position = "nav_banner";
                if (!string.IsNullOrEmpty(model.BANNER_ID))
                {
                    model = _galleryCom.GetModelByID(int.Parse(model.BANNER_ID));
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message });
            }
        }
        [HttpPost]
        public void SaveData()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var path = Server.MapPath("~/data/img/gallery/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        BannerModel model = new BannerModel();
                        HttpPostedFileBase file = Request.Files[i];
                        string result = string.Empty;
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);

                            var pathfull = Path.Combine(path, fileName);
                            //delete file exist
                            if (System.IO.File.Exists(pathfull))
                            {
                                System.IO.File.Delete(pathfull);
                            }
                            result = "~/data/img/gallery/" + file.FileName;
                            file.SaveAs(pathfull);
                            model.BANNER_NAME = file.FileName;
                            model.BANNER_FILE = result;
                            model.BANNER_DESC = file.ContentLength.ToString();
                            _galleryCom.Save(model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }
        [HttpPost]
        public ActionResult AjaxDelete(string id)
        {
            try
            {
                var dt_old = _galleryCom.GetModelByID(int.Parse(id));
                var pathfull = Server.MapPath(dt_old.BANNER_FILE);
                if (System.IO.File.Exists(pathfull))
                {
                    System.IO.File.Delete(pathfull);
                }
                _galleryCom.DeleteByID(id);
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