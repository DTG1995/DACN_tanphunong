﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    using System.ComponentModel.DataAnnotations;
    
    public partial class tb_VanPhong
    {
        public int MaVP { get; set; }
        [Display(Name = "Tên văn phòng")]
        public string TenVP { get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Giới thiệu")]
        public string ChiTiet { get; set; }
    }
}
