using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhachSan.ViewModels
{
    public class KhachHangVM
    {
        [Required]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Length Name[5->30]")]
        public string HoTen { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Length User-Name[5->30]")]
        public string TenDangNhap { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Length Password[5->30]")]
        public string MatKhau { get; set; }

        [Compare("MatKhau", ErrorMessage ="Password is not valid")]
        public string ComparePassword { get; set; }
        public string SoCMND { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Length Address[5->100]")]
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}