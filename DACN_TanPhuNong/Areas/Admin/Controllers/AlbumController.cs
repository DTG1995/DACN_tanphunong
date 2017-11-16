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
    public class AlbumController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/Album/
        public ActionResult Index()
        {
            return View(db.tb_Album.ToList());
        }
        // GET: /Admin/Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_album = db.tb_Album.Find(id);
            if (tb_album == null)
            {
                return HttpNotFound();
            }
            return View(tb_album);
        }

        // GET: /Admin/Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaAlbum,TenAlbum,HinhAnh,MoTa")] tb_Album tb_album)
        {
            tb_album.NgayTao = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tb_Album.Add(tb_album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_album);
        }

        // GET: /Admin/Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_album = db.tb_Album.Find(id);
            if (tb_album == null)
            {
                return HttpNotFound();
            }
            return View(tb_album);
        }

        // POST: /Admin/Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaAlbum,TenAlbum,HinhAnh,MoTa")] tb_Album tb_album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_album);
        }

        // GET: /Admin/Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_album = db.tb_Album.Find(id);
            if (tb_album == null)
            {
                return HttpNotFound();
            }
            return View(tb_album);
        }

        // POST: /Admin/Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Album tb_album = db.tb_Album.Find(id);
            db.tb_Album.Remove(tb_album);
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
