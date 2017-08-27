using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    
    public class UngDungController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Admin/UngDung/
        public ActionResult Index()
        {
            ViewBag.ContentHome =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentHome").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.NameEnterprise =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "NameEnterprise").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.DesEnterprise =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "DesEnterprise").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.logo =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "logo").Select(x => x.NoiDungTuyChon).FirstOrDefault();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public string SaveContentHome(String txtContentHome)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "ContentHome");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon {TenTuyChon = "ContentHome", NoiDungTuyChon = txtContentHome});
            else
            {
                tuyChon.NoiDungTuyChon = txtContentHome;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            int rows = db.SaveChanges();
            if (rows > 0)
                return "true";
            return "false";
        }
	}
}