using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class PhotosController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Admin/Photos/
        public ActionResult Index()
        {
            return View();
        }
        [AdminFilter(AllowPermit="0")]
        [HttpPost]
        public ActionResult Add()
        {
            List<string> Images = Request.Form.GetValues("Image").ToList();
            var id = int.Parse(Request.Form["MaAlbum"] as string ?? "0");
            var moTa = Request.Form["MoTa"] as string??"";
            if (db.tb_Album.Find(id)!=null)
            {
                for (int i = 0; i < Images.Count; i++)
                {
                    if(!string.IsNullOrEmpty(Images[i])){
                    db.tb_Photos.Add(new tb_Photos{
                        Link = Images[i],
                        MaAlbum = id,
                        MoTa = moTa
                    });
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Details", "Album", new {id= id });
            }
            return HttpNotFound();
        }
        [AdminFilter(AllowPermit="0")]
        [HttpPost]
        public ActionResult Delete(int?id, int? MaAlbum)
        {
            var photo = db.tb_Photos.Find(id);
            if (photo == null)
                return HttpNotFound();
            db.tb_Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Details", "Album", new { id = MaAlbum });
        }
	}
}