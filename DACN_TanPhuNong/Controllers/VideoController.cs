using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using PagedList;
namespace DACN_TanPhuNong.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        private db_tanphunongEntities db = new db_tanphunongEntities();
        public ActionResult Index(int? page)
        {
            var model = db.tb_Videos.OrderByDescending(t => t.NgayTao);
            return View(model.ToPagedList(page??1,6));
        }
	}
}