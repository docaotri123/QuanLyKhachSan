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
        private readonly QuanLyKhachSanEntities db = new QuanLyKhachSanEntities();
        // GET: BookRoom
        public ActionResult DetailRoom(string id,Phong phong)
        {
            var u = db.KHACHSANs.SingleOrDefault(m=>m.MaKS.Equals(id));
            var loaiPhong = db.LOAIPHONGs.Where(m => m.MaKS.Equals(id));
            Hotel hotel = new Hotel(u.MaKS,u.TenKS,u.SoSao,u.SoNha,u.Quan,u.ThanhPho,u.GiaTB,u.MoTa);
            List<LoaiPhong> listLP = new List<LoaiPhong>();
            LoaiPhong x;
            foreach(var item in loaiPhong)
            {
                x = new LoaiPhong(item.MaLoaiPhong, item.TenLoaiPhong, item.MaKS);
                listLP.Add(x);
            }
            ViewBag.listLoaiPhong = listLP;

            ViewBag.listPhong = null;
            Phong x1;
            List<Phong> listPhong = new List<Phong>();
            var lsPhong = db.DanhSachPhong(id, phong.maLoaiPhong);
            // return list Phong
            if (phong.maLoaiPhong != null)
            {

                foreach(var item in lsPhong)
                {
                    x1 = new Phong();
                    x1.maPhong = item.MaPhong;
                    x1.maLoaiPhong = item.LoaiPhong;
                    x1.soPhong = item.SoPhong;

                    listPhong.Add(x1);
                }
                
                ViewBag.listPhong = listPhong;
            }
            return View(hotel);
        }
        [HttpPost]
        public ActionResult DetailRoom()
        {
            
            return View();
        }


    }
}