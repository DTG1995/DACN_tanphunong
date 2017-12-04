using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DACN_TanPhuNong.Filter;
using DACN_TanPhuNong.Models;

namespace DACN_TanPhuNong.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();

        // GET: /Admin/NguoiDung/
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Index()
        {
            return View(db.tb_NguoiDung.Where(x=>x.TrangThai??false).ToList());
        }

        
        
        // GET: /Admin/NguoiDung/Create
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/NguoiDung/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Create([Bind(Include="TenDangNhap,MatKhau,TrangThai,LoaiND,ThoiGianDNCuoi")] tb_NguoiDung tb_nguoidung)
        {
            var loaiND = Request.Params.GetValues("LoaiND");
            if (loaiND != null)
            {
               string str = "";
                for (int i = 0; i < loaiND.Count(); i++)
                {
                    str += loaiND[i] + ";";
                }
                tb_nguoidung.LoaiND = str.Remove(str.Length -1);
            }
            MD5 md5 =MD5.Create();
            tb_nguoidung.MatKhau = GetMd5Hash(md5, tb_nguoidung.MatKhau);
            
            if (ModelState.IsValid)
            {
                db.tb_NguoiDung.Add(tb_nguoidung);
                db.SaveChanges();
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Người dùng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Thêm người dùng \"" + tb_nguoidung.TenDangNhap + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_nguoidung);
        }

        // GET: /Admin/NguoiDung/Edit/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            if (tb_nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(tb_nguoidung);
        }

        // POST: /Admin/NguoiDung/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Edit([Bind(Include="TenDangNhap,TrangThai,LoaiND")] tb_NguoiDung tb_nguoidung)
        {

            

            var loaiND = Request.Params.GetValues("LoaiND");
            if (loaiND != null)
            {
                string str = "";
                for (int i = 0; i < loaiND.Count(); i++)
                {
                    str += loaiND[i] + ";";
                }
                tb_nguoidung.LoaiND = str.Remove(str.Length - 1);
            }
            if (ModelState.IsValid)
            {
                var tb_nguoiDung = db.tb_NguoiDung.Find(tb_nguoidung.TenDangNhap);
                tb_nguoidung.TrangThai = tb_nguoidung.TrangThai;
                tb_nguoiDung.LoaiND = tb_nguoidung.LoaiND;
                db.Entry(tb_nguoiDung).State = EntityState.Modified;
                db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Người dùng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Sửa người dùng \"" + tb_nguoidung.TenDangNhap + "\"" });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_nguoidung);
        }

        // GET: /Admin/NguoiDung/Delete/5
        [AdminFilter(AllowPermit = "0")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            if (tb_nguoidung == null)
            {
                return HttpNotFound();
            }
            tb_nguoidung.TrangThai = false;
            return View(tb_nguoidung);
        }

        // POST: /Admin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(id);
            tb_nguoidung.TrangThai = false;
            db.Entry(tb_nguoidung).State =EntityState.Modified;
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Người dùng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Xóa người dùng \"" + tb_nguoidung.TenDangNhap + "\"" });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PhanQuyen()
        {
            return View(db.tb_NguoiDung.Where(x => x.TrangThai ?? false).ToList());
        }

        [HttpPost]
        [AdminFilter(AllowPermit = "0")]
        public ActionResult PhanQuyen(string username, string phanquyen)
        {
            tb_NguoiDung tb_nguoidung = db.tb_NguoiDung.Find(username);
            tb_nguoidung.LoaiND = phanquyen;
            db.Entry(tb_nguoidung).State = EntityState.Modified;
            db.tb_NhatKy.Add(new tb_NhatKy { NguoiDung = (string)Session["username"], DoiTuong = "Người dùng", ThaoTac = DateTime.Now.ToString("dd/MM/yyy hh:mm:ss") + " - Phân quyền người dùng \"" + tb_nguoidung.TenDangNhap + "\"" });
            db.SaveChanges();
            return View("SavePhanQuyen");
        }
        [NonAction]
        [AdminFilter(AllowPermit = "0")]
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "TenDangNhap,MatKhau")] tb_NguoiDung tb_nguoidung)
        {
            if (!string.IsNullOrEmpty(tb_nguoidung.TenDangNhap) || !string.IsNullOrEmpty(tb_nguoidung.TenDangNhap))
            {
                MD5 md5 = MD5.Create();
                string passHash = GetMd5Hash(md5, tb_nguoidung.MatKhau);

                tb_NguoiDung user_Login = db.tb_NguoiDung.Where(x => x.TenDangNhap == tb_nguoidung.TenDangNhap &&
                                                                     x.MatKhau == passHash).FirstOrDefault();
                if (user_Login == null)
                {
                    ViewBag.LoginFailer = "Tài khoản hoặc mật khẩu không đúng";
                    ModelState.AddModelError("LoginFailer", "Tài khoản hoặc mật khẩu không đúng");
                    return View();
                }
                else
                {


                    FormsAuthentication.SetAuthCookie(user_Login.TenDangNhap, false);
                    Session["IsAdmin"] = true;
                    Session["Permit"] = user_Login.LoaiND;
                    Session["username"] = user_Login.TenDangNhap;
                    Session["UserLogin"] = user_Login;
                    return RedirectToAction("Index", "Admin");

                }
            }
            return View();
        }

        
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [AdminFilter(AllowPermit = "0")]
        public ActionResult ResetPassword(string id)
        {
            var user = db.tb_NguoiDung.Find(id);
            if (user == null)
                return HttpNotFound();
            MD5 md5 = MD5.Create();
            user.MatKhau = GetMd5Hash(md5, "admin");
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [AdminFilter(AllowPermit="0,1,2,3")]

        public JsonResult ChangePass(string pageold, string passnew)
        {
            var tendangnhap = Session["username"];
            if (tendangnhap == null)
                return Json(new { err = true });
            MD5 md5 = MD5.Create();
            var passmd5 = GetMd5Hash(md5, pageold);
            var user = db.tb_NguoiDung.Where(t => t.TenDangNhap == tendangnhap && t.MatKhau == passmd5).FirstOrDefault();
            if (user == null)
                return Json(new { err = true });
            user.MatKhau = GetMd5Hash(md5, passnew);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new { err = false });
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
