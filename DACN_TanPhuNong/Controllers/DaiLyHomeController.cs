﻿using System;
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
            return View(db.tb_VanPhong.ToList());
        }
	}
}