using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    public class TimKiemKSController : Controller
    {
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();

        //GET:TimKiemKS

        public ActionResult GiaVaThanhPho(decimal? gia, string tp = "")
        {
            ViewBag.gia = gia;
         
            ViewBag.city = tp;
            var data = db.TimKiemGiaVaThanhPho(gia, tp);


            return View(data.ToList());
        }
        // GET: TimKiemKS
        public ActionResult HangSaoVaThanhPho(int? sao, string tp = "")
        {
            ViewBag.sao = sao.ToString();

            ViewBag.city = tp;

            var data = db.TimKiemSaoVaThanhPho(sao, tp);


            return View(data.ToList());
        }
    }
}