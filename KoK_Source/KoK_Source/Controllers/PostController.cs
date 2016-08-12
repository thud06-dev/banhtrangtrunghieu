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
        // GET: Post
        public ActionResult Index()
        {
            List<PostModel> model = new List<PostModel>();
            return View(model);
        }
    }
}