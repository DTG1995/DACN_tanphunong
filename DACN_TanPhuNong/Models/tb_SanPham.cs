//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DACN_TanPhuNong.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_SanPham
    {
        public tb_SanPham()
        {
            this.tb_SanPhamTrans = new HashSet<tb_SanPhamTrans>();
        }
    
        public int MaSP { get; set; }
        public string HinhAnh { get; set; }
        public string QuyCachDongGoi { get; set; }
        public string XuatXu { get; set; }
        public Nullable<decimal> GiaThanh { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public int MaLoai { get; set; }
        public string NguoiThem { get; set; }
    
        public virtual tb_LoaiSP tb_LoaiSP { get; set; }
        public virtual tb_NguoiDung tb_NguoiDung { get; set; }
        public virtual ICollection<tb_SanPhamTrans> tb_SanPhamTrans { get; set; }
    }
}
