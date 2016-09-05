using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.banhtrangtrunghieu.Com;
using KoK_Source.Areas.banhtrangtrunghieu.Models;

namespace KoK_Source.Areas.banhtrangtrunghieu.Controllers
{
    public class ProductsController : Controller
    {
        ProductsCom _productsCom = new ProductsCom();
        // GET: banhtrangtrunghieu/Product`
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailProducts(string id_menu, string id_products)
        {
            try
            {
                ProductsModel model = new ProductsModel();
                model = _productsCom.detailProducts(id_menu, id_products);
                model.ListProductsSidebar = _productsCom.getListProducts(7);
                model.ListProductsRelate = _productsCom.getListProducts(4);
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
    }
}