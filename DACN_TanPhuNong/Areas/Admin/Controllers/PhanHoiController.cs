using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using DACN_TanPhuNong.Filter;
using System.Data.Entity;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class PhanHoiController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        // GET: Admin/PhanHoi
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Index()
        {
            return View(db.tb_PhanHoi.ToList());
        }
        public ActionResult XuLyPhanHoi(int id)
        {
            var phanhoi = db.tb_PhanHoi.FirstOrDefault(x => x.MaPH.Equals(id));
            phanhoi.TrangThai = 1;
            db.Entry(phanhoi).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "PhanHoi");
        }
    }
}