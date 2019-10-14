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
            public double LK { get; set; }
        }
        public class SanXuat
        {
            public string TenTieuChi { get; set; }
            public double SanLuong { get; set; }
            public double KeHoach { get; set; }
            public double KHDC { get; set; }
            public double LuyKe { get; set; }
            public string GhiChu { get; set; }
            public string DonViDo { get; set; }
        }
        [Route("change")]
        [HttpPost]
        public JsonResult Change(string px_value, string ca_value, string date)
        {
            List<SanXuat> tcList = null;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            List<SanXuat> LK = null;
            List<SanXuat> listSX = null;
            int ca = 0;
            bool flag = false;
            if (!ca_value.Equals(""))
            {
                ca = Convert.ToInt32(ca_value);
            }
            DateTime dateTime = Convert.ToDateTime(date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2]);
            try
            {
                if (!date.Equals(""))
                {
                    month = Convert.ToInt32(date.Split('/')[1]);
                    year = Convert.ToInt32(date.Split('/')[2]);
                    List<header_ThucHienTheoNgay> checkList = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ca == ca && x.Ngay == dateTime).ToList();
                    if (checkList.Count > 0)
                    {
                        string queryLoad = "select TenTieuChi, SanLuong, KeHoach, KHDC, GhiChu, LuyKe, DonViDo from( " +
                            "(select th.SanLuong, th.GhiChu, th.MaTieuChi 'TieuChiLoad' from header_ThucHienTheoNgay headth " +
                            "left outer join ThucHien_TieuChi_TheoNgay th " +
                            "on headth.HeaderID = th.HeaderID " +
                            "where headth.MaPhongBan = '" + px_value + "' and headth.Ca = " + ca_value + " and " +
                            " headth.Ngay = '" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "' " +
                            ") as TH " +
                            "inner join " +
                            "(select kh.KeHoach, kh.MaTieuChi from KeHoach_TieuChi_TheoNgay kh " +
                            "left outer join header_KeHoach_TieuChi_TheoNgay headkh " +
                            "on kh.HeaderID = headkh.HeaderID " +
                            "where headkh.MaPhongBan = '" + px_value + "' and headkh.Ca = " + ca_value + " and " +
                            "headkh.NgayNhapKH = '" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "' " +
                            ") as KH " +
                            "on TH.TieuChiLoad = KH.MaTieuChi " +
                            "inner join " +
                            "(" +
                            "select khMonth.MaTieuChi, khMonth.SanLuong 'KHDC' from header_KeHoachTungThang headMonth " +
                            "left outer join KeHoach_TieuChi_TheoThang khMonth " +
                            "on headMonth.HeaderID = khMonth.HeaderID " +
                            "where headMonth.MaPhongBan = '" + px_value + "' and headMonth.ThangKeHoach = " + month + " and headMonth.NamKeHoach = " + year + " " +
                            ") as KHMonth " +
                            "on KH.MaTieuChi = KHMonth.MaTieuChi " +
                            "inner join " +
                            "TieuChi tc on tc.MaTieuChi = KH.MaTieuChi " +
                            "inner join " +
                            "(select case when sum(lk.SanLuong) is null then 0 else sum(lk.SanLuong) end 'LuyKe', lk.MaTieuChi " +
                            "from(select MaPhongBan, Ngay, Ca, MaTieuChi, SanLuong from header_ThucHienTheoNgay hth join ThucHien_TieuChi_TheoNgay th " +
                            "on hth.HeaderID = th.HeaderID " +
                            "where hth.MaPhongBan = '" + px_value + "' and Month(hth.Ngay) = Month('" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "') " +
                            "and Year(hth.Ngay) = Year('" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "')) as lk " +
                            "group by lk.MaTieuChi) as lkk " +
                            "on lkk.MaTieuChi = tc.MaTieuChi " +
                            ")";
                        listSX = db.Database.SqlQuery<SanXuat>(queryLoad).ToList();
                        flag = true;
                    }
                    else
                    {
                        if (px_value.Contains("KT"))
                        {
                            string query = "select * from TieuChi where MaTieuChi in (2,7,19)";
                            listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        }
                        else if (px_value.Contains("DL"))
                        {
                            if (px_value.Contains("PXDL1") || px_value.Contains("PXDL2") || px_value.Contains("CTA"))
                            {
                                string query = "select * from TieuChi where MaTieuChi in (1,7,19)";
                                listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                            }
                            else
                            {
                                string query = "select * from TieuChi where MaTieuChi in (1,7,9,19)";
                                listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                            }
                        }
                        else if (px_value.Equals("KCS"))
                        {
                            string query = "select * from TieuChi where MaTieuChi in (6,18,21,22,23,24,25,26,27,29,30)";
                            listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        }
                        else if (px_value.Contains("ST"))
                        {
                            string query = "select * from TieuChi where MaTieuChi in (10,11,12,13,14,15,16,17)";
                            listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        }
                        else if (px_value.Contains("LT"))
                        {
                            string query = "select * from TieuChi where MaTieuChi in (3,4)";
                            listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        }
                        flag = false;
                    }

                    string queryLK = "select case when sum(lk.SanLuong) is null then 0 else sum(lk.SanLuong) end 'LuyKe', lk.MaTieuChi " +
                                    "from(select MaPhongBan, Ngay, Ca, MaTieuChi, SanLuong from header_ThucHienTheoNgay hth join ThucHien_TieuChi_TheoNgay th " +
                                    "on hth.HeaderID = th.HeaderID " +
                                    "where hth.MaPhongBan = '" + px_value + "' and Month(hth.Ngay) = Month('" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "') and " +
                                    "Year(hth.Ngay) = Year('" + date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2] + "')) as lk  " +
                                    "group by lk.MaTieuChi ";
                    LK = db.Database.SqlQuery<SanXuat>(queryLK).ToList();


                }

            }

            catch (Exception e)
            {
                e.Message.ToString();

                return Json(new { success = flag, list = tcList, luyKe = LK, listSXLoad = listSX }, JsonRequestBehavior.AllowGet);

            }


            var ngaySX = db.header_KeHoachTungThang.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year).Select(x => x.SoNgayLamViec).FirstOrDefault();
            ViewBag.SoNgaySX = ngaySX;
            return Json(new { success = flag, list = tcList, dateSX = ngaySX, luyKe = LK, listSXLoad = listSX }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveChange(string ngaySX, string ngayNhap, string px_value, string ca_value, string[] tenTieuChi,
            string[] thucHien, string[] keHoach, string[] KHDC, string[] ghiChu)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    DateTime ngaySXFix = Convert.ToDateTime(ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0] + "/" + ngayNhap.Split('/')[2]);

                    header_ThucHienTheoNgay tttn = new header_ThucHienTheoNgay();
                    tttn.MaPhongBan = px_value;
                    tttn.Ngay = ngaySXFix;
                    tttn.Ca = Convert.ToInt32(ca_value);
                    tttn.NgaySanXuat = Convert.ToInt32(ngaySX);
                    db.header_ThucHienTheoNgay.Add(tttn);
                    db.SaveChanges();

                    header_KeHoach_TieuChi_TheoNgay khtctn = new header_KeHoach_TieuChi_TheoNgay();
                    khtctn.MaPhongBan = px_value;
                    khtctn.NgayNhapKH = ngaySXFix;
                    khtctn.Ca = Convert.ToInt32(ca_value);
                    db.header_KeHoach_TieuChi_TheoNgay.Add(khtctn);
                    db.SaveChanges();

                    int caSXConvert = Convert.ToInt32(ca_value);
                    var headerIDDay = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ngay == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                    var headerIDPlanDay = db.header_KeHoach_TieuChi_TheoNgay.Where(x => x.MaPhongBan == px_value && x.NgayNhapKH == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                    var headerIDMonth = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == px_value && x.ThangKeHoach == ngaySXFix.Month && x.NamKeHoach == ngaySXFix.Year).Select(x => x.HeaderID).FirstOrDefault();
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
                        else if (KHDC[i].Equals(""))
                        {
                            KHDC[i] = "0";
                        }
                        string query1 = "insert into ThucHien_TieuChi_TheoNgay (HeaderID,MaTieuChi,SanLuong,GhiChu) " +
                            "values(" + headerIDDay + "," + maTieuChi[i] + "," + thucHien[i] + "," + ghiChu[i] + ")";
                        db.Database.ExecuteSqlCommand(query1);

                        string query2 = "insert into KeHoach_TieuChi_TheoNgay (HeaderID, MaTieuChi, KeHoach, ThoiGianNhapCuoiCung) " +
                            "values(" + headerIDPlanDay + ", " + maTieuChi[i] + ", " + keHoach[i] + ", GETDATE())";
                        db.Database.ExecuteSqlCommand(query2);

                        string query3 = "insert into KeHoach_TieuChi_TheoThang (HeaderID, MaTieuChi, SanLuong, ThoiGianNhapCuoiCung)" +
                            " values(" + headerIDMonth + ", " + maTieuChi[i] + ", " + KHDC[i] + ", GETDATE())";
                        db.Database.ExecuteSqlCommand(query3);
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
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}