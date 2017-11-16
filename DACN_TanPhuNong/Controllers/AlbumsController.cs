using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
namespace DACN_TanPhuNong.Controllers
{
    public class AlbumsController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Albums/
        public ActionResult Index()
        {
            var model = db.tb_Album.OrderByDescending(x=>x.NgayTao).ToList();
            return View(model);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var modal = db.tb_Album.Find(id);
            if (modal == null)
                return RedirectToAction("Index");
            return View(modal);
        }
	}
}