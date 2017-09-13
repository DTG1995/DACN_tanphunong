using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class NhatKyController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Admin/NhatKy/

        [AdminFilter(AllowPermit = "0,1,2,3")]
        public ActionResult Index()
        {
            return View(db.tb_NhatKy.ToList());
        }
	}
}