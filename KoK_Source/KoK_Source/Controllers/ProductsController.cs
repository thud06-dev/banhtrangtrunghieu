using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Products;
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
                    _productsCom.CreateProducts(model);
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