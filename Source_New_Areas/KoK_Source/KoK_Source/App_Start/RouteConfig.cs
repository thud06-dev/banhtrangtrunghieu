using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KoK_Source
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "URL post",
               url: "bai-viet/{NEWS_SEO_URL}-{id_post}",
               defaults: new { controller = "Post", action = "DetailPost", id = UrlParameter.Optional, id_post = "id_post" }
           );
            routes.MapRoute(
               name: "URL products",
               url: "san-pham/{NEWS_SEO_URL}-{id_products}",
               defaults: new { controller = "Products", action = "DetailProducts", id = UrlParameter.Optional, id_products = "id_products" }
           );
            routes.MapRoute(
               name: "URL Danh muc products",
               url: "danh-muc-san-pham/{NEWS_SEO_URL}-{id}-{pageIndex}",
               defaults: new { controller = "Products", action = "Index", id = "id", pageIndex = "pageIndex" }
           );
            routes.MapRoute(
               name: "URL Danh muc post",
               url: "danh-muc-bai-viet/{NEWS_SEO_URL}-{id}-{pageIndex}",
               defaults: new { controller = "Post", action = "Index", id = "id", pageIndex = "pageIndex" }
           );
            //routes.MapRoute("Pages3", "{url1}/{url2}/{url3}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });
            //routes.MapRoute("Pages2", "{url1}/{url2}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });
            //routes.MapRoute("Pages1", "{url1}", MVC.Page.RedirectTo(), new { url1 = "", url2 = "", url3 = "" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
