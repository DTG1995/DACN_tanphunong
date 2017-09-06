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
            return View(db.tb_LoaiSP.Where(x=>x.LoaiCha==null).ToList());
        }

        public ActionResult AllByLoai(int? id)
        {
            if (id != null)
            {
                return View(db.tb_LoaiSP.Find(id).tb_SanPham.ToList());
            }
            return PartialView("Error");
        }
	}
}