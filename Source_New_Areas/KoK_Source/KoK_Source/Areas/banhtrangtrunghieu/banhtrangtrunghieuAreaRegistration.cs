using System.Web.Mvc;

namespace KoK_Source.Areas.banhtrangtrunghieu
{
    public class banhtrangtrunghieuAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "banhtrangtrunghieu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "banhtrangtrunghieu_default",
                "banhtrangtrunghieu/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //context.MapRoute(
            //    "banhtrangtrunghieu_default",
            //    "{controller}/{action}/{id}", //******
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}