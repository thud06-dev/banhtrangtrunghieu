using KOKService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


            //var message = new MailMessage();
            //message.Body = "";
            //message.To.Add((new MailAddress()););

            var fromEmailAddress = kok_news.NEWS_TITLE;
            var fromEmailDisplayName = kok_news.NEWS_URL;
            //var fromEmailContent = kok_news.POST_HTML;
            //var fromEmailPhone = kok_news.NEWS_DESC;


            //var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            //var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            //var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            string body = "Your registration has been done successfully. Thank you.";

            MailMessage message = new MailMessage(new MailAddress("test@dacsancuchi.com", "nguyenngochuyhaong"), new MailAddress("test@dacsancuchi.com", "nguyen ngoc huy hoang"));
            message.Subject = "Thank You For Your Registration";
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            var credental = new NetworkCredential
            {
                UserName = "test@dacsancuchi.com",
                Password = "07021994",
            };
            client.Credentials = new NetworkCredential("test@dacsancuchi.com", "07021994", "dacsancuchi.com");
            client.Host = "210.245.90.235";
            client.EnableSsl = true;
            client.Port = 8443;
            client.Timeout = 10000;
            client.Send(message);


            return View("Index");
        }
    }
}