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
    public class SanPhamController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/SanPham/
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Index()
        {
            var tb_sanpham = db.tb_SanPham.Where(x=>x.TrangThai??false).Include(t => t.tb_LoaiSP);
            return View(tb_sanpham.ToList());
        }

        // GET: /Admin/SanPham/Details/5
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_SanPham tb_sanpham = db.tb_SanPham.Find(id);
            if (tb_sanpham == null)
            {
                return HttpNotFound();
            }
            return View(tb_sanpham);
        }

        // GET: /Admin/SanPham/Create
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        // POST: /Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Create([Bind(Include = "MaSP,HinhAnh,TenSanPham,UuDiem,DacDiem,ThanhPhanChinh,LuuY,QuyCachDongGoi,XuatXu,CachDung,GiaThanh,TrangThai,MaLoai")] tb_SanPham tb_sanpham)
        {
            if (ModelState.IsValid)
            {
                db.tb_SanPham.Add(tb_sanpham);
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Sản phẩm", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm sản phẩm\"" + tb_sanpham.TenSanPham + "\"", MaDoiTuong = tb_sanpham.MaSP});
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_sanpham.MaLoai);
            return View(tb_sanpham);
        }

        // GET: /Admin/SanPham/Edit/5
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_SanPham tb_sanpham = db.tb_SanPham.Find(id);
            if (tb_sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_sanpham.MaLoai);
            return View(tb_sanpham);
        }

        // POST: /Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Edit([Bind(Include="MaSP,HinhAnh,TenSanPham,UuDiem,DacDiem,ThanhPhanChinh,LuuY,QuyCachDongGoi,XuatXu,CachDung,GiaThanh,TrangThai,MaLoai")] tb_SanPham tb_sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_sanpham).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Sản phẩm", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa sản phẩm\"" + tb_sanpham.TenSanPham + "\"", MaDoiTuong = tb_sanpham.MaSP });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.tb_LoaiSP, "MaLoaiSP", "TenLoaiSP", tb_sanpham.MaLoai);
            return View(tb_sanpham);
        }

        // GET: /Admin/SanPham/Delete/5
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_SanPham tb_sanpham = db.tb_SanPham.Find(id);
            if (tb_sanpham == null)
            {
                return HttpNotFound();
            }
            return View(tb_sanpham);
        }

        // POST: /Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,1")]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_SanPham tb_sanpham = db.tb_SanPham.Find(id);
            db.Entry(tb_sanpham).State = EntityState.Modified;
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Sản phẩm", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Xóa sản phẩm\"" + tb_sanpham.TenSanPham + "\"", MaDoiTuong = tb_sanpham.MaSP });
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
