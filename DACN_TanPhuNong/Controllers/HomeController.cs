using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Controllers
{
    public class HomeController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        public ActionResult Index()
        {
            ViewBag.ContentHome =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentHome").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}