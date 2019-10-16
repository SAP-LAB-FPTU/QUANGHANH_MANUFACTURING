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

            public string chenhlech { get; set; }
            public string percentDay { get; set; }
            public string luyke_temp { get; set; }
            public string percentMonth { get; set; }
            public string tong { get; set; }
            public string OneDay { get; set; }
            public int NgaySanXuat { get; set; }

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
            string date_sql = date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2];
            try
            {
                if (!date.Equals(""))
                {
                    month = Convert.ToInt32(date.Split('/')[1]);
                    year = Convert.ToInt32(date.Split('/')[2]);
                    List<header_ThucHienTheoNgay> checkList = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ca == ca && x.Ngay == dateTime).ToList();
                    List<header_KeHoach_TieuChi_TheoNgay> checkList2 = db.header_KeHoach_TieuChi_TheoNgay.Where(x => x.MaPhongBan == px_value && x.Ca == ca && x.NgayNhapKH == dateTime).ToList();

                    if (checkList.Count > 0 && checkList2.Count > 0)
                    {
                        string sql = "select t.TenTieuChi,p.MaPhongBan,t.DonViDo,table1.SanLuong, table1.Ngay, table1.Ca, table2.KeHoach,table3.luyke,table4.SanLuong as 'KHDC',table1.GhiChu,table1.NgaySanXuat "
                                    + "from PhongBan_TieuChi p inner join TieuChi t on p.MaTieuChi = t.MaTieuChi "
                                    + " inner join (select t.MaTieuChi, t.SanLuong, h.Ngay, h.Ca, h.MaPhongBan, t.GhiChu, h.NgaySanXuat  "
                                    + " from header_ThucHienTheoNgay h inner join ThucHien_TieuChi_TheoNgay t on h.HeaderID = t.HeaderID  "
                                    + " where h.Ngay = '" + date_sql + "' and h.Ca = " + ca_value + " and h.MaPhongBan = '" + px_value + "') table1 on p.MaTieuChi = table1.MaTieuChi and p.MaPhongBan = table1.MaPhongBan "
                                    + " inner join (select h.MaPhongBan,k.MaTieuChi, k.KeHoach  "
                                    + " from header_KeHoach_TieuChi_TheoNgay h inner join KeHoach_TieuChi_TheoNgay k on h.HeaderID = k.HeaderID  "
                                    + " where h.NgayNhapKH = '" + date_sql + "' and h.Ca = " + ca_value + " and h.MaPhongBan = '" + px_value + "') table2 on p.MaPhongBan = table2.MaPhongBan and p.MaTieuChi = table2.MaTieuChi "
                                    + " inner join (select a.MaPhongBan,a.MaTieuChi,sum(a.SanLuong) as 'luyke'  "
                                    + " from (select t.SanLuong,t.MaTieuChi,h.MaPhongBan  "
                                    + " from header_ThucHienTheoNgay h inner join ThucHien_TieuChi_TheoNgay t on h.HeaderID = t.HeaderID  "
                                    + " where h.MaPhongBan = '" + px_value + "' and h.Ngay between '" + year + "-" + month + "-1' and '" + date_sql + "' and h.Ca <= " + ca_value + ") as a group by a.MaPhongBan,a.MaTieuChi) table3 on p.MaTieuChi = table3.MaTieuChi and p.MaPhongBan = table3.MaPhongBan "
                                    + " inner join (select a.MaTieuChi, k.SanLuong, a.thoigian, h.MaPhongBan  "
                                    + " from header_KeHoachTungThang h inner join KeHoach_TieuChi_TheoThang k on h.HeaderID = k.HeaderID inner join (select h.MaTieuChi, MAX(h.ThoiGianNhapCuoiCung) as 'thoigian'  "
                                    + " from KeHoach_TieuChi_TheoThang h group by h.MaTieuChi) a on k.MaTieuChi = a.MaTieuChi and k.ThoiGianNhapCuoiCung = a.thoigian  "
                                    + " where h.MaPhongBan = '" + px_value + "' and h.ThangKeHoach = " + month + " and h.NamKeHoach = " + year + ") table4 on p.MaTieuChi = table4.MaTieuChi and p.MaPhongBan = table4.MaPhongBan";
                        listSX = db.Database.SqlQuery<SanXuat>(sql).ToList();
                        flag = true;
                    }
                    else
                    {
                        string query = "  select a.TenTieuChi, a.DonViDo, (case when LuyKe.LuyKe is null then 0 else LuyKe.LuyKe end) as LuyKe " +
                                        "from(select tc.* " +
                                                "from PhongBan_TieuChi pbtc inner " +
                                                "join TieuChi tc on pbtc.MaTieuChi = tc.MaTieuChi " +
                                                "where pbtc.MaPhongBan = '" + px_value + "') as a left outer join(select a.MaPhongBan, a.MaTieuChi, sum(a.SanLuong) as 'luyke' " +
                                                "from(select t.SanLuong, t.MaTieuChi, h.MaPhongBan " +
                                                "from header_ThucHienTheoNgay h inner " +
                                                "join ThucHien_TieuChi_TheoNgay t on h.HeaderID = t.HeaderID " +
                                                "where h.MaPhongBan = '" + px_value + "' and h.Ngay between '" + year + "-" + month + "-1' and '" + date_sql + "' and h.Ca <= " + ca_value + ")" +
                                                " as a group by a.MaPhongBan, a.MaTieuChi) as LuyKe on a.MaTieuChi = LuyKe.MaTieuChi";
                        listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        flag = false;
                    }
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            var ngaySX = db.header_KeHoachTungThang.Where(x => x.ThangKeHoach == month && x.NamKeHoach == year && x.MaPhongBan.Equals(px_value)).Select(x => x.SoNgayLamViec).FirstOrDefault();
            ViewBag.SoNgaySX = ngaySX;

            if (listSX != null) ViewBag.dem = listSX.Count();
            else ViewBag.dem = 0;
            int ngay_SX_now = 0;
            try
            {
                ngay_SX_now =  listSX.ElementAt(0).NgaySanXuat;

                foreach (var item in listSX)
                {
                    item.chenhlech = (Convert.ToInt32(item.SanLuong) - Convert.ToInt32(item.KeHoach)).ToString();
                    item.percentDay = (Convert.ToInt32(item.SanLuong) / Convert.ToInt32(item.KeHoach) * 100).ToString();
                    item.percentMonth = (Convert.ToInt32(item.LuyKe) / Convert.ToInt32(item.KHDC) * 100).ToString();
                    item.luyke_temp = (Convert.ToInt32(item.SanLuong) + Convert.ToInt32(item.LuyKe)).ToString();
                    item.tong = (Convert.ToInt32(item.KHDC) - Convert.ToInt32(item.luyke_temp)).ToString();
                    item.OneDay = (Convert.ToInt32(item.tong) / (ngaySX - item.NgaySanXuat)).ToString();
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return Json(new { success = flag, list = tcList, dateSX = ngaySX, luyKe = LK, listSXLoad = listSX, ngaySXnow = ngay_SX_now }, JsonRequestBehavior.AllowGet);
        }
        public class MaxKHDate : KeHoach_TieuChi_TheoThang
        {
            public DateTime Max { get; set; }
        }

        public JsonResult SaveChange(string ngaySX, string ngayNhap, string px_value, string ca_value, string[] tenTieuChi,
            string[] thucHien, string[] keHoach, string[] KHDC, string[] ghiChu)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            int ca = 0;
            if (!ca_value.Equals(""))
            {
                ca = Convert.ToInt32(ca_value);
            }
            DateTime dateTime = Convert.ToDateTime(ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0] + "/" + ngayNhap.Split('/')[2]);
            string date_sql = ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0] + "/" + ngayNhap.Split('/')[2];
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            using (DbContextTransaction dbct = db.Database.BeginTransaction())
            {
                try
                {
                    DateTime ngaySXFix = Convert.ToDateTime(ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0] + "/" + ngayNhap.Split('/')[2]);



                    List<TieuChi> list = db.TieuChis.ToList();
                    int[] maTieuChi = new int[tenTieuChi.Length];

                    ThucHien_TieuChi_TheoNgay thtctn = new ThucHien_TieuChi_TheoNgay();


                    if (!ngayNhap.Equals(""))
                    {
                        month = Convert.ToInt32(ngayNhap.Split('/')[1]);
                        year = Convert.ToInt32(ngayNhap.Split('/')[2]);
                        List<header_ThucHienTheoNgay> checkList = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ca == ca && x.Ngay == dateTime).ToList();
                        List<header_KeHoach_TieuChi_TheoNgay> checkList2 = db.header_KeHoach_TieuChi_TheoNgay.Where(x => x.MaPhongBan == px_value && x.Ca == ca && x.NgayNhapKH == dateTime).ToList();
                        KeHoach_TieuChi_TheoThang khMonth = new KeHoach_TieuChi_TheoThang();

                        if (checkList.Count > 0 && checkList2.Count > 0)
                        {
                            int caSXConvert = Convert.ToInt32(ca_value);
                            var headerIDDay = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ngay == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                            var headerIDPlanDay = db.header_KeHoach_TieuChi_TheoNgay.Where(x => x.MaPhongBan == px_value && x.NgayNhapKH == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                            var headerIDMonth = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == px_value && x.ThangKeHoach == ngaySXFix.Month && x.NamKeHoach == ngaySXFix.Year).Select(x => x.HeaderID).FirstOrDefault();
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
                                string queryGet = " select HeaderID, MaTieuChi , MAX(ThoiGianNhapCuoiCung) as 'Max' " +
                                  "from KeHoach_TieuChi_TheoThang where HeaderID = " + headerIDMonth + " and MaTieuChi = " + maTieuChi[i] + " " +
                                  "group by HeaderID, MaTieuChi";
                                var maxDate = db.Database.SqlQuery<MaxKHDate>(queryGet).FirstOrDefault();
                                string query = "update ThucHien_TieuChi_TheoNgay set SanLuong = " + thucHien[i] + ",GhiChu = '" + ghiChu[i] + "' " +
                                "  where HeaderID = " + headerIDDay + " and MaTieuChi = " + maTieuChi[i] + " " +
                                "  update KeHoach_TieuChi_TheoNgay set  KeHoach = " + keHoach[i] + ", ThoiGianNhapCuoiCung = GETDATE() " +
                                "  where HeaderID = " + headerIDPlanDay + " and MaTieuChi = " + maTieuChi[i] + " " +
                                "  update KeHoach_TieuChi_TheoThang set  SanLuong = " + KHDC[i] + ", ThoiGianNhapCuoiCung = GETDATE() " +
                                "  where HeaderID = " + headerIDMonth + " and MaTieuChi = " + maTieuChi[i] + " and ThoiGianNhapCuoiCung = '" + maxDate.Max + "'" +
                                "  update header_ThucHienTheoNgay set NgaySanXuat = " + ngaySX + " where HeaderID = " + headerIDDay + " ";
                                db.Database.ExecuteSqlCommand(query);
                            }
                        }
                        else if (checkList.Count <= 0 && checkList2.Count <= 0)
                        {
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
                                string query = "insert into ThucHien_TieuChi_TheoNgay (HeaderID,MaTieuChi,SanLuong,GhiChu) " +
                                    "values(" + headerIDDay + "," + maTieuChi[i] + "," + thucHien[i] + ",'" + ghiChu[i] + "')" +
                                    "insert into KeHoach_TieuChi_TheoNgay (HeaderID, MaTieuChi, KeHoach, ThoiGianNhapCuoiCung) " +
                                    "values(" + headerIDPlanDay + ", " + maTieuChi[i] + ", " + keHoach[i] + ", GETDATE()) " +
                                    "insert into KeHoach_TieuChi_TheoThang (HeaderID, MaTieuChi, SanLuong, ThoiGianNhapCuoiCung) " +
                                    " values(" + headerIDMonth + ", " + maTieuChi[i] + ", " + KHDC[i] + ", GETDATE())";
                                db.Database.ExecuteSqlCommand(query);
                            }
                        }
                        else
                        {
                            return Json(new { success = "dataSuck" }, JsonRequestBehavior.AllowGet);
                        }
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