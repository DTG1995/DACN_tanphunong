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
    
    public partial class tb_LoaiSP
    {
        public tb_LoaiSP()
        {
            this.tb_LoaiSP1 = new HashSet<tb_LoaiSP>();
            this.tb_LoaiSPTrans = new HashSet<tb_LoaiSPTrans>();
            this.tb_SanPham = new HashSet<tb_SanPham>();
        }
    
        public int MaLoaiSP { get; set; }
        public Nullable<int> LoaiCha { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public string NguoiThem { get; set; }
    
        public virtual ICollection<tb_LoaiSP> tb_LoaiSP1 { get; set; }
        public virtual tb_LoaiSP tb_LoaiSP2 { get; set; }
        public virtual tb_NguoiDung tb_NguoiDung { get; set; }
        public virtual ICollection<tb_LoaiSPTrans> tb_LoaiSPTrans { get; set; }
        public virtual ICollection<tb_SanPham> tb_SanPham { get; set; }
    }
}
