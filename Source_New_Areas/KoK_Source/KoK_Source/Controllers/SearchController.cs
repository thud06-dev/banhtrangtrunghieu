using KoK_Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Com;
namespace KoK_Source.Controllers
{
    public class SearchController : Controller
    {
        private SearchCom _searchCom = new SearchCom();
        // GET: Search
        public ActionResult Index(string search, int? pageIndex)
        {
            try
            {
                var md = new PagedList();
                pageIndex = md.currentPage = pageIndex == null ? 0 : pageIndex.Value;

                md.numberPost = 9;//Số bài post trong 1 trang
                int skip = pageIndex.Value * md.numberPost.Value;
                List<NewsModel> model = null;
                int countPost = 0;
                model = _searchCom.getAllByParam(search);
                countPost = model.Count;
                model = model.OrderByDescending(a => a.UPDATE_DATE).Skip(skip).Take(md.numberPost.Value).ToList();
               

                md.numberPage = countPost / md.numberPost.Value + (countPost % md.numberPost.Value > 0 ? 1 : 0);
                ViewBag.Page = md;
                ViewBag.Param = search;
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
    }
}