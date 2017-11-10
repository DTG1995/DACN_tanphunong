using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DACN_TanPhuNong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //San pham
            routes.MapRoute(
                name: "SanPham",
                url: "san-pham",
                defaults: new { controller = "SanPhamHome", action = "Index"}
            );
            routes.MapRoute(
                name: "LoaiSanPham",
                url: "{lang}/loai-san-pham/{title}-{id}",
                defaults: new { controller = "SanPhamHome", action = "AllByLoai",id=UrlParameter.Optional, title=UrlParameter.Optional },
                constraints: new { lang = @"vi|en" }
            );
            routes.MapRoute(
                name: "SanPhamDetails",
                url: "{lang}/san-pham/{title}-{id}",
                defaults: new { controller = "SanPhamHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional },
                constraints: new { lang = @"vi|en" }
            );

            //Dai Ly
            routes.MapRoute(
                name: "DaiLy",
                url: "dai-ly",
                defaults: new { controller = "DaiLyHome", action = "Index"}
            );
            routes.MapRoute(
                name: "DaiLyDetails",
                url: "dai-ly/{title}-{id}",
                defaults: new { controller = "DaiLyHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional }
            );
            //Doi Tac
            routes.MapRoute(
                name: "DoiTac",
                url: "doi-tac",
                defaults: new { controller = "DoiTacHome", action = "Index" }
            );
            routes.MapRoute(
                name: "DoiTacDetails",
                url: "doi-tac/{title}-{id}",
                defaults: new { controller = "DoiTacHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional }
            );
            //Tin Tuc
            routes.MapRoute(
                name: "TinTuc",
                url: "tin-tuc",
                defaults: new { controller = "TinTucHome", action = "Index" }
            );
            routes.MapRoute(
                name: "TinTucDetails",
                url: "tin-tuc/{title}-{id}",
                defaults: new { controller = "TinTucHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional }
            );
            //Tuyen Dung
            routes.MapRoute(
                name: "TuyenDung",
                url: "tuyen-dung",
                defaults: new { controller = "TuyenDungHome", action = "Index" }
            );
            routes.MapRoute(
                name: "TuyenDungDetails",
                url: "tuyen-dung/{title}-{id}",
                defaults: new { controller = "TuyenDungHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional }
            );
            //Lien He
            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "Home", action = "LienHe" }
            );
            //Tri an khach hang

            routes.MapRoute(
                name:"triankh",
                url:"{lang}/tri-an-khach-hang",
                defaults: new {controller="Home", action="TriAn" },
                constraints: new { lang = @"vi|en" }
                );
            routes.MapRoute(
                name: "Language",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"vi|en" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang="vi" }
            );
        }
    }
}
