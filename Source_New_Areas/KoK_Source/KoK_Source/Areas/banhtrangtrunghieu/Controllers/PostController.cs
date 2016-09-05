using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Areas.banhtrangtrunghieu.Models;
using KoK_Source.Areas.banhtrangtrunghieu.Com;

namespace KoK_Source.Areas.banhtrangtrunghieu.Controllers
{
    public class PostController : Controller
    {
        PostCom _postCom = new PostCom();
        // GET: Post
        public ActionResult Index()
        {
            return View();
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
                return new EmptyResult();
            }
        }
    }
}