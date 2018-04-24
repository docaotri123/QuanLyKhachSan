using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Dropdownlist
{
    public class DropDownList
    {

        public static IEnumerable<SelectListItem> GetStars(string selectedValue = "1")
        {
            var result1 = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                   Text = "1 Sao",
                   Value="1",
                   Selected =  selectedValue.Equals("1")
                },
                 new SelectListItem()
                {
                   Text = "2 Sao",
                   Value="2",
                   Selected =  selectedValue.Equals("2")
                },
                 new SelectListItem()
                {
                   Text = "3 Sao",
                   Value="3",
                   Selected =  selectedValue.Equals("3")
                },
                 new SelectListItem()
                {
                   Text = "4 Sao",
                   Value="4",
                   Selected =  selectedValue.Equals("4")
                },
                 new SelectListItem()
                {
                   Text = "5 Sao",
                   Value="5",
                   Selected =  selectedValue.Equals("5")
                }
            };


            return result1;
        }

        public static IEnumerable<SelectListItem> GetCities(string selectedValue = "hcm")
        {
            var result = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                   Text = "HCM",
                   Value="hcm",
                   Selected =  selectedValue.Equals("hcm")
                },
                 new SelectListItem()
                {
                   Text = "Hà Nội",
                   Value="hn",
                   Selected =  selectedValue.Equals("hn")
                },
                 new SelectListItem()
                {
                   Text = "Đà Nẵng",
                   Value="Đà Nẵng",
                   Selected =  selectedValue.Equals("Đà Nẵng")
                },
                 new SelectListItem()
                {
                   Text = "Vũng Tàu",
                   Value="Vũng Tàu",
                   Selected =  selectedValue.Equals("Vũng Tàu")
                },
                 new SelectListItem()
                {
                   Text = "Tây Ninh",
                   Value="Tây Ninh",
                   Selected =  selectedValue.Equals("Tây Ninh")
                }
            };


            return result;
        }

        public static IEnumerable<SelectListItem> GetTyleRoom(string maKS = "", string selectedValue = "")
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var rooms = new List<SelectListItem>();

                var kq = db.LOAIPHONGs.Where(m => m.MaKS.Equals(maKS)).ToList();

                foreach (var item in kq)
                {
                    var x = new SelectListItem()
                    {
                        Text = item.TenLoaiPhong,
                        Value = item.MaLoaiPhong,
                        Selected = !string.IsNullOrEmpty(selectedValue) ? selectedValue.Equals(item.MaLoaiPhong) : false
                    };

                    rooms.Add(x);
                }

                return rooms;
            }
        }
    }
}