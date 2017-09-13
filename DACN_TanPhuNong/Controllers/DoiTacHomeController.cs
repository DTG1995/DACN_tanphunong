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
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /DoiTacHome/
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "DoiTac";
            return View(db.tb_DoiTac.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.tb_DoiTac.Find(id));
        }
	}
}