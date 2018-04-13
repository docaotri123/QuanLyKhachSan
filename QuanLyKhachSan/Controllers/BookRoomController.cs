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

            // return list Phong
            if (phong.maLoaiPhong != null)
            {

                var lsPhong = db.DanhSachPhong(id, phong.maLoaiPhong).ToList();

                //Lay tình trạng phòng
                DateTime thisDay = DateTime.Today;
                var Stage = db.PhongVaTinhTrang(phong.maLoaiPhong, id, thisDay);
                List<string> trangThaiPhong = new List<string>();
                List<string> soPhong = new List<string>();
                int[] a = new int[lsPhong.Count ];
                int i = 0, j = 0;
                //Mục đích trả về kiểu list cho dễ tính toán
                foreach (var item in Stage)
                {
                    trangThaiPhong.Add(item.MaPhong);
                    i++;
                }
                i = 0;
                foreach (var item1 in lsPhong)
                {
                    soPhong.Add( item1.MaPhong);
                    i++;
                }
                i = 0;
                //Ghi lại trạng thái phong đã đặt
                for (; i < trangThaiPhong.Count(); i++)
                {
                    for (; j < lsPhong.Count(); j++)
                    {
                        a[i] = 0;
                        if (trangThaiPhong[i] == soPhong[j])
                        {
                            a[i] = 1;
                            break;
                        }
                    }
                }


                //
                i = 0;
                foreach (var item in lsPhong)
                {
                    x1 = new Phong();
                    x1.maPhong = item.MaPhong;
                    x1.maLoaiPhong = item.LoaiPhong;
                    x1.soPhong = item.SoPhong;
                    if (a[i] == 1)
                    {
                        x1.stage = "đang sử dụng";
                    }
                    else
                    {
                        x1.stage = "còn trống";
                    }
                    i++;

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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

    }
}