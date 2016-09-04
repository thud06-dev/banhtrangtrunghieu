using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Products;
using KoK_Source.Models.File;
using System.Data;
using System.IO;
using KoK_Source.Com;
using KoK_Source.Common;

namespace KoK_Source.Controllers
{
    public class ProductsController : BaseController
    {
        private ProductsCom _productsCom = new ProductsCom();
        private MenuCom _menuCom = new MenuCom();
        // GET: Products
        public ActionResult Index()
        {
            try
            {
                List<ProductsModel> model = null;
                model = _productsCom.GetAllProducts();
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
                    model = _productsCom.GetProductsByID(int.Parse(model.NEWS_ID));
                    model.arrMenu = _productsCom.getMenuOfPost(model.NEWS_ID);
                }
                model.listMenu = _menuCom.GetAllMenu();
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
        /// <summary>
        /// Save database from view Edit Product
        /// </summary>
        /// <param name="model"></param>
        /// author ="Lâm"
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveData(ProductsModel model)
        {
            try
            {
                var test = Request.Form.GetValues("form-field-checkbox");
                //get file danh sách ảnh

                List<FileModel> lsFile = new List<FileModel>();
                List<FileModel> lsFileAvata = new List<FileModel>();
                if (!string.IsNullOrEmpty(model.NEWS_ID))
                {
                    model.UPDATE_DATE = DateTime.Now;
                    _productsCom.UpdateProducts(model);
                    //get old list anh
                    if (!String.IsNullOrEmpty(model.LIST_ANH))
                    {
                        var lsFileName = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<FileModel>>(model.LIST_ANH);
                        foreach (var item in lsFileName)
                        {
                            lsFile.Add(new FileModel { name = item.name, url = item.url });
                        }
                    }
                }
                else
                {
                    model.CREATE_DATE = DateTime.Now;
                    model.NEWS_ID = _productsCom.CreateProducts(model);
                }
                //delete CAT old
                _productsCom.DeleteCatItem(model.NEWS_ID);
                if (test != null)
                {
                    //Insert CAT new
                    foreach (var p in test)
                    {
                        _productsCom.CreateCatItem(model.NEWS_ID, p);
                    }
                }
                if (Request.Files.Count > 0)
                {
                    //Save list image to database and folder data

                    var path = Server.MapPath("~/data/img/products/" + model.NEWS_ID + "/");
                    //check exist and create folder
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //get file ảnh đại diện
                    if (Request.Files["file-att"].ContentLength > 0)
                    {
                        string urlAvatar = "~/data/img/products/" + model.NEWS_ID + "/" + Request.Files["file-att"].FileName;
                        if (System.IO.File.Exists(urlAvatar))
                        {
                            System.IO.File.Delete(urlAvatar);
                        }
                        lsFileAvata.Add(new FileModel { name = Request.Files["file-att"].FileName, url = urlAvatar });
                        model.ANH = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsFileAvata); ;
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
                            if (file.FileName != Request.Files["file-att"].FileName)
                            {
                                result = "~/data/img/products/" + model.NEWS_ID + "/" + file.FileName;
                                //add to list
                                lsFile.Add(new FileModel { name = fileName, url = result });
                            }
                        }
                    }
                    if (Request.Files["file-att-list"].ContentLength > 0)
                    {
                        //add link to LIST_ANH
                        model.LIST_ANH = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsFile);
                    }
                    _productsCom.UpdateProducts(model);//update ANH and LIST_ANH

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
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
                _productsCom.UpdateActive(model);
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
                _productsCom.DeleteByID(id);
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
        public ActionResult DeleteFile(string fileName,string id)
        {
            try {
                string fullPath = Server.MapPath("~/data/img/products/" + id + "/" + fileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                }
                ProductsModel model = _productsCom.GetProductsByID(int.Parse(id));
                var lsFileName = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<FileModel>>(model.LIST_ANH);
                List<FileModel> lsName = new List<FileModel>();
                foreach (var item in lsFileName)
                {
                    if (item.name.Trim() != fileName.Trim())
                    {
                        lsName.Add(new FileModel { name = item.name, url = item.url });
                    }
                }

                string jsonString = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lsName);
                model.LIST_ANH = jsonString;
                _productsCom.UpdateProducts(model);
                return Json(new
                {
                    returnCode = 1
                });
            }
            catch(Exception ex)
            {
                return Json(new
                {
                    returnCode = 0
                });
            }
        }
    }
}