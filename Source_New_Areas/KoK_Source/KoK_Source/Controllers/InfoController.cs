using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KoK_Source.Models;
using KoK_Source.Com;

namespace KoK_Source.Controllers
{
    public class InfoController : Controller
    {
        PostCom _postCom = new PostCom();
        // GET: Info
        public ActionResult Index()
        {
            try
            {
                NewsModel old = new NewsModel();
                string id_post = _postCom.getGioiThieu();
                NewsModel model = new NewsModel();
                model = _postCom.detailNews(null, id_post);
                model.ListPostsSidebar = _postCom.getListProducts(7);
                model.ListPostsRelate = _postCom.getListProducts(4);
                _postCom.CountView(int.Parse(id_post));
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
                return Json(new { Msg = ex.Message });
            }
        }
    }
}