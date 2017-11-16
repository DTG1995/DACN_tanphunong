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
    public class VideosController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/Videos/
        public ActionResult Index()
        {
            return View(db.tb_Videos.ToList());
        }

        // GET: /Admin/Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Videos tb_videos = db.tb_Videos.Find(id);
            if (tb_videos == null)
            {
                return HttpNotFound();
            }
            return View(tb_videos);
        }

        // GET: /Admin/Videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaVideo,TenVideo,Link")] tb_Videos tb_videos)
        {
            var user = Session["username"] as string;
            tb_videos.NguoiDang = user;
            tb_videos.NgayTao = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tb_Videos.Add(tb_videos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_videos);
        }

        // GET: /Admin/Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Videos tb_videos = db.tb_Videos.Find(id);
            if (tb_videos == null)
            {
                return HttpNotFound();
            }
            return View(tb_videos);
        }

        // POST: /Admin/Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaVideo,TenVideo,Link")] tb_Videos tb_videos)
        {
            var user = Session["username"] as string;
            tb_videos.NguoiDang = user;
            if (ModelState.IsValid)
            {
                db.Entry(tb_videos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_videos);
        }

        // GET: /Admin/Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Videos tb_videos = db.tb_Videos.Find(id);
            if (tb_videos == null)
            {
                return HttpNotFound();
            }
            return View(tb_videos);
        }

        // POST: /Admin/Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Videos tb_videos = db.tb_Videos.Find(id);
            db.tb_Videos.Remove(tb_videos);
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
