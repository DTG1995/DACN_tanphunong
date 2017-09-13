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
    public class DoiTacController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/DoiTac/
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Index()
        {
            return View(db.tb_DoiTac.ToList());
        }

        // GET: /Admin/DoiTac/Details/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiTac tb_doitac = db.tb_DoiTac.Find(id);
            if (tb_doitac == null)
            {
                return HttpNotFound();
            }
            return View(tb_doitac);
        }

        // GET: /Admin/DoiTac/Create
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/DoiTac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create([Bind(Include="MaDT,TenDT,SDT,Email,DiaChi,ChiTiet,WebsiteDT")] tb_DoiTac tb_doitac)
        {
            if (ModelState.IsValid)
            {
                db.tb_DoiTac.Add(tb_doitac);
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Đối tác", MaDoiTuong = tb_doitac.MaDT, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm đối tác \"" + tb_doitac.TenDT + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_doitac);
        }

        // GET: /Admin/DoiTac/Edit/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiTac tb_doitac = db.tb_DoiTac.Find(id);
            if (tb_doitac == null)
            {
                return HttpNotFound();
            }
            return View(tb_doitac);
        }

        // POST: /Admin/DoiTac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit([Bind(Include="MaDT,TenDT,SDT,Email,DiaChi,ChiTiet,WebsiteDT")] tb_DoiTac tb_doitac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_doitac).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Đối tác", MaDoiTuong = tb_doitac.MaDT, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa đối tác \"" + tb_doitac.TenDT + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_doitac);
        }

        // GET: /Admin/DoiTac/Delete/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiTac tb_doitac = db.tb_DoiTac.Find(id);
            if (tb_doitac == null)
            {
                return HttpNotFound();
            }
            return View(tb_doitac);
        }

        // POST: /Admin/DoiTac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DoiTac tb_doitac = db.tb_DoiTac.Find(id);
            db.tb_DoiTac.Remove(tb_doitac);
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Đối tác", MaDoiTuong = tb_doitac.MaDT, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Xóa đối tác \"" + tb_doitac.TenDT + "\"" });
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
