using System;
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
            var opTriAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAnvi").FirstOrDefault();
                    
            var tri_an = opTriAn != null ? opTriAn.NoiDungTuyChon : "";
            ViewBag.TriAnVi = tri_an;
            opTriAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "TriAnen").FirstOrDefault();
            tri_an = opTriAn != null ? opTriAn.NoiDungTuyChon : "";
            ViewBag.TriAnEn = tri_an;
            ViewBag.SlideShow1 = (db.tb_TuyChon.Where(x => x.TenTuyChon == "SlideShow1").Select(x => x.NoiDungTuyChon).FirstOrDefault() ?? "").Split(';');
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
        [HttpPost]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult SaveFeateredPhotos(string slideShow1)
        {
            tb_TuyChon tuyChon = db.tb_TuyChon.FirstOrDefault(x => x.TenTuyChon == "SlideShow1");
            if (tuyChon == null)
                db.tb_TuyChon.Add(new tb_TuyChon { TenTuyChon = "SlideShow1", NoiDungTuyChon = slideShow1 });
            else
            {
                tuyChon.NoiDungTuyChon = slideShow1;
                db.tb_TuyChon.Attach(tuyChon);
                db.Entry(tuyChon).State = EntityState.Modified;
            }
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Trang chủ", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa nội dung ảnh nổi bật" });
            int rows = db.SaveChanges();
            return RedirectToAction("Index");
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
            ViewBag.ContentLienHeVn =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentLienHevn").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.ContentLienHeEn =
                db.tb_TuyChon.Where(x => x.TenTuyChon == "ContentLienHeen").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.DSSocial = db.tb_TuyChon.Where(x => x.TenTuyChon == "Social").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }

        [AdminFilter(AllowPermit = "0")]
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


        [AdminFilter(AllowPermit="0")]
        public ActionResult Abouts()
        {
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            var opTriAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "LichSuvi").FirstOrDefault();

            var tri_an = opTriAn != null ? opTriAn.NoiDungTuyChon : "";
            ViewBag.LichSuVi = tri_an;
            opTriAn = db.tb_TuyChon.Where(x => x.TenTuyChon == "LichSuen").FirstOrDefault();
            tri_an = opTriAn != null ? opTriAn.NoiDungTuyChon : "";
            ViewBag.LichSuEn = tri_an;
            ViewBag.DSQL = db.tb_DoiNguQuanLy.ToList().Select(b => new tb_DoiNguQuanLy
            {
                MaQL = b.MaQL,
                HinhAnh = b.HinhAnh,
                ThuBac = b.ThuBac,
                tb_DoiNguQL_Trans = b.tb_DoiNguQL_Trans.Where(x => x.NgonNgu == lang).FirstOrDefault() == null ? b.tb_DoiNguQL_Trans : b.tb_DoiNguQL_Trans.Where(x => x.NgonNgu == lang).ToList()

            });
            return View();
        }
       
        
        [AdminFilter(AllowPermit="0")]
        public ActionResult Footer(){
            ViewBag.ContentFooeterVn = db.tb_TuyChon.Where(x => x.TenTuyChon == "noiDungfootervn").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.ContentFooeterEn = db.tb_TuyChon.Where(x => x.TenTuyChon == "noiDungfooteren").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.LienHeFooeterVn = db.tb_TuyChon.Where(x => x.TenTuyChon == "lienHeFootervn").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.LienHEFooeterEn = db.tb_TuyChon.Where(x => x.TenTuyChon == "lienHeFooteren").Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.Socials = db.tb_TuyChon.Where(x=>x.Nhom == "Social").ToList();
            return View();
        }
        [AdminFilter (AllowPermit="0")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChangeSocial(List<string> listSocialName, List<string> listSocialUrl, string lienHeVn, string footerVn, string lienHeEn, string footerEn)
        {
            listSocialName = Request.Form.GetValues("MXH").ToList();
            listSocialUrl = Request.Form.GetValues("socialUrl").ToList();

            var listOption = db.tb_TuyChon.Where(x => x.Nhom == "Social" || x.Nhom=="footer").ToList();
            db.tb_TuyChon.RemoveRange(listOption);
            db.SaveChanges();
            listOption = new List<tb_TuyChon>();
            listOption.Add(new tb_TuyChon
            {
                Nhom = "footer",
                TenTuyChon = "lienHeFootervi",
                NoiDungTuyChon = lienHeVn
            });

            listOption.Add(new tb_TuyChon
            {
                Nhom = "footer",
                TenTuyChon = "lienHeFooteren",
                NoiDungTuyChon = string.IsNullOrEmpty(lienHeEn) ? lienHeVn : lienHeEn
            });
            listOption.Add(new tb_TuyChon
            {
                Nhom = "footer",
                TenTuyChon = "noiDungfootervi",
                NoiDungTuyChon = footerVn
            });

            listOption.Add(new tb_TuyChon
            {
                Nhom = "footer",
                TenTuyChon = "noiDungfooteren",
                NoiDungTuyChon = string.IsNullOrEmpty(footerEn) ? footerVn : footerEn
            });
            if (listSocialName != null)
            {
                for (int i = 0; i < listSocialName.Count; i++)
                {
                    string link = listSocialUrl[i] ?? "#";
                    if (link.Length > 4 && !link.Substring(0, 4).Equals("http") && link != "#")
                        link = "http://" + link;
                    listOption.Add(new tb_TuyChon
                    {
                        Nhom= "Social",
                        TenTuyChon = listSocialName[i],
                        NoiDungTuyChon = link
                    });
                }
            }
            db.tb_TuyChon.AddRange(listOption);
            db.SaveChanges();
            return RedirectToAction("Footer");
        }

    
    }
}