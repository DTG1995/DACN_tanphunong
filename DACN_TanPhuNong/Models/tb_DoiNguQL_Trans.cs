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
    
    public partial class tb_DoiNguQL_Trans
    {
        public int MaQL { get; set; }
        public string NgonNgu { get; set; }
        public string TenNguoiQL { get; set; }
        public string ChucVu { get; set; }
        public string MoTa { get; set; }
        public string CauNoi { get; set; }
    
        public virtual tb_DoiNguQuanLy tb_DoiNguQuanLy { get; set; }
    }
}
