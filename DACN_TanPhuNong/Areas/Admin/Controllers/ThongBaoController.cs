using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using DACN_TanPhuNong.Controllers;
namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class ThongBaoController : BaseController
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        
        // GET: /Admin/ThongBao/
        public ActionResult Index()
        {
            var lang = RouteData.Values["lang"] as string ?? "vi";
            var tb_baiviettrans = db.tb_BaiVietTrans.Include(t => t.tb_BaiViet).Where(t => t.tb_BaiViet.LoaiBaiViet == 0 && t.NgonNgu==lang );
            return View(tb_baiviettrans.ToList());
        }

        // GET: /Admin/ThongBao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Include(t => t.tb_BaiVietTrans).Where(t=>t.MaBV==id).FirstOrDefault();

            if (tb_baiviet == null)
            {
                return HttpNotFound();
            }
            return View(tb_baiviet);
        }

        // GET: /Admin/ThongBao/Create
        public ActionResult Create()
        {
            //ViewBag.MaBV = new SelectList(db.tb_BaiViet, "MaBV", "HinhAnh");
            return View(new tb_BaiViet());
        }

        // POST: /Admin/ThongBao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include="HinhAnh,NoiBo")] tb_BaiViet tb_baiviet)
        {
            tb_baiviet.LoaiBaiViet = 0;
            tb_baiviet.NgayViet = DateTime.Now;
            tb_baiviet.NguoiViet = HttpContext.Session["username"] as string??"";
            
            if (ModelState.IsValid)
            {
                db.tb_BaiViet.Add(tb_baiviet);
                db.SaveChanges();
                
            }

            tb_BaiVietTrans tb_bvVn = new tb_BaiVietTrans();
            tb_bvVn.MaBV = tb_baiviet.MaBV;
            tb_bvVn.NgonNgu = "vi";
            tb_bvVn.TieuDeTrans = Request.Form["TieuDeVn"];
            tb_bvVn.TomTatTrans = Request.Form["TomTatVn"];
            tb_bvVn.NoiDungTrans = Request.Form["NoiDungVn"];
            db.tb_BaiVietTrans.Add(tb_bvVn);
            tb_BaiVietTrans tb_bvEn = new tb_BaiVietTrans();
            tb_bvEn.MaBV = tb_baiviet.MaBV;
            tb_bvEn.NgonNgu = "en";
            tb_bvEn.TieuDeTrans = Request.Form["TieuDeEn"];
            tb_bvEn.TomTatTrans = Request.Form["TomTatEn"];
            tb_bvEn.NoiDungTrans = Request.Form["NoiDungEn"];
            db.tb_BaiVietTrans.Add(tb_bvEn);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: /Admin/ThongBao/Edit/5
        public ActionResult Edit(int? id)
        {
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Include(t => t.tb_BaiVietTrans).Where(t=>t.MaBV ==id).FirstOrDefault();

            if (tb_baiviet == null)
            {
                return HttpNotFound();
            }
            return View(tb_baiviet);
        }

        // POST: /Admin/ThongBao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken,ValidateInput(false)]
        public ActionResult Edit([Bind(Include="MaBV,HinhAnh,NoiBo")] tb_BaiViet tb_baiviet)
        {
            tb_baiviet.NguoiViet = HttpContext.Session["username"] as string ?? "";
            tb_baiviet.LoaiBaiViet = 0;
            tb_baiviet.NgayViet = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                db.Entry(tb_baiviet).State = EntityState.Modified;
                db.SaveChanges();
            }

            tb_BaiVietTrans tb_bvVn =db.tb_BaiVietTrans.Where(t=>t.NgonNgu=="vi" && t.MaBV==tb_baiviet.MaBV).FirstOrDefault();
            
            tb_bvVn.TieuDeTrans = Request.Form["TieuDeVn"];
            tb_bvVn.TomTatTrans = Request.Form["TomTatVn"];
            tb_bvVn.NoiDungTrans = Request.Form["NoiDungVn"];
            db.Entry(tb_bvVn).State = EntityState.Modified;
            tb_BaiVietTrans tb_bvEn = db.tb_BaiVietTrans.Where(t => t.NgonNgu == "en" && t.MaBV == tb_baiviet.MaBV).FirstOrDefault();
            tb_bvEn.TieuDeTrans = Request.Form["TieuDeEn"];
            tb_bvEn.TomTatTrans = Request.Form["TomTatEn"];
            tb_bvEn.NoiDungTrans = Request.Form["NoiDungEn"];
            db.Entry(tb_bvEn).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: /Admin/ThongBao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Find(id);
            if (tb_baiviet == null)
            {
                return HttpNotFound();
            }
            return View(tb_baiviet);
        }

        // POST: /Admin/ThongBao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Find(id);
            List<tb_BaiVietTrans> dsTrans = tb_baiviet.tb_BaiVietTrans.ToList();
            for (int i = 0; i < dsTrans.Count; i++)
            {
                db.tb_BaiVietTrans.Remove(dsTrans[i]);
            }
            db.SaveChanges();
            db.tb_BaiViet.Remove(tb_baiviet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SetCode()
        {
            ViewBag.Code = db.tb_TuyChon.Where(x => x.TenTuyChon == "CodeInternal").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult SetCode(string codeInternal)
        {
            var code = db.tb_TuyChon.Where(x => x.TenTuyChon == "CodeInternal").FirstOrDefault();
            if (code != null)
            {
                code.NoiDungTuyChon = codeInternal;
                db.Entry(code).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                code = new tb_TuyChon();
                code.TenTuyChon = "CodeInternal";
                code.NoiDungTuyChon = codeInternal;
                db.tb_TuyChon.Add(code);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
