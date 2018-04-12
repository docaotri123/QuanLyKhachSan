using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class LoaiPhong
    {
        public LoaiPhong(string maLoaiPhong, string tenLoaiPhong, string maKS)
        {
            MaLoaiPhong = maLoaiPhong;
            TenLoaiPhong = tenLoaiPhong;
            MaKS = maKS;
        }

        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public string MaKS { get; set; }
    }
}