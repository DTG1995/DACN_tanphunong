using System.Web.Mvc;

namespace DACN_TanPhuNong.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_language",
                "{lang}/admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                constraints: new {lang="vi|en" }
            );
            context.MapRoute(
                "Admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional,lang="vi" }
            );
        }
    }
}