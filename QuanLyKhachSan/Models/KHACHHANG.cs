
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace QuanLyKhachSan.Models
{

using System;
    using System.Collections.Generic;
    
public partial class KHACHHANG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public KHACHHANG()
    {

        this.DATPHONGs = new HashSet<DATPHONG>();

    }


    public string MaKH { get; set; }

    public string HoTen { get; set; }

    public string TenDangNhap { get; set; }

    public string MatKhau { get; set; }

    public string SoCMND { get; set; }

    public string DiaChi { get; set; }

    public string SoDienThoai { get; set; }

    public string MoTa { get; set; }

    public string Email { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

}

}
