using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DACN_TanPhuNong.Filter
{
    public class AdminFilter : ActionFilterAttribute
    {
        public string AllowPermit { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Convert.ToBoolean(filterContext.HttpContext.Session["IsAdmin"]??false))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "NguoiDung", action = "Login" }));
            }
            string permit =(string) filterContext.HttpContext.Session["Permit"] ?? "";
            var arrpermit = permit.Split(',');
            var arrpermitAllow = this.AllowPermit.Split(',');
            bool check = false;
            for (int i = 0; i < arrpermit.Length; i++)
            {
                for (int j = 0; j < arrpermitAllow.Length; j++)
                {
                    if (arrpermit[i] == arrpermitAllow[j])
                    {
                        check = true;
                        break;
                    }
                }
                if (check == true)
                {
                    break;
                }
            }
            if (check == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "NguoiDung", action = "Login" }));
            }
        }


    }
}