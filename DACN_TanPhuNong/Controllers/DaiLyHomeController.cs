using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Controllers
{
    public class DaiLyHomeController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /DaiLyHome/
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "DaiLy";

            return View(db.tb_VanPhong.ToList());
        }

        public ActionResult Details(int? id)
        {
            return View(db.tb_VanPhong.Find(id));
        }
    }
}