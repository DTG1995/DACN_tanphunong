using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Admin/Admin/
        [AdminFilter(AllowPermit = "0,1,2,3")]
        public ActionResult Index()
        {
            
            string[] arrper = ((string) Session["Permit"] ?? "").Split(',');
            int per = int.Parse(arrper[0]);
            switch (per)
            {
                case 0:
                    
                    return RedirectToAction("Index", "UngDung");
                case 1:
                    return RedirectToAction("Index", "SanPham");
                case 2:
                    return RedirectToAction("Index", "Conferences");
                default:
                    return RedirectToAction("Index", "TuyenDung");
            }
            
        }

        [AdminFilter(AllowPermit="0,1,2,3")]
   
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult TriAn(string triAnVi, string triAnEn)
        {
            tb_TuyChon triAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAnvi").FirstOrDefault();
            
            if (triAn != null)
            {
                triAn.NoiDungTuyChon = triAnVi;
                db.Entry(triAn).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                   
            }
            else
            {
                triAn = new tb_TuyChon();
                triAn.TenTuyChon = "TriAnvi";
                triAn.NoiDungTuyChon = triAnVi;
                db.tb_TuyChon.Add(triAn);
                db.SaveChanges();
            }

            triAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAnen").FirstOrDefault();

            if (triAn != null)
            {
                triAn.NoiDungTuyChon = triAnEn;
                db.Entry(triAn).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }
            else
            {
                triAn = new tb_TuyChon();
                triAn.TenTuyChon = "TriAnen";
                triAn.NoiDungTuyChon = triAnEn;
                db.tb_TuyChon.Add(triAn);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
	}
}