using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.ViewModels;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    public class SigninController : Controller
    {
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        // GET: DangNhap

        public ActionResult Signin()
        {
            ViewBag.Message = "Signin";
            return View();
        }
        [HttpPost]
        public ActionResult Signin(UserName user)
        {
            ViewBag.Message = "Signin";

            var ck = db.KHACHHANGs.SingleOrDefault(x => x.TenDangNhap.Equals(user.userName) && x.MatKhau.Equals(user.password));
            if (ck!=null)
            {
                user.maKH = ck.MaKH;
                user.nameKH = ck.HoTen;
                Session["loginSuccess"] = user;
                ViewBag.User = user.userName;
                return RedirectToAction("Detail", "User");
            }
            else
            {
                ViewBag.tb = "Đăng Nhập thất bại";
            }

            return View();
        }
        //GET user logout
        public ActionResult Logout()
        {
            Session["loginSuccess"] = null;
            return RedirectToAction("Index", "Home");
        }
        


    }
}