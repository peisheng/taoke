using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebCenter.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Categroy",
               url: "Category/{id}-{cate_name}",
               defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional, cate_name = UrlParameter.Optional },
               namespaces: new[] { "WebCenter.Web.Controllers" }
           );
            routes.MapRoute(
              name: "Categroy2",
              url: "Category/{id}/{cate_name}",
              defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional, cate_name = UrlParameter.Optional },
              namespaces: new[] { "WebCenter.Web.Controllers" }
          );
            routes.MapRoute(
              name: "product",
              url: "product/{id}-{product_name}",
              defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional, cate_name = UrlParameter.Optional },
              namespaces: new[] { "WebCenter.Web.Controllers" }
          );
            routes.MapRoute(
             name: "product2",
             url: "product/{id}/{product_name}",
             defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional, cate_name = UrlParameter.Optional },
             namespaces: new[] { "WebCenter.Web.Controllers" }
         );
         
            routes.MapRoute(
              name: "contact",
              url: "welcome/contact",
              defaults: new { controller = "page", action = "contact" },
              namespaces: new[] { "WebCenter.Web.Controllers" }
          );

            routes.MapRoute(
            name: "privacy",
            url: "welcome/privacy",
            defaults: new { controller = "page", action = "index", pagename = "privacy" },
            namespaces: new[] { "WebCenter.Web.Controllers" }
        );

            routes.MapRoute(
           name: "term_condiction",
           url: "welcome/terms_conditions",
           defaults: new { controller = "page", action = "index", pagename = "terms_conditions" },
           namespaces: new[] { "WebCenter.Web.Controllers" }
       );
            routes.MapRoute(
       name: "our_company",
       url: "welcome/our_company",
       defaults: new { controller = "page", action = "index", pagename = "our_company" },
       namespaces: new[] { "WebCenter.Web.Controllers" }
   );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebCenter.Web.Controllers" }
            );


        }
    }
}
