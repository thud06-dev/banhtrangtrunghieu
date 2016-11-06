using KOKService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Controllers
{
    public class ContactController : Controller
    {
        private KOK_DATAEntities _kokDataEntities = new KOK_DATAEntities();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(FormCollection form)
        {
            KOK_NEWS kok_news = new KOK_NEWS();
            kok_news.NEWS_TITLE = form["name"].Trim();//tên người dùng
            kok_news.NEWS_URL = form["email"].Trim();//email
            kok_news.POST_HTML = form["content"].Trim();//nội dung
            kok_news.NEWS_DESC = form["phonenumber"].Trim();//SDT
            kok_news.UPDATE_DATE = DateTime.Now;
            _kokDataEntities.KOK_NEWS.Add(kok_news);
            _kokDataEntities.SaveChanges();
            return View("Index");
        }
    }
}