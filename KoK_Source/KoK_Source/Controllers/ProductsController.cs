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
    public class ProductsController : Controller
    {
        private ProductsCom _productsCom = new ProductsCom();
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
                }
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

                if (!string.IsNullOrEmpty(model.NEWS_ID))
                {
                    _productsCom.UpdateProducts(model);
                }
                else
                {
                    model.NEWS_ID = _productsCom.CreateProducts(model);
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
                        model.ANH = "~/data/img/products/" + model.NEWS_ID + "/" + Request.Files["file-att"].FileName;
                    }
                    //get file danh sách ảnh

                    List<FileModel> lsFile = new List<FileModel>();
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
    }
}