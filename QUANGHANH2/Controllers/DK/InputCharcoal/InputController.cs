using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.InputCharcoal
{
    public class InputController : Controller
    {
        // GET: Input
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/nhap-lieu-san-xuat")]
        public ActionResult InputCharcoal()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            var ngaySX = db.header_KeHoachTungThang.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.SoNgayLamViec).FirstOrDefault();
            ViewBag.SoNgaySX = ngaySX;
            ViewBag.NgayNhap = DateTime.Today;
            return View("/Views/DK/InputCharcoal/InputCharcoal.cshtml");
        }
        public class LuyKe
        {
            public string LK { get; set; }
        }
        [Route("change")]
        [HttpPost]
        public JsonResult Change(string px_value, string to_value, string date)
        {
            List<TieuChi> tcList = null;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            if (px_value != null)
            {
                if (px_value.Contains("KT"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (2,24,9)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Contains("DL"))
                {
                    if (px_value.Contains("TL") || px_value.Contains("AS") || px_value.Contains("XLM"))
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,23,9)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }
                    else
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,24,9,6)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }
                }
                else if (px_value.Equals("KCS"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (18,19,22,10,11,12,13,14,15,16,17)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Equals("ST"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (21)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Equals("LT"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (3,4)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
            }
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            List<LuyKe> LK = null;
            if (!date.Equals(""))
            {
                month = Convert.ToInt32(date.Split('/')[1]);
                year = Convert.ToInt32(date.Split('/')[2]);
                //   string queryLK = "select case when sum(tha.SanLuong) is null then 0 else sum(tha.SanLuong) end 'LK' " +
                //"from(select th2.MaPhongBan, th2.Ca, th2.Ngay, th2.NgaySanXuat, th1.MaTieuChi, th1.SanLuong from ThucHien_TieuChi_TheoNgay th1 join header_ThucHienTheoNgay th2 on th1.HeaderID = th2.HeaderID " +
                //"where Month(Ngay) = (SELECT Month(CONVERT(VARCHAR(10), '" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "', 101)))) as tha";
                //   List<LuyKe> list = db.Database.SqlQuery<LuyKe>(queryLK).ToList();
            }

            var ngaySX = db.header_KeHoachTungThang.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.SoNgayLamViec).FirstOrDefault();
            return Json(new { success = true, list = tcList, dateSX = ngaySX }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveChange(string date, string px_value, string ca_value,
            string[] thucHien, string[] keHoach, string[] chenhLech, string[] phanTramTH,
            string[] luyKe, string[] KHDC, string[] phanTramTD, string[] tong, string[] motNgay, string[] ghiChu)
        {

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}