﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;
namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    
    public class UngDungController : Controller
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /Admin/UngDung/
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Index()
        {
            ViewBag.ContentHome =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentHome").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.NameEnterprise =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "NameEnterprise").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.DesEnterprise =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "DesEnterprise").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.VeChungToi =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "VeChungToi").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.LienHe =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "LienHe").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.SanPhamFooter =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "SanPhamFooter").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.SlideShow =
                (db.tb_TuyChon.Where(x => x.TenTuyChon == "SlideShow").Select(x => x.NoiDungTuyChon).FirstOrDefault() ?? "").Split(';');
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        [AdminFilter(AllowPermit = "0")]

        public string SaveContentHome(string txtContentHome)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "ContentHome");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon {TenTuyChon = "ContentHome", NoiDungTuyChon = txtContentHome});
            else
            {
                tuyChon.NoiDungTuyChon = txtContentHome;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Trang chủ", MaDoiTuong = tuyChon.MaTuyChon, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa nội dung trang chủ" });
            }
            int rows = db.SaveChanges();
            if (rows > 0)
                return "true";
            return "false";
        }
        [HttpPost]
        [AdminFilter(AllowPermit = "0")]
        public string SaveHeader(string txtTenDN, string txtMoTa, string slideShow)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "NameEnterprise");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "NameEnterprise", NoiDungTuyChon = txtTenDN });
            else
            {
                tuyChon.NoiDungTuyChon = txtTenDN;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "DesEnterprise");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "DesEnterprise", NoiDungTuyChon = txtMoTa });
            else
            {
                tuyChon.NoiDungTuyChon = txtMoTa;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "SlideShow");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "SlideShow", NoiDungTuyChon = slideShow });
            else
            {
                tuyChon.NoiDungTuyChon = slideShow;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            //string path = "~/";
            //if (Request.Files.Count > 0)
            //{
            //    string tg = DateTime.Now.ToString("ddMMyyyy_");
            //    string pathToSave = Server.MapPath(path);
            //    string filename = tg + Path.GetFileName(Request.Files[0].FileName);
            //    wa_posts.Picture = Path.Combine(path, filename);
            //    Request.Files[0].SaveAs(Path.Combine(pathToSave, filename));
            //}
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Trang chủ", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa nội dung header" });
            int rows = db.SaveChanges();
            if (rows > 0)
                return "true";
            return "false";
        }
        [ValidateInput(false)]
        [HttpPost]
        [AdminFilter(AllowPermit = "0")]
        public string SaveFooter(string txtVeChungToi, string txtLienHe, string txtSanPham)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "VeChungToi");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "VeChungToi", NoiDungTuyChon = txtVeChungToi });
            else
            {
                tuyChon.NoiDungTuyChon = txtVeChungToi;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "LienHe");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "LienHe", NoiDungTuyChon = txtLienHe });
            else
            {
                tuyChon.NoiDungTuyChon = txtLienHe;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            
            tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "SanPhamFooter");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "SanPhamFooter", NoiDungTuyChon = txtSanPham });
            else
            {
                tuyChon.NoiDungTuyChon = txtSanPham;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Trang chủ", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa nội dung footer" });
            if (db.SaveChanges() > 0)
                return "true";
            return "false";

        }
        [AdminFilter(AllowPermit = "0")]
        public ActionResult LienHe()
        {
            ViewBag.ContentLienHe =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentLienHe").Select(x => x.NoiDungTuyChon).FirstOrDefault();

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult LienHe(string txtContact)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "ContentLienHe");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "ContentLienHe", NoiDungTuyChon = txtContact });
            else
            {
                tuyChon.NoiDungTuyChon = txtContact;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Trang liên hệ", MaDoiTuong = tuyChon.MaTuyChon, ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa nội dung trang liên hệ" });
            }
            db.SaveChanges();
            return View();
        }
    }
}