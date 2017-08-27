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
    public class LoaiSPController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/LoaiSP/
        public ActionResult Index()
        {
            var tb_loaisp = db.tb_LoaiSP.Include(t => t.tb_LoaiSP2);
            return View(tb_loaisp.ToList());
        }

        // GET: /Admin/LoaiSP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSP tb_loaisp = db.tb_LoaiSP.Find(id);
            if (tb_loaisp == null)
            {
                return HttpNotFound();
            }
            return View(tb_loaisp);
        }

        // GET: /Admin/LoaiSP/Create
        public ActionResult Create()
        {
            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        // POST: /Admin/LoaiSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaLoaiSP,TenLoaiSP,MoTa,LoaiCha,TrangThai")] tb_LoaiSP tb_loaisp)
        {
            if (ModelState.IsValid)
            {
                db.tb_LoaiSP.Add(tb_loaisp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_loaisp.LoaiCha);
            return View(tb_loaisp);
        }

        // GET: /Admin/LoaiSP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSP tb_loaisp = db.tb_LoaiSP.Find(id);
            if (tb_loaisp == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_loaisp.LoaiCha);
            return View(tb_loaisp);
        }

        // POST: /Admin/LoaiSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaLoaiSP,TenLoaiSP,MoTa,LoaiCha,TrangThai")] tb_LoaiSP tb_loaisp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_loaisp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_loaisp.LoaiCha);
            return View(tb_loaisp);
        }

        // GET: /Admin/LoaiSP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiSP tb_loaisp = db.tb_LoaiSP.Find(id);
            if (tb_loaisp == null)
            {
                return HttpNotFound();
            }
            return View(tb_loaisp);
        }

        // POST: /Admin/LoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_LoaiSP tb_loaisp = db.tb_LoaiSP.Find(id);
            db.tb_LoaiSP.Remove(tb_loaisp);
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
