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
    
    public partial class tb_DoiNguQuanLy
    {
        public tb_DoiNguQuanLy()
        {
            this.tb_DoiNguQL_Trans = new HashSet<tb_DoiNguQL_Trans>();
        }
    
        public int MaQL { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> ThuBac { get; set; }
    
        public virtual ICollection<tb_DoiNguQL_Trans> tb_DoiNguQL_Trans { get; set; }
    }
}