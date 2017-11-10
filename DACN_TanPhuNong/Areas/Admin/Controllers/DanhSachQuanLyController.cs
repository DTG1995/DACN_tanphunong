using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class DanhSachQuanLyController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/DanhSachQuanLy/
        public ActionResult Index()
        {
            return View(db.tb_DoiNguQuanLy.ToList());
        }

        // GET: /Admin/DanhSachQuanLy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQuanLy tb_doinguquanly = db.tb_DoiNguQuanLy.Find(id);
            if (tb_doinguquanly == null)
            {
                return HttpNotFound();
            }
            return View(tb_doinguquanly);
        }

        // GET: /Admin/DanhSachQuanLy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/DanhSachQuanLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQL,HinhAnh,ThuBac")] tb_DoiNguQuanLy tb_doinguquanly)
        {
             
            if (ModelState.IsValid)
            {
                db.tb_DoiNguQuanLy.Add(tb_doinguquanly);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            tb_DoiNguQL_Trans tb_QLVi = new tb_DoiNguQL_Trans();
            tb_QLVi.MaQL = tb_doinguquanly.MaQL;
            tb_QLVi.TenNguoiQL = Request.Params["TenNguoiQLVn"];
            tb_QLVi.NgonNgu ="vi";
            tb_QLVi.ChucVu = Request.Params["ChucVuVn"];
            tb_QLVi.MoTa = Request.Params["MoTaVn"];
            tb_QLVi.CauNoi = Request.Params["CauNoiVn"];
            
            tb_DoiNguQL_Trans tb_QLEn=new tb_DoiNguQL_Trans();
            tb_QLEn.MaQL = tb_doinguquanly.MaQL;
            tb_QLEn.TenNguoiQL = Request.Params["TenNguoiQLEn"];
            tb_QLEn.NgonNgu = "en";
            tb_QLEn.ChucVu = Request.Params["ChucVuEn"];
            tb_QLEn.MoTa = Request.Params["MoTaEn"];
            tb_QLEn.CauNoi = Request.Params["CauNoiEn"];
            db.tb_DoiNguQL_Trans.Add(tb_QLVi);
            db.tb_DoiNguQL_Trans.Add(tb_QLEn);
            db.SaveChanges();
            return RedirectToAction("Abouts", "UngDung");
        }

        // GET: /Admin/DanhSachQuanLy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQuanLy tb_doinguquanly = db.tb_DoiNguQuanLy.Find(id);
            if (tb_doinguquanly == null)
            {
                return HttpNotFound();
            }
            return View(tb_doinguquanly);
        }

        // POST: /Admin/DanhSachQuanLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaQL,HinhAnh,ThuBac")] tb_DoiNguQuanLy tb_doinguquanly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_doinguquanly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_doinguquanly);
        }

        // GET: /Admin/DanhSachQuanLy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQuanLy tb_doinguquanly = db.tb_DoiNguQuanLy.Find(id);
            if (tb_doinguquanly == null)
            {
                return HttpNotFound();
            }
            return View(tb_doinguquanly);
        }

        // POST: /Admin/DanhSachQuanLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DoiNguQuanLy tb_doinguquanly = db.tb_DoiNguQuanLy.Find(id);
            db.tb_DoiNguQuanLy.Remove(tb_doinguquanly);
            db.SaveChanges();
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
