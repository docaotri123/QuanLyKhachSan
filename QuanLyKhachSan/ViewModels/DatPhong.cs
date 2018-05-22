using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class DatPhong
    {
        public int? maDP { get; set; }
        public int? maKH { get; set; }
        public int? maPhong { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayTraPhong { get; set; }
        public DateTime ngayDat { get; set; }
        public decimal donGia { get; set; }
        public string MoTa { get; set; }
        public string tinhTrang { get; set; }

    }
}