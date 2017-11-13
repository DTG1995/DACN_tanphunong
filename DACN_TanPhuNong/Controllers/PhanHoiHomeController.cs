using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
namespace DACN_TanPhuNong.Controllers
{
    public class PhanHoiHomeController : BaseController
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        // Gui Phan Hoi
        [HttpGet]
        public ActionResult GuiPhanHoi()
        {
            ViewBag.CurrentMenu = "PhanHoi";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuiPhanHoi(tb_PhanHoi phanhoi)
        {
            ViewBag.CurrentMenu = "PhanHoi";
            if (ModelState.IsValid)
            {
                phanhoi.TrangThai = 0;
                db.tb_PhanHoi.Add(phanhoi);
                db.SaveChanges();
                TempData["ThongBao"] = "ThanhCong";
                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}