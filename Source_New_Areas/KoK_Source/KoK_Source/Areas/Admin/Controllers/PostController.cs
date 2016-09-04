using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.Admin.Models;
using KoK_Source.Areas.Admin.Models.Products;
using System.Data;
using System.IO;
using KoK_Source.Areas.Admin.Com;
using KoK_Source.Common;
using KoK_Source.Areas.Admin.Models.File;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private PostCom _postCom = new PostCom();
        private MenuCom _menuCom = new MenuCom();
        // GET: Post
        public ActionResult Index()
        {
            try
            {
                List<ProductsModel> model = null;
                model = _postCom.GetAllPost();
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
        public ActionResult Edit(ProductsModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.NEWS_ID))
                {
                    model = _postCom.GetPostByID(int.Parse(model.NEWS_ID));
                    model.arrMenu = _postCom.getMenuOfPost(model.NEWS_ID);
                }
                model.listMenu = _menuCom.GetAllMenu();
                
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
        [HttpPost]
        public ActionResult SaveData(ProductsModel model)
        {
            try
            {
                var test = Request.Form.GetValues("form-field-checkbox");
                List<FileModel> lsFile = new List<FileModel>();
                if (!string.IsNullOrEmpty(model.NEWS_ID))
                {
                    model.UPDATE_DATE = DateTime.Now;
                    _postCom.UpdatePost(model);
                }
                else
                {
                    model.CREATE_DATE = DateTime.Now;
                    model.NEWS_ID = _postCom.CreatePost(model);
                }
                //delete CAT old
                _postCom.DeleteCatItem(model.NEWS_ID);
                if (test!=null)
                {
                    //Insert CAT new
                    foreach (var p in test)
                    {
                        _postCom.CreateCatItem(model.NEWS_ID, p);
                    }
                }
                if (Request.Files.Count > 0)
                {
                    //Save list image to database and folder data

                    var path = Server.MapPath("~/data/img/post/" + model.NEWS_ID + "/");
                    //check exist and create folder
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //get file ảnh đại diện
                    if (Request.Files["file-att"].ContentLength > 0)
                    {
                        string urlAvatar = "~/data/img/post/" + model.NEWS_ID + "/" + Request.Files["file-att"].FileName;
                        if (System.IO.File.Exists(urlAvatar))
                        {
                            System.IO.File.Delete(urlAvatar);
                        }
                        lsFile.Add(new FileModel { name = Request.Files["file-att"].FileName, url = urlAvatar });
                        model.ANH = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsFile); ;
                    }

                    //save list file
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
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
                            file.SaveAs(pathfull);
                            //if (file.FileName != Request.Files["file-att"].FileName)
                            //{
                            //    result = "~/data/img/products/" + model.NEWS_ID + "/" + file.FileName;
                            //    //add to list
                            //    lsFile.Add(new FileModel { name = fileName, url = result });
                            //}
                        }
                    }
                    //if (Request.Files["file-att-list"].ContentLength > 0)
                    //{
                    //    //add link to LIST_ANH
                    //    model.LIST_ANH = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsFile);
                    //}
                    _postCom.UpdatePost(model);//update ANH and LIST_ANH

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { Msg = "Save fail!" });
            }

        }
        [HttpPost]
        public ActionResult AjaxUpdateActive(string id, string active)
        {
            try
            {
                ProductsModel model = new ProductsModel();
                model.NEWS_ID = id;
                model.ACTIVE = active != "0" ? true : false;
                _postCom.UpdateActive(model);
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
        public ActionResult AjaxDelete(string id)
        {
            try
            {
                _postCom.DeleteByID(id);
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
        public ActionResult DeleteFile(string fileName, string id)
        {
            try
            {
                string fullPath = Server.MapPath("~/data/img/post/" + id + "/" + fileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                }
                ProductsModel model = _postCom.GetPostByID(int.Parse(id));
                var lsFileName = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<FileModel>>(model.ANH);
                List<FileModel> lsName = new List<FileModel>();
                foreach (var item in lsFileName)
                {
                    if (item.name.Trim() != fileName.Trim())
                    {
                        lsName.Add(new FileModel { name = item.name, url = item.url });
                    }
                }

                string jsonString = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsName);
                model.ANH = jsonString;
                _postCom.UpdatePost(model);
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