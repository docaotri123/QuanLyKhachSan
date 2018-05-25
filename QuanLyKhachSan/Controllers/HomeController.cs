using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.ViewModels;

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
        public ActionResult Signup(KhachHangVM kh)
        {
            if (ModelState.IsValid)
            {
                var ck = 0;
                var maKH = RandomString();
                ck = db.ThemKhachHang(kh.HoTen, kh.TenDangNhap, kh.MatKhau, kh.SoCMND, kh.DiaChi, kh.SoDienThoai, kh.MoTa, kh.Email);
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
            return View(kh);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }



    }
}