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

        public static IEnumerable<SelectListItem> GetCities(string selectedValue = "")
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var cities = new List<SelectListItem>();
                var kq = db.KHACHSANs.Select(x => new { x.ThanhPho }).GroupBy(x => x.ThanhPho).ToList();
                foreach(var item in kq)
                {
                    var city = new SelectListItem()
                    {
                        Text = item.Key,
                        Value = item.Key,
                        Selected = !string.IsNullOrEmpty(selectedValue) ? selectedValue.Equals(item.Key) : false
                    };
                    if (item.Key != null)
                        cities.Add(city);
                }

                return cities;
            }

        }

        public static IEnumerable<SelectListItem> GetTyleRoom(int? maKS = null, string selectedValue = "")
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var rooms = new List<SelectListItem>();

                var kq = db.LOAIPHONGs.Where(m => m.MaKS==maKS).ToList();

                foreach (var item in kq)
                {
                    var x = new SelectListItem()
                    {
                        Text = item.MaLoaiPhong.ToString(),
                        Value = item.MaLoaiPhong.ToString(),
                        Selected = !string.IsNullOrEmpty(selectedValue) ? selectedValue.Equals(item.MaLoaiPhong) : false
                    };

                    rooms.Add(x);
                }

                return rooms;
            }
        }
    }
}