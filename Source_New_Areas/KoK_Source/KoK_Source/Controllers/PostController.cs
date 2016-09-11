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
                md.currentPage = pageIndex == null ? 0 : pageIndex.Value;

                md.numberPost = 9;//Số bài post trong 1 trang
                int skip = pageIndex.Value * md.numberPost.Value;
                List<NewsModel> model = null;
                int countPost = 0;
                if (!id.HasValue)
                {
                    model = _postCom.getPostAll();
                    countPost = model.Count;
                    model = model.OrderByDescending(a => a.UPDATE_DATE).Skip(skip).Take(md.numberPost.Value).ToList();
                }
                else
                {
                    model = _postCom.getPostOfCat(id, skip, md.numberPost.Value);
                    countPost = _postCom.getPostofCatAll(id).Count;
                }
                
                 
                md.numberPage = countPost / md.numberPost.Value + (countPost % md.numberPost.Value > 0 ? 1 : 0);
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
        public ActionResult ABC(string test)
        {
            return View();
        }
    }
}