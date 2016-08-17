using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Models.Post;
using KOKService;
using System.Data;
using System.IO;
using KoK_Source.Com;
using KoK_Source.Common;

namespace KoK_Source.Controllers
{
    public class PostController : Controller
    {
        private PostCom _postCom = new PostCom();
        // GET: Post
        public ActionResult Index()
        {
            try
            {
                List<PostModel> model = null;
                model = _postCom.GetAllPost();
                return View(model);
            }
            catch (Exception ex)
            {
                return new EmptyResult();
            }
        }
        public ActionResult Edit(PostModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.NEWS_ID))
                {
                    model = _postCom.GetPostByID(int.Parse(model.NEWS_ID));
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