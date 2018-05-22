using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.ViewModels
{
    public class Hotel
    {
        public int? MaKS { get; set; }
        public string TenKS { get; set; }
        public Nullable<int> SoSao { get; set; }
        public Nullable<int> SoNha { get; set; }
        public string Duong { get; set; }
        public string Quan { get; set; }
        public string ThanhPho { get; set; }
        public Nullable<decimal> GiaTB { get; set; }
        public string MoTa { get; set; }
     

        public Hotel(int? maKS, string tenKS, int? soSao, int? soNha, string quan, string thanhPho, decimal? giaTB, string moTa)
        {
            MaKS = maKS;
            TenKS = tenKS;
            SoSao = soSao;
            SoNha = soNha;
            Quan = quan;
            ThanhPho = thanhPho;
            GiaTB = giaTB;
            MoTa = moTa;
        }
    }
}