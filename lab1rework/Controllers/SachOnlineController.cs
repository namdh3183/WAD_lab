using lab1rework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Dynamic;

namespace lab1rework.Controllers
{
    public class SachOnlineController : Controller
    {
        // GET: SachOnline
        Model1 db = new Model1();
        public ActionResult Index(int ? page)
        {

            var lstSaches = db.SACHes.OrderBy(s => s.Masach);
            int pageNumber = (page) ?? 1;
            int pageSize = 6;
            return View(lstSaches.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult  NavPartial()
        {
            return PartialView();
        }

        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult ChuDePartial()
        {
            var lstChuDe = db.CHUDEs.ToList();
            return PartialView(lstChuDe);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var lstNXB = db.NHAXUATBANs.ToList();
            return PartialView(lstNXB);
        }

        public ActionResult SachBanNhieuPartial()
        {
            return PartialView();
        }

        public ActionResult SachTheoCD(int MaCD, int? page)
        {

            var lstSaches = db.SACHes.Where(s => s.MaCD==MaCD).OrderBy(s => s.Masach);
            int pageNumber = (page) ?? 1;
            int pageSize = 6;
            return View("Index" ,lstSaches.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SachTheoNXB(int MaNXB, int? page)
        {

            var lstSaches = db.SACHes.Where(s => s.MaNXB==MaNXB).OrderBy(s => s.Masach);
            int pageNumber = (page) ?? 1;
            int pageSize = 6;
            return View("Index" ,lstSaches.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ChiTietSach(int MaSach)
        {
            var sach = db.SACHes.FirstOrDefault(s => s.Masach == MaSach);
            return View(sach);
        }

        public ActionResult GioHang()
        {
            return View();
        }

        public ActionResult MenuPartial()
        {
            dynamic model = new ExpandoObject();
            model.CHUDEs = db.CHUDEs.ToList();
            model.NHAXUATBANs = db.NHAXUATBANs.ToList();

            return PartialView(model);
        }

    }
}