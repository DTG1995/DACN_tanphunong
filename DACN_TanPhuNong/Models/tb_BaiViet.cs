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
    
    public partial class tb_BaiViet
    {
        public tb_BaiViet()
        {
            this.tb_BaiVietTrans = new HashSet<tb_BaiVietTrans>();
        }
    
        public int MaBV { get; set; }
        public Nullable<int> LoaiBaiViet { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiViet { get; set; }
        public Nullable<bool> NoiBo { get; set; }
        public Nullable<System.DateTime> NgayViet { get; set; }
    
        public virtual tb_NguoiDung tb_NguoiDung { get; set; }
        public virtual ICollection<tb_BaiVietTrans> tb_BaiVietTrans { get; set; }
    }
}
