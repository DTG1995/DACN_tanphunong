using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Controllers
{
    public class SanPhamHomeController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /SanPhamHome/
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "SanPham";
            return View(db.tb_LoaiSP.Where(x=>x.LoaiCha==null).ToList());
        }

        public ActionResult AllByLoai(int? id)
        {
            ViewBag.CurrentMenu = "SanPham";
            if (id != null)
            {
                return View(db.tb_LoaiSP.Find(id).tb_SanPham.ToList());
            }
            return PartialView("Error");
        }

        public ActionResult Details(int? id)
        {
            ViewBag.CurrentMenu = "SanPham";
            if (id != null)
            {
                tb_SanPham sanPham = db.tb_SanPham.Find(id);
                return View(sanPham);
            }
            return PartialView("Error");
        }
	}
}