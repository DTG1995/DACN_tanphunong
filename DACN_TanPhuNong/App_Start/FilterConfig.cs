using System.Web;
using System.Web.Mvc;

namespace DACN_TanPhuNong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("vi"), 0);
        }
    }
}
