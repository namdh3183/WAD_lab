using lab1rework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1rework.Controllers
{
    public class GioHangController : Controller
    {
        Model1 db = new Model1();
        // GET: GioHang
        public ActionResult Index()
        {
            var userLogin = (KHACHHANG)Session["Taikhoan"];
            if(userLogin == null)
            {
                return Redirect("~/User/DangNhap");
            }
            else
            {
                var GioHang = db.DONDATHANGs.FirstOrDefault(d => d.Dathanhtoan == false && d.MaKH == userLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false
                    };
                    db.DONDATHANGs.Add(GioHang);
                    db.SaveChanges();
                }
                var lstCtGiohang = db.CHITIETDONTHANGs.Where(ct => ct.MaDonHang == GioHang.MaDonHang).ToList();
                var model = (from ct in lstCtGiohang
                             join s in db.SACHes
                             on ct.Masach equals s.Masach
                             select new { Masach = ct.Masach, Tensach = s.Tensach, Anhbia = s.Anhbia, 
                                 Giaban = s.Giaban, Soluong = ct.Soluong, Thanhtien = ct.Soluong * s.Giaban }).Select(t => t.ToExpando()).ToList();
                return View(model);
            }
        }

        public ActionResult ThemGioHang(int Masach)
        {
            var userLogin = (KHACHHANG)Session["Taikhoan"];
            if (userLogin == null)
            {
                return Redirect("~/User/DangNhap");
            }
            else
            {
                var GioHang = db.DONDATHANGs.FirstOrDefault(d => d.Dathanhtoan == false && d.MaKH == userLogin.MaKH);
                if(GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false
                    };
                    db.DONDATHANGs.Add(GioHang);
                    db.SaveChanges();
                }
                var ctDonhang = db.CHITIETDONTHANGs.FirstOrDefault(
                        ct => ct.Masach==Masach && ct.MaDonHang == GioHang.MaDonHang
                        );
                if(ctDonhang == null)
                {
                    ctDonhang = new CHITIETDONTHANG 
                    {
                        Masach = Masach,
                        MaDonHang = GioHang.MaDonHang,
                        Soluong = 1
                    };
                }
                else
                {
                    ctDonhang.Soluong++;
                }
                db.CHITIETDONTHANGs.AddOrUpdate(ctDonhang);
                db.SaveChanges();
            }

            return View(Masach);
        }
    }
}