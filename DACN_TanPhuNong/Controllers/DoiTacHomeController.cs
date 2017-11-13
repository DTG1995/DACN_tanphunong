using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Controllers
{
    public class DoiTacHomeController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        // GET: Danh Sahc Doi Tac
        public ActionResult DanhSachDoiTac()
        {
            ViewBag.CurrentMenu = "DoiTac";
            return View(db.tb_DoiTac.ToList());
        }
      
    }
}
