using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Controllers
{
    public class TinTucHomeController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /TinTucHome/
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "TinTuc";
            return View(db.tb_BaiViet.Where(x=>x.LoaiBaiViet==0).ToList());
        }

        public ActionResult Details(int? id)
        {
            ViewBag.CurrentMenu = "TinTuc";
            return View(db.tb_BaiViet.Find(id));
        }
	}
}