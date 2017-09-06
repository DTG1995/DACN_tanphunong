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
    public class NguoiDungController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/NguoiDung/
        public ActionResult Index()
        {
            return View(db.tb_NguoiDung.ToList());
        }

        // GET: /Admin/NguoiDung/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            if (tb_nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(tb_nguoidung);
        }

        // GET: /Admin/NguoiDung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/NguoiDung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TenDangNhap,MatKhau,TrangThai,LoaiND,ThoiGianDNCuoi")] tb_NguoiDung tb_nguoidung)
        {
            var loaiND = Request.Params.GetValues("LoaiND");
            if (loaiND != null)
            {
               string str = "";
                for (int i = 0; i < loaiND.Count(); i++)
                {
                    str += loaiND[i] + ";";
                }
                tb_nguoidung.LoaiND = str.Remove(str.Length -1);
            }
            
            
            if (ModelState.IsValid)
            {
                db.tb_NguoiDung.Add(tb_nguoidung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_nguoidung);
        }

        // GET: /Admin/NguoiDung/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            if (tb_nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(tb_nguoidung);
        }

        // POST: /Admin/NguoiDung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TenDangNhap,MatKhau,TrangThai,LoaiND,ThoiGianDNCuoi")] tb_NguoiDung tb_nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_nguoidung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_nguoidung);
        }

        // GET: /Admin/NguoiDung/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            if (tb_nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(tb_nguoidung);
        }

        // POST: /Admin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            db.tb_NguoiDung.Remove(tb_nguoidung);
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
