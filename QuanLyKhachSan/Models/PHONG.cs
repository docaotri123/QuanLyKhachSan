
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
    
public partial class PHONG
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PHONG()
    {

        this.DATPHONGs = new HashSet<DATPHONG>();

        this.TRANGTHAIPHONGs = new HashSet<TRANGTHAIPHONG>();

    }


    public string MaPhong { get; set; }

    public string LoaiPhong { get; set; }

    public Nullable<int> SoPhong { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

    public virtual LOAIPHONG LOAIPHONG1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TRANGTHAIPHONG> TRANGTHAIPHONGs { get; set; }

}

}