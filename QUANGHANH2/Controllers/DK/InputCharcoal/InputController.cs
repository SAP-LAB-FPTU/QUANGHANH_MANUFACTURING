using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.NgayNhap = DateTime.Today.ToString("dd/MM/yyyy");
            return View("/Views/DK/InputCharcoal/InputCharcoal.cshtml");
        }
        public class LuyKe
        {
            public int LK { get; set; }
        }
        [Route("change")]
        [HttpPost]
        public JsonResult Change(string px_value, string ca_value, string date)
        {
            List<TieuChi> tcList = null;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            if (px_value != null)
            {
                if (px_value.Contains("KT"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (2,7,19)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Contains("DL"))
                {
                    if (px_value.Contains("PXDL1") || px_value.Contains("PXDL2") || px_value.Contains("CTA"))
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,7,19)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }
                    else
                    {
                        string query = "select * from TieuChi where MaTieuChi in (1,7,9,19)";
                        tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                    }
                }
                else if (px_value.Equals("KCS"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (6,18,21,22,23,24,25,26,27,28,30)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Contains("ST"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (10,11,12,13,14,15,16,17)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
                else if (px_value.Contains("LT"))
                {
                    string query = "select * from TieuChi where MaTieuChi in (3,4)";
                    tcList = db.Database.SqlQuery<TieuChi>(query).ToList();
                }
            }
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            double LK = 0;
            try
            {
                if (!date.Equals(""))
                {
                    month = Convert.ToInt32(date.Split('/')[1]);
                    year = Convert.ToInt32(date.Split('/')[2]);
                    string queryLK = "select case when sum(tha.SanLuong) is null then 0 else sum(tha.SanLuong) end 'LK' " +
                 "from(select th2.MaPhongBan, th2.Ca, th2.Ngay, th2.NgaySanXuat, th1.MaTieuChi, th1.SanLuong from ThucHien_TieuChi_TheoNgay th1 join header_ThucHienTheoNgay th2 on th1.HeaderID = th2.HeaderID " +
                 "where Month(Ngay) = (SELECT Month(CONVERT(VARCHAR(10), '" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "', 101)))) as tha";
                    LK = db.Database.SqlQuery<LuyKe>(queryLK).FirstOrDefault().LK;
                    ViewBag.luyKe = LK;
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }



            var ngaySX = db.header_KeHoachTungThang.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.SoNgayLamViec).FirstOrDefault();
            ViewBag.SoNgaySX = ngaySX;
            return Json(new { success = true, list = tcList, dateSX = ngaySX, luyKe = LK }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveChange(string ngaySX, string ngayNhap, string px_value, string ca_value, string[] tenTieuChi,
            string[] thucHien, string[] keHoach, string[] KHDC, string[] ghiChu)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    header_ThucHienTheoNgay tttn = new header_ThucHienTheoNgay();
                    DateTime ngaySXFix = Convert.ToDateTime(ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0] + "/" + ngayNhap.Split('/')[2]);
                    tttn.MaPhongBan = px_value;
                    tttn.Ngay = ngaySXFix;
                    tttn.Ca = Convert.ToInt32(ca_value);
                    tttn.NgaySanXuat = Convert.ToInt32(ngaySX);
                    db.header_ThucHienTheoNgay.Add(tttn);
                    db.SaveChanges();
                    int caSXConvert = Convert.ToInt32(ca_value);
                    var headerID = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ngay == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                    List<TieuChi> list = db.TieuChis.ToList();
                    int[] maTieuChi = new int[tenTieuChi.Length];
                    ThucHien_TieuChi_TheoNgay thtctn = new ThucHien_TieuChi_TheoNgay();
                    for (int i = 0; i < tenTieuChi.Length; i++)
                    {
                        foreach (var item in list)
                        {
                            if (item.TenTieuChi.Equals(tenTieuChi[i]))
                            {
                                maTieuChi[i] = item.MaTieuChi;
                            }
                        }
                        if (ghiChu[i].Equals(""))
                        {
                            ghiChu[i] = "null";
                        }
                        else if (thucHien[i].Equals(""))
                        {
                            thucHien[i] = "0";
                        }
                        else if (keHoach[i].Equals(""))
                        {
                            keHoach[i] = "0";
                        }
                        string query = "insert into ThucHien_TieuChi_TheoNgay (HeaderID,MaTieuChi,SanLuong,GhiChu,KeHoach) " +
                            "values(" + headerID + "," + maTieuChi[i] + "," + thucHien[i] + "," + ghiChu[i] + "," + keHoach[i] + ")";
                        db.Database.ExecuteSqlCommand(query);
                    }
                    dbct.Commit();

                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbct.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);

                }
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet) ;
        }
    }
}