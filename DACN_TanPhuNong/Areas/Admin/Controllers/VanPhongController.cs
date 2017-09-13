using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class VanPhongController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/VanPhong/
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Index()
        {
            return View(db.tb_VanPhong.ToList());
        }

        // GET: /Admin/VanPhong/Details/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VanPhong tb_vanphong = db.tb_VanPhong.Find(id);
            if (tb_vanphong == null)
            {
                return HttpNotFound();
            }
            return View(tb_vanphong);
        }

        // GET: /Admin/VanPhong/Create
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/VanPhong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create([Bind(Include="MaVP,TenVP,DiaChi,SDT,Email,ChiTiet")] tb_VanPhong tb_vanphong)
        {
            if (ModelState.IsValid)
            {
                db.tb_VanPhong.Add(tb_vanphong);

                try { 
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Văn phòng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm văn phòng \"" + tb_vanphong.TenVP + "\"", MaDoiTuong = tb_vanphong.MaVP });
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string str = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            str += "\n" + String.Format("- Property): \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                   
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(tb_vanphong);
        }

        // GET: /Admin/VanPhong/Edit/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VanPhong tb_vanphong = db.tb_VanPhong.Find(id);
            if (tb_vanphong == null)
            {
                return HttpNotFound();
            }
            return View(tb_vanphong);
        }

        // POST: /Admin/VanPhong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit([Bind(Include="MaVP,TenVP,DiaChi,SDT,Email,ChiTiet")] tb_VanPhong tb_vanphong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_vanphong).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Văn phòng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa văn phòng \"" + tb_vanphong.TenVP + "\"", MaDoiTuong = tb_vanphong.MaVP });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_vanphong);
        }

        // GET: /Admin/VanPhong/Delete/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_VanPhong tb_vanphong = db.tb_VanPhong.Find(id);
            if (tb_vanphong == null)
            {
                return HttpNotFound();
            }
            return View(tb_vanphong);
        }

        // POST: /Admin/VanPhong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_VanPhong tb_vanphong = db.tb_VanPhong.Find(id);
            db.tb_VanPhong.Remove(tb_vanphong);
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Văn phòng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Xóa văn phòng \"" + tb_vanphong.TenVP + "\"", MaDoiTuong = tb_vanphong.MaVP });
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
