using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class BaiVietController : Controller

    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        

        // GET: /Admin/BaiViet/
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Index()
        {    
            return View(db.tb_BaiViet.Where(x=>x.LoaiBaiViet==0).ToList());
        }

        // GET: /Admin/BaiViet/Details/5
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Details(int? id)
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

        // GET: /Admin/BaiViet/Create
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/BaiViet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Create([Bind(Include="MaBV,TieuDe,TomTat,NoiDung,NgayViet,HinhAnh")] tb_BaiViet tb_baiviet)
        {
            
            tb_baiviet.LoaiBaiViet = 0;
            tb_baiviet.NgayViet = DateTime.Now;
            tb_baiviet.NguoiViet = (string) Session["username"];
            if (string.IsNullOrEmpty(tb_baiviet.HinhAnh))
                tb_baiviet.HinhAnh = "/images/BaiViet/default.jpg";
            if (ModelState.IsValid)
            {
                db.tb_BaiViet.Add(tb_baiviet);
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Bài viết", MaDoiTuong = tb_baiviet.MaBV, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm Bài viết \"" + tb_baiviet.TieuDe + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_baiviet);
        }

        // GET: /Admin/BaiViet/Edit/5
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Edit(int? id)
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

        // POST: /Admin/BaiViet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult Edit([Bind(Include = "MaBV,TieuDe,TomTat,NoiDung,NgayViet,HinhAnh")] tb_BaiViet tb_baiviet)
        {
            if(string.IsNullOrEmpty(tb_baiviet.HinhAnh))
                tb_baiviet.HinhAnh = "/images/BaiViet/default.jpg";
            if (ModelState.IsValid)
            {
                db.Entry(tb_baiviet).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Bài viết", MaDoiTuong = tb_baiviet.MaBV, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa Bài viết \""+tb_baiviet.TieuDe+"\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_baiviet);
        }

        // GET: /Admin/BaiViet/Delete/5
        [AdminFilter(AllowPermit = "0,2")]
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

        // POST: /Admin/BaiViet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0,2")]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Find(id);
            db.tb_BaiViet.Remove(tb_baiviet);
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Bài viết", MaDoiTuong = tb_baiviet.MaBV, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Xóa Bài viết \""+tb_baiviet.TieuDe+"\"" });
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
