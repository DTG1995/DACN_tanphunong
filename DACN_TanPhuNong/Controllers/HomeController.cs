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
        public ActionResult Index(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return View(db.tb_SanPham.Where(x=>x.TenSanPham.Contains(s)).ToList());
            }
            ViewBag.CurrentMenu = "TrangChu";
            ViewBag.ContentHome =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentHome").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }

        

        public ActionResult LienHe()
        {
            ViewBag.CurrentMenu = "LienHe";
            ViewBag.ContentLienHe =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentLienHe").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }
    }
}