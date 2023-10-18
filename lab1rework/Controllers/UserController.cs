using lab1rework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1rework.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KHACHHANG Model) 
        {
            if(ModelState.IsValid)
            {
                var kh = db.KHACHHANGs.FirstOrDefault(k => k.Taikhoan == Model.Taikhoan);
                if(kh != null)
                {
                    ModelState.AddModelError("Taikhoan", "Tài khoản đã tồn tại");
                    return View(Model);
                }
                db.KHACHHANGs.Add(Model);
                db.SaveChanges();
                return Redirect("DangNhap");
            }
            return View(Model);
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var u = db.KHACHHANGs.FirstOrDefault(k => k.Taikhoan == user.UserName && k.Matkhau == user.Password);
                if (u != null)
                {
                    Session["Taikhoan"] = u;
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    return Redirect("~/");
                }
                else
                    ModelState.AddModelError("Password", "Mật khẩu không chính xác");
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            Session["Taikhoan"] = null;
            return Redirect("~/");
        }
    }
}