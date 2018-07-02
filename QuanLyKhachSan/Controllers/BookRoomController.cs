using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.ViewModels;
using QuanLyKhachSan.Models;
using System.Globalization;

namespace QuanLyKhachSan.Controllers
{
    public class BookRoomController : Controller
    {
        private QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();

        private bool TrangThaiPhongTheoNgay(int? maPhong, DateTime date)
        {
            return db.TRANGTHAIPHONGs.Any(m => m.MaPhong == maPhong && m.Ngay.Equals(date));
        }

        // GET: BookRoom
        [HttpGet]
        public ActionResult DetailRoom(int? maKS, int? maLoaiPhong, DatPhong dp, string ngayBatDau,string ngayKetThuc)
        {
            //Check Login
            var user = Session["loginSuccess"] as UserName;
            ViewBag.User = null;
            if (user != null)
                ViewBag.User = user.maKH;
            //Tìm Hotel 
            var dbhotel = db.KHACHSANs.SingleOrDefault(m => m.MaKS == maKS);
            //List rooms of this Hotel
            var dblistloaiPhong = db.LOAIPHONGs.Where(m => m.MaKS == maKS).ToList();

            Hotel hotel = new Hotel(dbhotel.MaKS, dbhotel.TenKS, dbhotel.SoSao, dbhotel.SoNha, dbhotel.Quan, dbhotel.ThanhPho, dbhotel.GiaTB, dbhotel.MoTa);

            ViewBag.Hotel = hotel;
            ViewBag.maLoaiPhong = maLoaiPhong.ToString();


            List<LoaiPhong> listLoaiPhong = new List<LoaiPhong>();

            foreach (var item in dblistloaiPhong)
            {
                listLoaiPhong.Add(new LoaiPhong(item.MaLoaiPhong, item.TenLoaiPhong, item.MaKS));
            }

            ViewBag.listLoaiPhong = listLoaiPhong;
            //Get this day

            DateTime thisDay = DateTime.Today;
            DateTime ngayDat = DateTime.Today;

            if (ngayBatDau != null && ngayBatDau != "")
            {
                String[] sub = ngayBatDau.Split('-');
                ngayDat = new DateTime(int.Parse(sub[0]), int.Parse(sub[1]), int.Parse(sub[2]));
            }

            string this_day = thisDay.ToString("yyyy-MM-dd");

            ViewBag.thisday = this_day;
            ViewBag.ngayDatPhong = ngayBatDau;
            ViewBag.ngayDatPhong = ngayKetThuc;
            if (maLoaiPhong != null)
            {
                //GEt listPhong
                var dblstPhong = db.DanhSachPhong(maLoaiPhong).ToList().OrderBy(m => m.SoPhong);

                var dbStage = db.TrangThaiPhongDaDatTheoNgay(maLoaiPhong, ngayDat).OrderBy(m => m).ToList();
                var phongtrongs = dblstPhong.Select(x => new Phong
                {
                    maPhong = x.MaPhong,
                    soPhong = x.SoPhong,
                    stage = dbStage.Any(p => p == x.MaPhong) ? "hết phòng" : "còn phòng"
                }).ToList();
                List<Phong> listPhong = new List<Phong>();
                //Lay tình trạng phòng


                ViewBag.listPhong = phongtrongs;
                //Book Room

                ViewBag.ThongBao = "";
                int i = 0;
                if (dp.maPhong != null)
                {
                    //dp.ngayBatDau = DateTime.ParseExact(ngayBatDau,"MM/dd/yyyy", CultureInfo.InvariantCulture);
                    //dp.ngayTraPhong = DateTime.ParseExact(ngayKetThuc, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    dp.ngayBatDau = DateTime.Parse(ngayBatDau);
                    dp.ngayTraPhong = DateTime.Parse(ngayKetThuc);
                    if (DateTime.Compare(dp.ngayBatDau, dp.ngayTraPhong) <= 0)
                    {
                        dp.maKH = user.maKH;
                        dp.ngayDat = thisDay;
                        int numDaysDiff = Math.Abs(dp.ngayBatDau.Subtract(dp.ngayTraPhong).Days) + 1;
                        dp.donGia = numDaysDiff * dp.donGia;
                        dp.tinhTrang = "chưa xác nhận";
                        var test = false;
                        DateTime start = dp.ngayBatDau;
                        for (i = 0; i < numDaysDiff; i++)
                        {
                            test = TrangThaiPhongTheoNgay(dp.maPhong, start.AddDays(i));
                            if (test)
                            {
                                ViewBag.ThongBao = "Dat Phong That Bai";
                                break;
                            }
                        }
                        if (!test)
                        {
                            ViewBag.ThongBao = "Dat Phong Thanh Cong";
                            DATPHONG datphong = new DATPHONG();
                            datphong.MaPhong = dp.maPhong;
                            datphong.MaKH = dp.maKH;
                            datphong.NgayBatDau = dp.ngayBatDau;
                            datphong.NgayTraPhong = dp.ngayTraPhong;
                            datphong.NgayDat = thisDay;
                            datphong.DonGia = dp.donGia;
                            datphong.MoTa = "ABC";
                            datphong.TinhTrang = "chưa xác nhận";
                            //Cap nhat bang dat Phong
                            db.DATPHONGs.Add(datphong);
                            //Cap nhat bang Trang Thai Phong
                            TRANGTHAIPHONG ttp1 = null;
                            for (i = 0; i < numDaysDiff; i++)
                            {
                                //TrangThaiPhongTheoNgay(dp.maPhong, dp.ngayBatDau.AddDays(i)); 
                                ttp1 = new TRANGTHAIPHONG();
                                ttp1.MaPhong = (int)dp.maPhong;
                                ttp1.Ngay = dp.ngayBatDau.AddDays(i);
                                ttp1.TinhTrang = "đang sử dụng";
                                db.TRANGTHAIPHONGs.Add(ttp1);
                            }
                            db.SaveChanges();

                            var dathuephong = phongtrongs.FirstOrDefault(x => x.maPhong == datphong.MaPhong);
                            var dathuephongThuTu = Array.IndexOf(phongtrongs.ToArray(), dathuephong);
                            phongtrongs.ElementAt(dathuephongThuTu).stage = "hết phòng";

                            ViewBag.listPhong = phongtrongs;
                        }
                    }

                }

            }

            return View();
        }



        [HttpPost]
        public ActionResult DetailRoom()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }



    }

}