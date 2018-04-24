using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class DatPhong
    {
        public string maDP { get; set; }
        public string maKH { get; set; }
        public string maPhong { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayTraPhong { get; set; }
        public DateTime ngayDat { get; set; }
        public decimal donGia { get; set; }
        public string MoTa { get; set; }
        public string tinhTrang { get; set; }

    }
}