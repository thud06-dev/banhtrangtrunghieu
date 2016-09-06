using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Com;

namespace KoK_Source.Controllers
{
    public class PostController : Controller
    {
        PostCom _postCom = new PostCom();
        // GET: Post
        public ActionResult Index(int? id, int? pageIndex)
        {
            try
            {
                var md = new PagedList();
                md.currentPage = pageIndex == null ? 1 : pageIndex.Value;

                md.numberPost = 9;//Số bài post trong 1 trang
                int skip = pageIndex.Value * md.numberPost.Value;
                List<NewsModel> model = _postCom.getPostOfCat(id, skip, md.numberPost.Value);
                int countPost = _postCom.getPostofCatAll(id).Count;
                md.numberPage = countPost / md.numberPost.Value + countPost % md.numberPost.Value;
                ViewBag.Page = md;
                ViewBag.MenuId = id == null ? 1 : id.Value;
                ViewBag.PostRight = _postCom.getListProducts(7);
                return View(model);
            }
            catch(Exception ex)
            {
                return Json(new { Msg = ex.Message });
            }
        }
        public ActionResult DetailPost(string id_menu, string id_post)
        {
            try
            {
                NewsModel model = new NewsModel();
                model = _postCom.detailNews(id_menu, id_post);
                model.ListPostsSidebar = _postCom.getListProducts(7);
                model.ListPostsRelate = _postCom.getListProducts(4);
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { Msg = ex.Message });
            }
        }
    }
}