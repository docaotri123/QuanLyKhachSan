
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
    
public partial class KHACHSAN
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public KHACHSAN()
    {

        this.LOAIPHONGs = new HashSet<LOAIPHONG>();

    }


    public string MaKS { get; set; }

    public string TenKS { get; set; }

    public Nullable<int> SoSao { get; set; }

    public Nullable<int> SoNha { get; set; }

    public string Duong { get; set; }

    public string Quan { get; set; }

    public string ThanhPho { get; set; }

    public Nullable<decimal> GiaTB { get; set; }

    public string MoTa { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LOAIPHONG> LOAIPHONGs { get; set; }

}

}
