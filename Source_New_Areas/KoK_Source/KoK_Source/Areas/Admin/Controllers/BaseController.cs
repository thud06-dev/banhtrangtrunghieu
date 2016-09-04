using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KoK_Source.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //check Session here
            if (Session["UserId"] == null || Session["UserName"] == null)
            {
                filterContext.Result = RedirectToAction("Login", "Login");
            }
        }
    }
}