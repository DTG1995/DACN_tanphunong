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
    public class DoiNguQuanLyController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/DoiNguQuanLy/
        public ActionResult Index()
        {
            var lang = RouteData.Values["lang"] as string ?? "vi";
            var tb_doinguql_trans = db.tb_DoiNguQL_Trans.Include(t => t.tb_DoiNguQuanLy).Where(x=>x.NgonNgu==lang);
            return View(tb_doinguql_trans.ToList());
        }

        // GET: /Admin/DoiNguQuanLy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQL_Trans tb_doinguql_trans = db.tb_DoiNguQL_Trans.Find(id);
            if (tb_doinguql_trans == null)
            {
                return HttpNotFound();
            }
            return View(tb_doinguql_trans);
        }

        // GET: /Admin/DoiNguQuanLy/Create
        public ActionResult Create()
        {
            ViewBag.MaQL = new SelectList(db.tb_DoiNguQuanLy, "MaQL", "HinhAnh");
            return View();
        }

        // POST: /Admin/DoiNguQuanLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HinhAnh, CapBac")] tb_DoiNguQuanLy tb_doinguql)
        {
            if (ModelState.IsValid)
            {
                db.tb_DoiNguQuanLy.Add(tb_doinguql);
                db.SaveChanges();
                
            }
            tb_DoiNguQL_Trans qlVn = new tb_DoiNguQL_Trans();
            qlVn.NgonNgu = "vi";
            qlVn.MaQL = tb_doinguql.MaQL;
            qlVn.TenNguoiQL = string.IsNullOrEmpty(Request.Form["HoTenVn"]) ? Request.Form["HoTenEn"] : Request.Form["HoTenVn"];
            qlVn.ChucVu = string.IsNullOrEmpty(Request.Form["ChucVuVn"]) ? Request.Form["ChucVuEn"] : Request.Form["ChucVuVn"];
            qlVn.CauNoi = string.IsNullOrEmpty(Request.Form["CauNoiVn"]) ? Request.Form["CauNoiEn"] : Request.Form["CauNoiVn"];
            qlVn.MoTa = string.IsNullOrEmpty(Request.Form["MoTaVn"]) ? Request.Form["MoTaEn"] : Request.Form["MoTaVn"];


            tb_DoiNguQL_Trans qlEn = new tb_DoiNguQL_Trans();
            qlEn.NgonNgu = "en";
            qlEn.MaQL = tb_doinguql.MaQL;
            qlEn.TenNguoiQL = string.IsNullOrEmpty(Request.Form["HoTenEn"]) ? Request.Form["HoTenEn"] : Request.Form["HoTenEn"];
            qlEn.ChucVu = string.IsNullOrEmpty(Request.Form["ChucVuEn"]) ? Request.Form["ChucVuEn"] : Request.Form["ChucVuEn"];
            qlEn.CauNoi = string.IsNullOrEmpty(Request.Form["CauNoiEn"]) ? Request.Form["CauNoiEn"] : Request.Form["CauNoiEn"];
            qlEn.MoTa = string.IsNullOrEmpty(Request.Form["MoTaEn"]) ? Request.Form["MoTaEn"] : Request.Form["MoTaEn"];

            db.tb_DoiNguQL_Trans.Add(qlVn);
            db.tb_DoiNguQL_Trans.Add(qlEn);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        // GET: /Admin/DoiNguQuanLy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQuanLy tb_doinguql_trans = db.tb_DoiNguQuanLy.Find(id);
            if (tb_doinguql_trans == null)
            {
                return HttpNotFound();
            }
            
            return View(tb_doinguql_trans);
        }

        // POST: /Admin/DoiNguQuanLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQL,HinhAnh, CapBac")] tb_DoiNguQuanLy tb_doinguql)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_doinguql).State = EntityState.Modified;
                db.SaveChanges();
            }
            tb_DoiNguQL_Trans qlVn = new tb_DoiNguQL_Trans();
            qlVn.NgonNgu = "vi";
            qlVn.MaQL = tb_doinguql.MaQL;
            qlVn.TenNguoiQL = string.IsNullOrEmpty(Request.Form["HoTenVn"]) ? Request.Form["HoTenEn"] : Request.Form["HoTenVn"];
            qlVn.ChucVu = string.IsNullOrEmpty(Request.Form["ChucVuVn"]) ? Request.Form["ChucVuEn"] : Request.Form["ChucVuVn"];
            qlVn.CauNoi = string.IsNullOrEmpty(Request.Form["CauNoiVn"]) ? Request.Form["CauNoiEn"] : Request.Form["CauNoiVn"];
            qlVn.MoTa = string.IsNullOrEmpty(Request.Form["MoTaVn"]) ? Request.Form["MoTaEn"] : Request.Form["MoTaVn"];


            tb_DoiNguQL_Trans qlEn = new tb_DoiNguQL_Trans();
            qlEn.NgonNgu = "en";
            qlEn.MaQL = tb_doinguql.MaQL;
            qlEn.TenNguoiQL = string.IsNullOrEmpty(Request.Form["HoTenEn"]) ? Request.Form["HoTenEn"] : Request.Form["HoTenEn"];
            qlEn.ChucVu = string.IsNullOrEmpty(Request.Form["ChucVuEn"]) ? Request.Form["ChucVuEn"] : Request.Form["ChucVuEn"];
            qlEn.CauNoi = string.IsNullOrEmpty(Request.Form["CauNoiEn"]) ? Request.Form["CauNoiEn"] : Request.Form["CauNoiEn"];
            qlEn.MoTa = string.IsNullOrEmpty(Request.Form["MoTaEn"]) ? Request.Form["MoTaEn"] : Request.Form["MoTaEn"];

            db.Entry(qlVn).State = EntityState.Modified;
            db.Entry(qlVn).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        // GET: /Admin/DoiNguQuanLy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiNguQuanLy tb_doinguql_trans = db.tb_DoiNguQuanLy.Find(id);
            if (tb_doinguql_trans == null)
            {
                return HttpNotFound();
            }

            return View(tb_doinguql_trans);
        }

        // POST: /Admin/DoiNguQuanLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

           var tb_doinguql_trans = db.tb_DoiNguQL_Trans.Where(x=>x.MaQL == id).ToList();
            db.tb_DoiNguQL_Trans.RemoveRange(tb_doinguql_trans);
            db.SaveChanges();
            db.tb_DoiNguQuanLy.Remove(db.tb_DoiNguQuanLy.Find(id));
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
