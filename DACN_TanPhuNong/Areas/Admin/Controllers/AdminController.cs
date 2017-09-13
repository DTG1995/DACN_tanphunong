using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/
        [AdminFilter(AllowPermit = "0,1,2,3")]
        public ActionResult Index()
        {
            
            string[] arrper = ((string) Session["Permit"] ?? "").Split(',');
            int per = int.Parse(arrper[0]);
            switch (per)
            {
                case 0:
                    return RedirectToAction("Index", "UngDung");
                case 1:
                    return RedirectToAction("Index", "SanPham");
                case 2:
                    return RedirectToAction("Index", "BaiViet");
                default:
                    return RedirectToAction("Index", "TuyenDung");
            }
        }
	}
}