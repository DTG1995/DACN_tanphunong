using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class TuyenDungController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/BaiViet/
        public ActionResult Index()
        {
            return View(db.tb_BaiViet.Where(x => x.LoaiBaiViet == 0).ToList());
        }

        // GET: /Admin/BaiViet/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/BaiViet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBV,NoiDung,NgayViet,HinhAnh")] tb_BaiViet tb_baiviet)
        {
            tb_baiviet.LoaiBaiViet = 0;
            if (ModelState.IsValid)
            {
                db.tb_BaiViet.Add(tb_baiviet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_baiviet);
        }

        // GET: /Admin/BaiViet/Edit/5
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
        public ActionResult Edit([Bind(Include = "MaBV,NoiDung,NgayViet,HinhAnh")] tb_BaiViet tb_baiviet)
        {
            tb_baiviet.LoaiBaiViet = 0;
            if (ModelState.IsValid)
            {
                db.Entry(tb_baiviet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_baiviet);
        }

        // GET: /Admin/BaiViet/Delete/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            tb_BaiViet tb_baiviet = db.tb_BaiViet.Find(id);
            db.tb_BaiViet.Remove(tb_baiviet);
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
