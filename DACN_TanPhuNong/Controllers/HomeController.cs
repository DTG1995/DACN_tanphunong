using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using DACN_TanPhuNong.Languages;

namespace DACN_TanPhuNong.Controllers
{
    public class HomeController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        public ActionResult Index(string s)
        {
            ViewBag.CurrentMenu = "Home";
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
           
            string tri_an = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAn" + lang).Select(x => x.NoiDungTuyChon).FirstOrDefault()  ?? db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAn" + (lang == "vi" ? "en" : "vi")).Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.TriAn = !string.IsNullOrEmpty(tri_an) ? tri_an.Substring(0, tri_an.IndexOf("</p>") == -1 ? 0 : tri_an.IndexOf("</p>")) + "</p>" : "";

            return View();
        }

        public ActionResult TriAn()
        {
            ViewBag.CurrentMenu = "Home";
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            ViewBag.TriAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAn" + lang).Select(x => x.NoiDungTuyChon).FirstOrDefault() ?? db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAn" + (lang == "vi" ? "en" : "vi")).Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }

        //public ActionResult LienHe()
        //{
        //    ViewBag.CurrentMenu = "LienHe";
        //    ViewBag.CurrentMenu = "LienHe";
        //    ViewBag.ContentLienHe =
        //        db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentLienHe").Select(x => x.NoiDungTuyChon).FirstOrDefault();
        //    return View();
        //}

        public ActionResult SlideShow()
        {
            var rd = ControllerContext.ParentActionViewContext.RouteData;
            var currentAction = rd.GetRequiredString("action");
            var currentController = rd.GetRequiredString("controller");
            string[] slideShow = (db.tb_TuyChon.Where(x => x.TenTuyChon == "SlideShow").Select(x => x.NoiDungTuyChon).FirstOrDefault() ?? "").Split(';');
            if (currentAction == "Index"&&currentController == "Home")
            {
                return PartialView("_SlideShow", slideShow);
                
            }

            slideShow = new string[] { slideShow.Last() };
            return PartialView("SlideShow", slideShow);
        }

        public ActionResult Abouts()
        {

            ViewBag.CurrentMenu = "Abouts";
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            ViewBag.LichSu = db.tb_TuyChon.Where(x => x.TenTuyChon == "LichSu" + lang).Select(x => x.NoiDungTuyChon).FirstOrDefault() ?? db.tb_TuyChon.Where(x => x.TenTuyChon == "LichSu" + (lang == "vi" ? "en" : "vi")).Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.DSQL = ViewBag.DSQL = db.tb_DoiNguQuanLy.ToList().Select(b => new tb_DoiNguQuanLy
            {
                MaQL = b.MaQL,
                HinhAnh = b.HinhAnh,
                ThuBac = b.ThuBac,
                tb_DoiNguQL_Trans = b.tb_DoiNguQL_Trans.Where(x => x.NgonNgu == lang).FirstOrDefault() == null ? b.tb_DoiNguQL_Trans : b.tb_DoiNguQL_Trans.Where(x => x.NgonNgu == lang).ToList()

            }).OrderBy(x => x.ThuBac); ;

            ViewBag.CurrentPage = "asdasd"+ GlobalRes.About;
            return View();
        }
        public ActionResult getMenuPhan()
        {
            var lang = Request.RequestContext.RouteData.Values["lang"] as string??"vi";
            var lsp = db.tb_LoaiSP.Where(x => x.LoaiCha == null).Select(x=>x.MaLoaiSP);
            var dslsp = db.tb_LoaiSPTrans.Where(x => x.NgonNgu == lang && lsp.Contains(x.MaLoaiSP)).ToList();
            return PartialView("_MenuSP",dslsp);
        }
    }
}