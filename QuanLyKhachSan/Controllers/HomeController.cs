using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();

        public ActionResult Index()
        {
            //var a = db.ThongKeDTNgay_KhongIndex(DateTime.Now);

           
            return View();
        }


        public ActionResult Signup()
        {
            ViewBag.Message = "Signup";

            return View();
        }
        private static Random random = new Random();
        private static int RandomLength()
        {
            Random rnd = new Random();
            int len = rnd.Next(4, 11);
            return len;
        }
        private static string RandomString()
        {
            int len = RandomLength();
            const string chars = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, len)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(KHACHHANG kh, FormCollection fr)
        {
            if (ModelState.IsValid)
            {
                var ck = 0;
                var ps = fr["password-confirmation"].ToString();
                if (ps == kh.MatKhau)
                {
                    var maKH = RandomString();
                    ck = db.ThemKhachHang(maKH, kh.HoTen, kh.TenDangNhap, kh.MatKhau, kh.SoCMND, kh.DiaChi, kh.SoDienThoai, kh.MoTa, kh.Email);
                    if (ck == -1)
                    {
                        ViewBag.ThongBao = "Đăng ký thất bại";
                    }
                    else
                    {
                        ViewBag.ThongBao = "Đăng ký thành công";
                        db.SaveChanges();
                    }
                }
                else
                {
                    ViewBag.ThongBaoMK = "Xác nhận lại mật khẩu";
                }


            }
            return View(kh);
        }


    }
}