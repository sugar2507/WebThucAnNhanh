﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanThucAnNhanh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FEEDBACK
    {
        public int MAFEEDBACK { get; set; }
        [StringLength(50, ErrorMessage = "Không được nhập quá 50 ký tự")]
        public string TENKH { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
        public int SDT { get; set; }
        [StringLength(200, ErrorMessage = "Không được nhập quá 200 ký tự")]
        [Required(ErrorMessage = "Bạn chưa nội dung")]
        public string NOIDUNG { get; set; }
    }
}
