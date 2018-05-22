using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class LoaiPhong
    {
        public LoaiPhong(int? maLoaiPhong, string tenLoaiPhong, int? maKS)
        {
            MaLoaiPhong = maLoaiPhong;
            TenLoaiPhong = tenLoaiPhong;
            MaKS = maKS;
        }

        public int? MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public int? MaKS { get; set; }
    }
}