
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
    
public partial class DATPHONG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public DATPHONG()
    {

        this.HOADONs = new HashSet<HOADON>();

    }


    public string MaDP { get; set; }

    public string MaPhong { get; set; }

    public string MaKH { get; set; }

    public Nullable<System.DateTime> NgayBatDau { get; set; }

    public Nullable<System.DateTime> NgayTraPhong { get; set; }

    public Nullable<System.DateTime> NgayDat { get; set; }

    public Nullable<decimal> DonGia { get; set; }

    public string MoTa { get; set; }

    public string TinhTrang { get; set; }



    public virtual KHACHHANG KHACHHANG { get; set; }

    public virtual PHONG PHONG { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<HOADON> HOADONs { get; set; }

}

}
