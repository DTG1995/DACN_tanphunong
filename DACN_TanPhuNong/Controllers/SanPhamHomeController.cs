using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_TanPhuNong.Models;
using DACN_TanPhuNong.Languages;
using System.Text.RegularExpressions;

namespace DACN_TanPhuNong.Controllers
{
    public class SanPhamHomeController : Controller
    {
        private db_tanphunongEntities db = new db_tanphunongEntities();
        //
        // GET: /SanPhamHome/
        public ActionResult Index()
        {
            ViewBag.CurrentMenu = "SanPham";
            return View(db.tb_LoaiSP.Where(x=>x.LoaiCha==null).ToList());
        }

        public ActionResult AllByLoai(int? id,int? page)
        {
            ViewBag.CurrentMenu = "SanPham";
            ViewBag.IDCurrent = id;
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            var current = db.tb_LoaiSP.Include("tb_LoaiSP1").Where(x=>x.MaLoaiSP==id).FirstOrDefault();
            
            while (current.tb_LoaiSP2 != null)
            {
                current = current.tb_LoaiSP2;
            }
            ViewBag.LoaiCurrent = current;
            ViewBag.Title= current.tb_LoaiSPTrans.Where(x => x.NgonNgu == lang).Select(x => x.TenLoaiSPTrans).FirstOrDefault();
            if (current != null)
            {
                var listLSP = current.tb_LoaiSP1;
                
                int limit = 12;
                int page1 = page ?? 1;
                var listID = listLSP.Select(x => x.MaLoaiSP).ToList();
                ViewBag.ListLSP = db.tb_LoaiSPTrans.Where(x=>x.NgonNgu==lang && listID.Contains(x.MaLoaiSP)).ToList();
               

                return View();
            }
            return View(new List<tb_SanPham>());
        }
        public ActionResult getListProductsByCategory(int? id, int? page)
        {
            List<Object> list = new List<object>();
            string lang = Request.RequestContext.RouteData.Values["lang"] as string ?? "vi";
            var current = db.tb_LoaiSP.Where(x => x.MaLoaiSP == id).FirstOrDefault();
          //  ViewBag.LoaiCurrent = db.tb_LoaiSPTrans.Where(x => x.NgonNgu == lang && x.MaLoaiSP == id).FirstOrDefault();
           
            if (current != null)
            {
                var listLSP = current.tb_LoaiSP1;

                int limit = 8;
                int page1 = page ?? 1;
                var listID = new List<int>();
                listID.Add(current.MaLoaiSP);
                 listID.AddRange(listLSP.Select(x => x.MaLoaiSP).ToList());
                
                //var numberPage = listID.Count / limit;
               // ViewBag.NumberPage = numberPage + 1;
                
                
                var listSPFull = db.tb_SanPham.Where(x => listID.Contains(x.MaLoai)).ToList();
                var listSP = listSPFull.OrderByDescending(x=>x.MaSP).Skip((page1 - 1) * limit).Take(limit).ToList();
                var numberPage = listSPFull.Count % limit > 0 ? listSPFull.Count / limit + 1 : listSPFull.Count / limit;
                string strlistsp = "";
                for (int i = 0; i < listSP.Count(); i++)
                {
                    tb_SanPhamTrans spTran = listSP[i].tb_SanPhamTrans.FirstOrDefault(y => y.NgonNgu == lang);

                    if (spTran != null && string.IsNullOrWhiteSpace(spTran.TenSanPhamTrans))
                    {
                        lang = lang == "en" ? "vi" : "en";
                        spTran = listSP[i].tb_SanPhamTrans.FirstOrDefault(y => y.NgonNgu == lang);
                    }
                    if(spTran==null || (spTran!=null && string.IsNullOrWhiteSpace(spTran.TenSanPhamTrans)))
                    {
                        continue;
                    }

                        

                    //RegexOptions options = RegexOptions.None;
                    //Regex regex = new Regex("[ ]{2,}", options);
                    //spTran.UuDienTrans = regex.Replace(spTran.UuDienTrans, "<br/>");
                    string uudiem = spTran.UuDienTrans.Length > 150
                        ? spTran.UuDienTrans.Substring(0, 147) + "..."
                        : spTran.UuDienTrans;
                    strlistsp +="<div class=\"col-lg-3 col-md-3 col-sm-4 col-xs-12 item-product\" data-id='product"+listSP[i].MaSP+"'>"+
                        "<img src=\""+listSP[i].HinhAnh+"\" alt=\"Avatar\" class=\"image\">"+
                        "<a href=\"" + Url.RouteUrl("SanPhamDetails", new { id = listSP[i].MaSP, title = UrlEncode.ToFriendlyUrl(spTran.TenSanPhamTrans) }) + "\" style=\"top: 70%;font-weight: bold;color: white;background: #524f4fc7;width: 95%;position: absolute;left:2.5%;height: 20%;\">" +
                       spTran.TenSanPhamTrans+
                                      "</a></div>";
                    strlistsp += "<div class='product-uudiem' id='product" +  listSP[i].MaSP + "'>" +
                                    "<div class='uu-diem'>"+
                                        "<div class='tieu-de'>"+
                                            "<h4><b>"+spTran.TenSanPhamTrans+"</b></h4>"+
                                        "</div>"+
                                        "<div class='noi-dung'>"+
                                            "<p>" + uudiem.Replace("\r\n", "<br/>") + "</p>" +
                                        "</div>"+
                                        "<div class='doc-them'>"+
                                            "<a class='btn btn-custom' href='" + Url.RouteUrl("SanPhamDetails", new { id = listSP[i].MaSP, title = UrlEncode.ToFriendlyUrl(spTran.TenSanPhamTrans) }) +"'>"+GlobalRes.ReadMore+"</a>"+
                                        "</div>"+
                                    "</div>"+                        
                                "</div>";


                }
                  

                  string pagination = "";
                  for (int i = 1; i <= numberPage; i++)
                  {
                      pagination += "<li ";
                      if (i == page1)
                          pagination += "class='active'>";
                      else pagination += "onclick='chuyenTrang(" + i + ")'>";
                      pagination += "<a href='javascript:;'>" + i + "</a></li>";

                  }
                  list.Add(new { pagination = pagination });
                  list.Add(new { listproduct = strlistsp });
                  

               
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int? id)
        {
            ViewBag.CurrentMenu = "SanPham";
            if (id != null)
            {
                string lang= Request.RequestContext.RouteData.Values["lang"] as string??"vi";
                tb_SanPham sanPham = db.tb_SanPham.Find(id);
                var list = sanPham.tb_SanPhamTrans.Where(x => x.NgonNgu == lang && x.MaSP == id).ToList();
                sanPham.tb_SanPhamTrans = list;
                if (sanPham.tb_SanPhamTrans.FirstOrDefault() != null)
                {
                    if (string.IsNullOrWhiteSpace(sanPham.tb_SanPhamTrans.FirstOrDefault().TenSanPhamTrans))
                    {
                        lang = (lang == "en" ? "vi" : "en");
                        sanPham.tb_SanPhamTrans = db.tb_SanPhamTrans.Where(x => x.NgonNgu == lang && x.MaSP == id).ToList();
                    }
                }
                return View(sanPham);
            }
            return PartialView("Error");
        }
	}
}