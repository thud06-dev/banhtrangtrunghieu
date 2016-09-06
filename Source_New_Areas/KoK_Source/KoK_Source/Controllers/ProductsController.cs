using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Com;
using KoK_Source.Models;

namespace KoK_Source.Controllers
{
    public class ProductsController : Controller
    {
        ProductsCom _productsCom = new ProductsCom();
        // GET: banhtrangtrunghieu/Product`
        public ActionResult Index(int? id, int? pageIndex)
        {
            try
            {
                var md = new PagedList();
                md.currentPage = pageIndex == null ? 1 : pageIndex.Value;

                md.numberPost = 9;//Số bài post trong 1 trang
                int skip = pageIndex.Value * md.numberPost.Value;
                List<ProductsModel> model = _productsCom.getPostOfCat(id, skip, md.numberPost.Value);
                int countPost = _productsCom.getPostofCatAll(id).Count;
                md.numberPage = countPost / md.numberPost.Value + countPost % md.numberPost.Value;
                ViewBag.Page = md;
                ViewBag.MenuId = id == null ? 1 : id.Value;
                ViewBag.PostRight = _productsCom.getListProducts(7);
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message });
            }
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