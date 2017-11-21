using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using System.Net.Mail;
using System.Net;
namespace DACN_TanPhuNong.Controllers
{
    public class PhanHoiHomeController : BaseController
    {
        db_tanphunongEntities db = new db_tanphunongEntities();
        // Gui Phan Hoi
        [HttpGet]
        public  ActionResult GuiPhanHoi()
        {
            ViewBag.CurrentMenu = "PhanHoi";

            var lang = RouteData.Values["lang"] as string ?? "vi";
            ViewBag.ContactLienHe = db.tb_TuyChon.Where(x => x.TenTuyChon == ("ContentLienHe" + lang)).Select(x => x.NoiDungTuyChon).FirstOrDefault();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuiPhanHoi(tb_PhanHoi phanhoi)
        {
            var lang = RouteData.Values["lang"] as string ?? "vi";
            ViewBag.ContactLienHe = db.tb_TuyChon.Where(x => x.TenTuyChon == ("ContentLienHe"+lang)).Select(x => x.NoiDungTuyChon).FirstOrDefault();
            ViewBag.CurrentMenu = "PhanHoi";
            if (ModelState.IsValid)
            {
                phanhoi.TrangThai = 0;
                db.tb_PhanHoi.Add(phanhoi);
                db.SaveChanges();
                TempData["ThongBao"] = "ThanhCong";
              
            }
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1},{2})</p><p>Message:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("tiengioiit@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("dinhtiengioi@gmail.com");  // replace with valid value
                message.Subject = "Feelback tanphunong";
                message.Body = string.Format(body, phanhoi.HoTen, phanhoi.Email,phanhoi.SDT, phanhoi.NoiDung);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "dinhtiengioi@gmail.com",  // replace with valid value
                        Password = "a01693638116"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    
                    smtp.Send(message);
                    
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}