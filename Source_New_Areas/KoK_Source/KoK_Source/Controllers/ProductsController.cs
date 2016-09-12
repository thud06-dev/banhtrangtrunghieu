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
                List<ProductsModel> model = null;
                int countPost = 0;
                if (!id.HasValue)
                {
                    model = _productsCom.getPostAll();
                    countPost = model.Count;
                    model = model.OrderByDescending(a => a.UPDATE_DATE).Skip(skip).Take(md.numberPost.Value).ToList();
                }
                else
                {
                    model = _productsCom.getPostOfCat(id, skip, md.numberPost.Value);
                    countPost = _productsCom.getPostofCatAll(id).Count;
                }
                md.numberPage = countPost / md.numberPost.Value + (countPost % md.numberPost.Value > 0 ? 1 : 0);
                ViewBag.Page = md;
                ViewBag.MenuId = id == null ? id : id.Value;
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
                _productsCom.CountView(int.Parse(id_products));
                ViewBag.NEWS_SEO_TITLE = model.NEWS_SEO_TITLE;
                ViewBag.NEWS_SEO_DESC = model.NEWS_SEO_DESC;
                ViewBag.NEWS_DESC = model.NEWS_DESC;
                ViewBag.NEWS_SEO_KEYWORD = model.NEWS_SEO_KEYWORD;
                ViewBag.NEWS_TITLE = model.NEWS_TITLE;
                if (!string.IsNullOrEmpty(model.ANH))
                {
                    List<FileModel> fileAvatar = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<FileModel>>(model.ANH);
                    if (fileAvatar != null)
                    {
                        ViewBag.IMAGE = fileAvatar.First().url;
                    }
                    else
                    {
                        ViewBag.IMAGE = "~/Content/_Template/img/img.jpg";
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
    }
}