using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class Phong 
    {
        public Phong()
        {
        }

        public Phong(int? soPhong)
        {
            this.soPhong = soPhong;
        }

        public string maPhong { get; set; }
        public string maLoaiPhong { get; set; }
        public string maKS { get; set; }

        public int? soPhong { get; set; }
        public string stage { get; set; }
        public decimal donGia { get; set; }

   
    }
}