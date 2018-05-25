using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.ViewModels;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    public class BookRoomController : Controller
    {
        private QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();

        private bool TrangThaiPhongTheoNgay(int? maPhong, DateTime date)
        {
            var kq = db.TRANGTHAIPHONGs.Where(m => m.MaPhong == maPhong && m.Ngay.Equals(date));
            if (kq != null)
            {
                return true;
            }
            return false;
        }

        // GET: BookRoom
        [HttpGet]
        public ActionResult DetailRoom(int? maKS,int? maLoaiPhong,DatPhong dp,string ngayBatDau)
        {
            //Check Login
            var user = Session["loginSuccess"] as UserName;
            ViewBag.User = null;
            if(user!=null)
                ViewBag.User = user.maKH;
            //Tìm Hotel 
            var dbhotel = db.KHACHSANs.SingleOrDefault(m => m.MaKS==maKS);
            //List rooms of this Hotel
            var dblistloaiPhong = db.LOAIPHONGs.Where(m => m.MaKS==maKS).ToList();

            Hotel hotel = new Hotel(dbhotel.MaKS, dbhotel.TenKS, dbhotel.SoSao, dbhotel.SoNha, dbhotel.Quan, dbhotel.ThanhPho, dbhotel.GiaTB, dbhotel.MoTa);

            ViewBag.Hotel = hotel;
            ViewBag.maLoaiPhong = maLoaiPhong.ToString();
        

            List<LoaiPhong> listLoaiPhong = new List<LoaiPhong>();

            foreach(var item in dblistloaiPhong)
            {
                listLoaiPhong.Add(new LoaiPhong(item.MaLoaiPhong,item.TenLoaiPhong,item.MaKS));
            }

            ViewBag.listLoaiPhong = listLoaiPhong;
            //Get this day

            DateTime thisDay = DateTime.Today;
            DateTime ngayDat = DateTime.Today;

            if (ngayBatDau != null&&ngayBatDau!="")
            {
                String[] sub = ngayBatDau.Split('-');
                ngayDat = new DateTime(int.Parse(sub[0]), int.Parse(sub[1]), int.Parse(sub[2]));
            }

            string this_day = thisDay.ToString("yyyy-MM-dd");

            ViewBag.thisday = this_day;
            ViewBag.ngayDatPhong = ngayBatDau;
            if (maLoaiPhong !=null)
            {
                //GEt listPhong
                var dblstPhong = db.DanhSachPhong(maLoaiPhong).ToList().OrderBy(m=>m.SoPhong);
                List<Phong> listPhong = new List<Phong>();
                //Lay tình trạng phòng

                var dbStage = db.TrangThaiPhongDaDatTheoNgay(maLoaiPhong, ngayDat).ToList().OrderBy(m=>m.Value);
                List<int?> trangThaiPhong = new List<int?>();
                List<int?> maPhong = new List<int?>();
                int[] a = new int[dblstPhong.Count()];
                int i = 0, j = 0;
                //Mục dích trả về kiểu list cho dễ tính toán
                foreach (var item in dbStage)
                {
                    trangThaiPhong.Add(item.Value);
                    i++;
                }
                i = 0;
                foreach (var item in dblstPhong)
                {
                    maPhong.Add(item.MaPhong);
                    i++;
                }
                i = 0;
                int ck = 0;
                //Ghi lại trạng thái phong dã đặt
                for (; i < maPhong.Count(); i++)
                {
                    a[i] = 0;
                    for (; j < trangThaiPhong.Count(); j++)
                    {                 
                        if (maPhong[i] == trangThaiPhong[j])
                        {
                            a[i] = 1;
                            ck = j;
                            break;
                        }
                    }
                    j = ck;
                }


                Phong x;
                i = 0;
                foreach (var item in dblstPhong)
                {
                    x = new Phong();
                    x.maPhong = item.MaPhong;
                    x.soPhong = item.SoPhong;
                    if (a[i] == 1)
                    {
                        x.stage = "hết phòng";
                    }
                    else
                    {
                        x.stage = "còn trống";
                    }
                    i++;
                    listPhong.Add(x);
                }

                ViewBag.listPhong = listPhong;
                //Book Room

                ViewBag.ThongBao = "";

                if (dp.maPhong != null)
                {
                    if(DateTime.Compare(dp.ngayBatDau,dp.ngayTraPhong)<=0)
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
                            if (test == false)
                            {
                                ViewBag.ThongBao = "Dat Phong That Bai";
                                break;
                            }
                        }
                        if (test==true)
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
                                ttp1.MaPhong =(int) dp.maPhong;
                                ttp1.Ngay = dp.ngayBatDau.AddDays(i);
                                ttp1.TinhTrang = "đang sử dụng";
                                db.TRANGTHAIPHONGs.Add(ttp1);
                            }
                            db.SaveChanges();
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