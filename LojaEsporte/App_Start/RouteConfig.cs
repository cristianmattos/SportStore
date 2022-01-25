using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaEsporte
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cadastro do Produto",
                url: "Fornecedor/CadastroProduto/",
                defaults: new { controller = "Produto", action = "CadastroProduto", id = UrlParameter.Optional },
                namespaces: new[] { "LojaEsporte.Controllers" }
            );
        }
    }
}
