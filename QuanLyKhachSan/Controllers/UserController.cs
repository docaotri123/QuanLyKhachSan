using QuanLyKhachSan.Models;
using QuanLyKhachSan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachSan.Controllers
{
    public class UserController : Controller
    {
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        // GET: User
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult DetailCart()
        {
            var user = Session["loginSuccess"] as UserName;
            DateTime today = DateTime.Today;
            var list = db.DATPHONGs.Where(m => m.MaKH == user.maKH && DateTime.Compare((DateTime)m.NgayTraPhong, today) >= 0);

            ViewBag.Cart = list;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

    }
}