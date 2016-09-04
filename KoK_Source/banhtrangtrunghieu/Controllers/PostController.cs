using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using banhtrangtrunghieu.Models;
using banhtrangtrunghieu.Com;

namespace banhtrangtrunghieu.Controllers
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
                NewsModel model = _postCom.detailNews(id_menu, id_post);
                return View(model);
            }
            catch(Exception ex)
            {
                return new EmptyResult();
            }
        }
    }
}