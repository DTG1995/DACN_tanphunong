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

        public ActionResult AllByLoai(int? id,int? page)
        {
            ViewBag.CurrentMenu = "SanPham";
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            var current = db.tb_LoaiSP.Include("tb_LoaiSP1").Where(x=>x.MaLoaiSP==id).FirstOrDefault();
            ViewBag.LoaiCurrent = db.tb_LoaiSPTrans.Where(x=>x.NgonNgu==lang && x.MaLoaiSP == id).FirstOrDefault();
            
            if (current != null)
            {
                var listLSP = current.tb_LoaiSP1;
                
                int limit = 12;
                int page1 = page ?? 1;
                var listID = listLSP.Select(x => x.MaLoaiSP).ToList();
                ViewBag.ListLSP = db.tb_LoaiSPTrans.Where(x=>x.NgonNgu==lang && listID.Contains(x.MaLoaiSP)).ToList();
                var listSP = db.tb_SanPham.Where(x => listID.Contains(x.MaLoai)).ToList().Skip((page1 - 1) * limit).Take(limit);


                return View(listSP);
            }
            return View(new List<tb_SanPham>());
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