﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_tanphunongEntities : DbContext
    {
        public db_tanphunongEntities()
            : base("name=db_tanphunongEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_BaiViet> tb_BaiViet { get; set; }
        public virtual DbSet<tb_DoiTac> tb_DoiTac { get; set; }
        public virtual DbSet<tb_LoaiSP> tb_LoaiSP { get; set; }
        public virtual DbSet<tb_SanPham> tb_SanPham { get; set; }
        public virtual DbSet<tb_TuyChon> tb_TuyChon { get; set; }
        public virtual DbSet<tb_VanPhong> tb_VanPhong { get; set; }
        public virtual DbSet<tb_NhatKy> tb_NhatKy { get; set; }
        public virtual DbSet<tb_NguoiDung> tb_NguoiDung { get; set; }
    }
}
