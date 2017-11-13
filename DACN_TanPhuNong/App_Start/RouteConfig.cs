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
                name: "SanPhamDetails",
                url: "{lang}/sp/{title}-{id}",
                defaults: new { controller = "SanPhamHome", action = "Details", id = UrlParameter.Optional, title = UrlParameter.Optional },
                constraints: new { lang = @"vi|en" }
            );
            //Thong bao
            routes.MapRoute(
                name: "thong_bao",
                url: "{lang}/notification",
                defaults: new { controller = "BaiViet", action = "Index", loaibv = 0 },
                constraints: new { lang = @"vi|en" }
            );
            //tuyen dung
            routes.MapRoute(
                name: "Careers",
                url: "{lang}/tuyen-dung",
                defaults: new { controller = "BaiViet", action = "Index", loaibv = 1 },
                constraints: new { lang = @"vi|en" }
            );
            //Khuyen mai
            routes.MapRoute(
                name: "Promotions",
                url: "{lang}/khuyen-mai",
                defaults: new { controller = "BaiViet", action = "Index", loaibv = 2 },
                constraints: new { lang = @"vi|en" }
            );
            //hoi nghi
            routes.MapRoute(
                name: "Conferences",
                url: "{lang}/hoi-nghi-hoi-thao",
                defaults: new { controller = "BaiViet", action = "Index", loaibv = 3 },
                constraints: new { lang = @"vi|en" }
            );
            //Image Video

            routes.MapRoute(
                name: "hinh-anh-video",
                url: "{lang}/images-videos",
                defaults: new { controller = "BaiViet", action = "Index", loaibv = 4 },
                constraints: new { lang = @"vi|en" }
            );


            routes.MapRoute(
                name: "chitietbaiviet",
                url: "{lang}/p/{title}-{id}",
                defaults: new { controller = "BaiViet", action = "Detail", id = UrlParameter.Optional, title = UrlParameter.Optional },
                constraints: new { lang = @"vi|en" }
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
            //Thong bao noi bo
            routes.MapRoute(
                name: "thong_bao_noi_bo",
                url: "{lang}/thong-bao-noi-bo",
                defaults: new { controller = "BaiViet", action = "thongBaoNoiBo" },
                constraints: new { lang = @"vi|en" });
            //Phan bon
            routes.MapRoute(
               name: "LoaiSanPham",
               url: "{lang}/{title}-{id}",
               defaults: new { controller = "SanPhamHome", action = "AllByLoai", id = UrlParameter.Optional, title = UrlParameter.Optional },
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
