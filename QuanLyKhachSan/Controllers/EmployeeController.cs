using QuanLyKhachSan.Models;
using QuanLyKhachSan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachSan.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        // GET: Employee    Nhập ID phiếu đặt phòng
        public ActionResult ScanfIDBookRoom(DatPhong dp)
        {
            ViewBag.DatPhong = null;
            ViewBag.ThongBao = "";
            if(dp.maDP!=null)
            {
                var list = db.DATPHONGs.FirstOrDefault(m => m.MaDP == dp.maDP);
                ViewBag.maDP = dp.maDP;
                //Check maDP tính tiền chưa
                var ck = list.HOADONs.FirstOrDefault(m => m.MaDP == dp.maDP);
                if(ck!=null)
                {
                    ViewBag.ThongBao = "Đã Thanh Toán Rồi";
                }
                else
                {
                    ViewBag.DatPhong = list;
                    
                }

               
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult ScanfIDBookRoom(int? maDP)
        {
            ViewBag.DatPhong = null;
            ViewBag.ThongBao = "";
            if (maDP != null)
            {
                var list = db.DATPHONGs.FirstOrDefault(m => m.MaDP == maDP);
                ViewBag.maDP = maDP;
                DateTime thisDay = DateTime.Today;
                HOADON hd = new HOADON();
                hd.TongTien = list.DonGia;
                hd.NgayThanhToan = thisDay;
                hd.MaDP = maDP;

                db.HOADONs.Add(hd);
                db.SaveChanges();

                //ViewBag.DatPhong = list;
                ViewBag.ThongBao = "Thanh Toan Thanh Cong";



            }

            return View();
        }

        public ActionResult SearchReceipt(int? maKH,string date)
        {
            ViewBag.list = null;
            ViewBag.maKH = maKH;
            DateTime thisDay = DateTime.Today;
            ViewBag.date = thisDay.ToString("yyyy-MM-dd");
            if (maKH!=null)
            {
                // ViewBag.list = db.SeachReceipt_MaKH(maKH).ToList();
                ViewBag.list = null;

            }
            else if(maKH!=null && date!=null)
            {
                String[] subs = date.Split('-');
                DateTime date1 = new DateTime(int.Parse(subs[0]), int.Parse(subs[1]), int.Parse(subs[2]));
                //ViewBag.list = db.SeachReceipt_MaKH_Date(maKH, thisDay).ToList();
                ViewBag.list = null;
                ViewBag.date = date1.ToString("yyyy-MM-dd");
            }
            return View();
        }

        public ActionResult DoanhThuTheoThang(string month,string year)
        {
            ViewBag.month = month;
            ViewBag.year = year;
            if(month!=null && year!=null)
            {
                int? y = int.Parse(year);
                int? m1 = int.Parse(month);
                var total = db.HOADONs.Where(m => m.NgayThanhToan.Value.Year == y
                && m.NgayThanhToan.Value.Month == m1).Sum(x => x.TongTien);
                ViewBag.Total = total;
            }
          
            return View();
        }

        public ActionResult DoanhThuTheoNam(string year)
        {
            ViewBag.year = year;
            if (year != null)
            {
                int? y = int.Parse(year);
                var total = db.HOADONs.Where(m => m.NgayThanhToan.Value.Year == y).Sum(x => x.TongTien);
                ViewBag.Total = total;
            }

            return View();
        }

    }
}