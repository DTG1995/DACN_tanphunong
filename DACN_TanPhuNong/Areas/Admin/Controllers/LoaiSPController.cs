using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/LoaiSP/
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Index()
        {
            var tb_loaisp = db.tb_LoaiSP.Include(t => t.tb_LoaiSP2);
            return View(tb_loaisp.Where(x=>x.TrangThai??false).ToList());
        }

        // GET: /Admin/LoaiSP/Details/5
        [AdminFilter(AllowPermit = "0,1")]
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
        [AdminFilter(AllowPermit = "0,1")]
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
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Create([Bind(Include="MaLoaiSP,TenLoaiSP,MoTa,LoaiCha,TrangThai")] tb_LoaiSP tb_loaisp)
        {
            if (ModelState.IsValid)
            {
                db.tb_LoaiSP.Add(tb_loaisp);
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Loại Sản Phẩm", MaDoiTuong = tb_loaisp.MaLoaiSP, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm loại sản phẩm \"" + tb_loaisp.TenLoaiSP + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_loaisp.LoaiCha);
            return View(tb_loaisp);
        }

        // GET: /Admin/LoaiSP/Edit/5

        [AdminFilter(AllowPermit = "0,1")]
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
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Edit([Bind(Include="MaLoaiSP,TenLoaiSP,MoTa,LoaiCha,TrangThai")] tb_LoaiSP tb_loaisp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_loaisp).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Loại Sản Phẩm", MaDoiTuong = tb_loaisp.MaLoaiSP, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm loại sản phẩm \"" + tb_loaisp.TenLoaiSP + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiCha = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_loaisp.LoaiCha);
            return View(tb_loaisp);
        }

        // GET: /Admin/LoaiSP/Delete/5
        [AdminFilter(AllowPermit = "0,1")]
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

        [AdminFilter(AllowPermit = "0,1")]
        // POST: /Admin/LoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_LoaiSP tb_loaisp = db.tb_LoaiSP.Find(id);
            db.Entry(tb_loaisp).State = EntityState.Modified;
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Loại Sản Phẩm", MaDoiTuong = tb_loaisp.MaLoaiSP, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm loại sản phẩm \"" + tb_loaisp.TenLoaiSP + "\"" });
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
