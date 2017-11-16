using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using PagedList;
using DACN_TanPhuNong.Languages;
namespace DACN_TanPhuNong.Controllers
{
    public class BaiVietController : Controller
    {
        //
        // GET: /BaiViet/
        db_tanphunongEntities db = new db_tanphunongEntities();
        public ActionResult Index(int? loaibv, int? page)
        {
            ViewBag.CurrentMenu = "BaiViet";
            if (loaibv == null)
                return HttpNotFound();
            var lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            int page1 = page??1;
            var list = db.tb_BaiViet.Where(t => t.LoaiBaiViet == loaibv && t.NoiBo!=true).ToList();
            var model = list.Select(x => new tb_BaiViet
            {
                HinhAnh=x.HinhAnh,
                NgayViet = x.NgayViet,
                NguoiViet = x.NguoiViet,
                MaBV = x.MaBV,
                tb_BaiVietTrans = x.tb_BaiVietTrans.Where(y => y.NgonNgu == lang).ToList()
            });
            switch(loaibv){
                case 0:
                    ViewBag.Title = GlobalRes.thong_bao;
                    break;
                case 1:
                    ViewBag.Title = GlobalRes.Careers;
                    break;
                case 2:
                    ViewBag.Title = GlobalRes.News;
                    break;
                case 3:
                    ViewBag.Title = GlobalRes.Conferences;
                    break;
                case 4:
                    ViewBag.Title = GlobalRes.Images + ", Video";
                    break;
                default:
                    ViewBag.Title = "Not found";
                    break;
            }
            ViewBag.LoaiBV = loaibv;

            return View(model.ToPagedList(page1, 5));
        }
        public ActionResult Detail(int ?id)
        {
            ViewBag.CurrentMenu = "BaiViet";
            if (id == null)
                return HttpNotFound();
            var lang = RouteData.Values["lang"] as string ?? "vi";
            var bv = db.tb_BaiViet.Find(id);
            if (bv == null)
                return HttpNotFound();
            ViewBag.Lang = lang;
            return View(bv);
        }
        public ActionResult thongBaoNoiBo(int? page)
        {
            bool check =(bool?) Session["NoiBo"] ?? false;
            if (!check)
            {
                return RedirectToAction("InputCodeInternal");
            }
            var lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            int page1 = page ?? 1;
            var list = db.tb_BaiViet.Where(t => t.LoaiBaiViet == 0 && t.NoiBo == true).ToList();
            var model = list.Select(x => new tb_BaiViet
            {
                HinhAnh = x.HinhAnh,
                NgayViet = x.NgayViet,
                NguoiViet = x.NguoiViet,
                MaBV = x.MaBV,
                tb_BaiVietTrans = x.tb_BaiVietTrans.Where(y => y.NgonNgu == lang).ToList()
            });
            return View(model.ToPagedList(page1, 5));
        }
        public ActionResult InputCodeInternal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InputCodeInternal(string codeInternal)
        {
            var code = db.tb_TuyChon.Where(x => x.TenTuyChon == "CodeInternal" ).FirstOrDefault();
            if (code == null) {
                ViewBag.ErrorCode = "Có vẻ quản trị viên chưa set code!!!!!";
            }
            else
            {
                if (code.NoiDungTuyChon == codeInternal)
                {
                    Session["NoiBo"] = true;
                    return RedirectToAction("thongBaoNoiBo");
                }
                else
                {
                    ViewBag.ErrorCode = "Code bạn nhập không đúng";
                }
            }
            return View();
        }
    }
}