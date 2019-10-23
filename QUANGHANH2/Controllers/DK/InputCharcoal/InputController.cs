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
            List<SanXuat> listSX = new List<SanXuat>();
            List<SanXuat> listKH = new List<SanXuat>();
            List<SanXuat> listKHDC = new List<SanXuat>();
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
                    List<header_KeHoachTungThang> checkList3 = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == px_value && x.ThangKeHoach == month && x.NamKeHoach == year).ToList();

                    if (checkList.Count <= 0)
                    {
                        string sql = "select a.MaTieuChi, a.TenTieuChi,case when b.luyke is null then 0 else b.luyke end 'LuyKe', a.DonViDo from " +
                                    "(select pb.MaTieuChi, tc.TenTieuChi, tc.DonViDo from PhongBan_TieuChi pb left " +
                                    "join TieuChi tc " +
                                    "on pb.MaTieuChi = tc.MaTieuChi " +
                                    "where pb.MaPhongBan = '" + px_value + "' ) as a " +
                                    "left join( " +
                                    "select a.MaPhongBan, a.MaTieuChi, sum(a.SanLuong) as 'luyke' " +
                                    "from(select t.SanLuong, t.MaTieuChi, h.MaPhongBan " +
                                    "from header_ThucHienTheoNgay h left " +
                                    "join ThucHien_TieuChi_TheoNgay t " +
                                    "on h.HeaderID = t.HeaderID " +
                                    "where h.MaPhongBan = '" + px_value + "' and h.Ngay between '" + year + "-" + month + "-1' and '" + date_sql + "' and h.Ca <= " + ca + ") as a " +
                                    "group by a.MaPhongBan,a.MaTieuChi) as b " +
                                    "on a.MaTieuChi = b.MaTieuChi " +
                                    "order by a.MaTieuChi ASC";
                        listSX = db.Database.SqlQuery<SanXuat>(sql).ToList();
                        foreach(var item in listSX)
                        {
                            item.chenhlech = (Convert.ToInt32(item.SanLuong) - Convert.ToInt32(item.KeHoach)).ToString();
                            item.percentDay = (Convert.ToInt32(item.SanLuong) / Convert.ToInt32(item.KeHoach) * 100).ToString();
                            //item.percentAll = (Convert.ToInt32(item.LuyKe) / Convert.ToInt32(item.KHDC) * 100).ToString();
                        }
                        flag = true;
                    }
                    else
                    {
                        string query = "select a.MaTieuChi, a.GhiChu,case when a.NgaySanXuat is null then 0 else a.NgaySanXuat end 'NgaySanXuat', a.SanLuong, b.luyke, c.DonViDo, c.TenTieuChi from " +
                                "(select thDay.MaTieuChi, thDay.GhiChu, headtH.NgaySanXuat, thDay.SanLuong from header_ThucHienTheoNgay headTH " +
                                "inner " +
                                "join ThucHien_TieuChi_TheoNgay thDay " +
                                "on headTH.HeaderID = thDay.HeaderID " +
                                "where headTH.MaPhongBan = '" + px_value + "' and headTH.Ngay = '" + date_sql + "' and headTH.Ca = " + ca + ") as a " +
                                "inner join( " +
                                "select a.MaPhongBan, a.MaTieuChi, sum(a.SanLuong) as 'luyke' " +
                                "from(select t.SanLuong, t.MaTieuChi, h.MaPhongBan " +
                                "from header_ThucHienTheoNgay h left " +
                                "join ThucHien_TieuChi_TheoNgay t " +
                                "on h.HeaderID = t.HeaderID " +
                                "where h.MaPhongBan = '" + px_value + "' and h.Ngay between '" + year + "-" + month + "-1' and '" + date_sql + "' and h.Ca <= " + ca + ") as a " +
                                "group by a.MaPhongBan,a.MaTieuChi) as b " +
                                "on a.MaTieuChi = b.MaTieuChi " +
                                "inner join (select tc.MaTieuChi, pb.MaPhongBan, tc.TenTieuChi, tc.DonViDo from PhongBan_TieuChi pb left join TieuChi tc on pb.MaTieuChi = tc.MaTieuChi " +
                                "where pb.MaPhongBan = '" + px_value + "') as c " +
                                "on b.MaTieuChi = c.MaTieuChi " +
                                "order by a.MaTieuChi";
                        listSX = db.Database.SqlQuery<SanXuat>(query).ToList();
                        foreach (var item in listSX)
                        {
                            item.chenhlech = (Convert.ToInt32(item.SanLuong) - Convert.ToInt32(item.KeHoach)).ToString();
                            item.percentDay = (Convert.ToInt32(item.SanLuong) / Convert.ToInt32(item.KeHoach) * 100).ToString();
                            //item.percentAll = (Convert.ToInt32(item.LuyKe) / Convert.ToInt32(item.KHDC) * 100).ToString();
                        }
                        flag = false;
                    }
                    if (checkList2.Count <= 0)
                    {
                        string sql = "select * from ( " +
                            "select tc.TenTieuChi, tc.DonViDo, tc.MaTieuChi, pb.MaPhongBan " +
                            "from PhongBan_TieuChi pb left join TieuChi tc " +
                            "on pb.MaTieuChi = tc.MaTieuChi " +
                            "where pb.MaPhongBan = '" + px_value + "') as a " +
                            "left join(select * from header_KeHoach_TieuChi_TheoNgay khDay " +
                            "where khDay.NgayNhapKH = '" + date_sql + "') as b " +
                            "on b.MaPhongBan = a.MaPhongBan " +
                            "order by a.MaTieuChi";
                        listKH = db.Database.SqlQuery<SanXuat>(sql).ToList();
                    }
                    else
                    {
                        string sql = "select a.*, khDay2.KeHoach, c.DonViDo, c.TenTieuChi from " +
                                "(select headKH.HeaderID, headKH.MaPhongBan, Headkh.Ca, headKH.NgayNhapKH, khDay.MaTieuChi, MAX(khDay.ThoiGianNhapCuoiCung) as 'MaxDate' " +
                                "from header_KeHoach_TieuChi_TheoNgay headKH " +
                                "left " +
                                "join KeHoach_TieuChi_TheoNgay khDay " +
                                "on headKH.HeaderID = khDay.HeaderID " +
                                "where headKH.MaPhongBan = '" + px_value + "'  and headKH.Ca = " + ca + " and headKH.NgayNhapKH = '" + date_sql + "' " +
                                "group by headKH.HeaderID, headKH.MaPhongBan, Headkh.Ca, headKH.NgayNhapKH, khDay.MaTieuChi) as a " +
                                "inner join KeHoach_TieuChi_TheoNgay khDay2 " +
                                "on a.HeaderID = khDay2.HeaderID and a.MaxDate = khday2.ThoiGianNhapCuoiCung " +
                                "inner join(select tc.TenTieuChi, tc.DonViDo, tc.MaTieuChi from PhongBan_TieuChi pb inner join TieuChi tc " +
                                "on pb.MaTieuChi = tc.MaTieuChi " +
                                "where pb.MaPhongBan = '" + px_value + "') as c " +
                                "on c.MaTieuChi = a.MaTieuChi " +
                                "order by a.MaTieuChi";
                        listKH = db.Database.SqlQuery<SanXuat>(sql).ToList();
                    }
                    if (checkList3.Count <= 0)
                    {
                        string sql = "select pbtc.MaTieuChi, pbtc.DonViDo, pbtc.TenTieuChi, case when khdc.KHDC is null then 0 else khdc.KHDC end 'KHDC', " +
                                        "case when khdc.SoNgayLamViec is null then 0 else khdc.SoNgayLamViec end 'SoNgayLamViec'  from " +
                                        "(select pb.MaTieuChi, pb.MaPhongBan, tc.DonViDo, tc.TenTieuChi from PhongBan_TieuChi pb left " +
                                        "join TieuChi tc on pb.MaTieuChi = tc.MaTieuChi " +
                                        "where pb.MaPhongBan = '" + px_value + "') as pbtc " +
                                        "left join(select a.MaTieuChi, a.ThangKeHoach, a.NamKeHoach, b.SanLuong as 'KHDC',a.SoNgayLamViec from( " +
                                        "select headKH.MaPhongBan, headKH.ThangKeHoach, headKH.NamKeHoach, " +
                                        "headKH.SoNgayLamViec, khMonth.MaTieuChi, MAX(khMonth.ThoiGianNhapCuoiCung) as 'MaxDate' " +
                                        "from header_KeHoachTungThang headKH " +
                                        "left " +
                                        "join KeHoach_TieuChi_TheoThang khMonth " +
                                        "on headKH.HeaderID = khMonth.HeaderID " +
                                        "where headKH.MaPhongBan = '" + px_value + "' " +
                                        "and headKH.ThangKeHoach = " + month + " " +
                                        "group by headKH.MaPhongBan, headKH.ThangKeHoach, headKH.NamKeHoach,  " +
                                        "headKH.SoNgayLamViec, khMonth.MaTieuChi) as a " +
                                        "left join(select * from KeHoach_TieuChi_TheoThang khMonth " +
                                        ") as b on a.MaTieuChi = b.MaTieuChi and a.MaxDate = b.ThoiGianNhapCuoiCung) as khdc " +
                                        "on pbtc.MaTieuChi = khdc.MaTieuChi";
                        listKHDC = db.Database.SqlQuery<SanXuat>(sql).ToList();
                    }
                    else
                    {
                        string sql = "select pbtc.MaTieuChi, pbtc.DonViDo, pbtc.TenTieuChi, khdc.KHDC, khdc.SoNgayLamViec from " +
                                        "(select pb.MaTieuChi, pb.MaPhongBan, tc.DonViDo, tc.TenTieuChi from PhongBan_TieuChi pb left " +
                                        "join TieuChi tc on pb.MaTieuChi = tc.MaTieuChi " +
                                        "where pb.MaPhongBan = '" + px_value + "') as pbtc " +
                                        "left join(select a.MaTieuChi, a.ThangKeHoach, a.NamKeHoach, b.SanLuong as 'KHDC',a.SoNgayLamViec from( " +
                                        "select headKH.MaPhongBan, headKH.ThangKeHoach, headKH.NamKeHoach, " +
                                        "headKH.SoNgayLamViec, khMonth.MaTieuChi, MAX(khMonth.ThoiGianNhapCuoiCung) as 'MaxDate' " +
                                        "from header_KeHoachTungThang headKH " +
                                        "left " +
                                        "join KeHoach_TieuChi_TheoThang khMonth " +
                                        "on headKH.HeaderID = khMonth.HeaderID " +
                                        "where headKH.MaPhongBan = '" + px_value + "' " +
                                        "and headKH.ThangKeHoach = " + month + " " +
                                        "group by headKH.MaPhongBan, headKH.ThangKeHoach, headKH.NamKeHoach,  " +
                                        "headKH.SoNgayLamViec, khMonth.MaTieuChi) as a " +
                                        "left join(select * from KeHoach_TieuChi_TheoThang khMonth " +
                                        ") as b on a.MaTieuChi = b.MaTieuChi and a.MaxDate = b.ThoiGianNhapCuoiCung) as khdc " +
                                        "on pbtc.MaTieuChi = khdc.MaTieuChi";
                        listKHDC = db.Database.SqlQuery<SanXuat>(sql).ToList();
                    }

                    for (int i = 0; i < listSX.Count; i++)
                    {
                        listSX[i].KeHoach = listKH[i].KeHoach;
                        listSX[i].KHDC = listKHDC[i].KHDC;
                        if (listSX[i].GhiChu == null || listSX[i].GhiChu.Equals("null"))
                        {
                            listSX[i].GhiChu = "";
                        }
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
                ngay_SX_now = listSX.ElementAt(0).NgaySanXuat;

                foreach (var item in listSX)
                {
                    item.chenhlech = (Math.Round(Convert.ToDouble(item.SanLuong) - Convert.ToDouble(item.KeHoach), 2)).ToString();
                    if (Convert.ToDouble(item.KeHoach) == 0)
                    {
                        item.percentDay = 0 + "";
                    }
                    else
                    {
                        item.percentDay = (Math.Round(Convert.ToDouble(item.SanLuong) / Convert.ToDouble(item.KeHoach) * 100, 2)).ToString();
                    }
                    if (Convert.ToDouble(item.KHDC) == 0)
                    {
                        item.percentMonth = 0 + "";
                    }
                    else
                    {
                        item.percentMonth = (Math.Round(Convert.ToDouble(item.LuyKe) / Convert.ToDouble(item.KHDC) * 100, 2)).ToString();
                    }
                    item.luyke_temp = (Math.Round(Convert.ToDouble(item.LuyKe), 2)).ToString();
                    item.tong = (Math.Round(Convert.ToDouble(item.KHDC) - Convert.ToDouble(item.luyke_temp), 2)).ToString();
                    if (Convert.ToDouble(ngaySX - item.NgaySanXuat) <= 0)
                    {
                        item.OneDay = 0 + "";
                    }
                    else
                    {
                        item.OneDay = (Math.Round(Convert.ToDouble(item.tong) / Convert.ToDouble(ngaySX - item.NgaySanXuat), 2)).ToString();
                    }
                    item.LuyKe = (Math.Round(Convert.ToDouble(item.LuyKe) - Convert.ToDouble(item.SanLuong), 2));
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
                        int caSXConvert = Convert.ToInt32(ca_value);
                        KeHoach_TieuChi_TheoThang khMonth = new KeHoach_TieuChi_TheoThang();

                        header_KeHoach_TieuChi_TheoNgay khtctn = new header_KeHoach_TieuChi_TheoNgay();
                        khtctn.MaPhongBan = px_value;
                        khtctn.NgayNhapKH = ngaySXFix;
                        khtctn.Ca = Convert.ToInt32(ca_value);
                        db.header_KeHoach_TieuChi_TheoNgay.Add(khtctn);
                        db.SaveChanges();

                        var headerIDPlanDay = db.header_KeHoach_TieuChi_TheoNgay.Where(x => x.MaPhongBan == px_value && x.NgayNhapKH == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();
                        var headerIDMonth = db.header_KeHoachTungThang.Where(x => x.MaPhongBan == px_value && x.ThangKeHoach == ngaySXFix.Month && x.NamKeHoach == ngaySXFix.Year).Select(x => x.HeaderID).FirstOrDefault();

                        if (checkList.Count > 0)
                        {
                            var headerIDDay = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ngay == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();

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
                                if (thucHien[i].Equals(""))
                                {
                                    thucHien[i] = "0";
                                }
                                if (keHoach[i].Equals(""))
                                {
                                    keHoach[i] = "0";
                                }
                                if (KHDC[i].Equals(""))
                                {
                                    KHDC[i] = "0";
                                }

                                string query = "update ThucHien_TieuChi_TheoNgay set SanLuong = " + thucHien[i] + ",GhiChu = '" + ghiChu[i] + "' " +
                                "  where HeaderID = " + headerIDDay + " and MaTieuChi = " + maTieuChi[i] + " " +
                                "  insert into KeHoach_TieuChi_TheoNgay (HeaderID, MaTieuChi, KeHoach, ThoiGianNhapCuoiCung) " +
                                "  values(" + headerIDPlanDay + ", " + maTieuChi[i] + ", " + keHoach[i] + ", GETDATE())  " +
                                "  insert into KeHoach_TieuChi_TheoThang (HeaderID, MaTieuChi, SanLuong, ThoiGianNhapCuoiCung) " +
                                "  values(" + headerIDMonth + ", " + maTieuChi[i] + ", " + KHDC[i] + ", GETDATE())";
                                db.Database.ExecuteSqlCommand(query);
                            }
                        }
                        else if (checkList.Count <= 0)
                        {

                            header_ThucHienTheoNgay tttn = new header_ThucHienTheoNgay();
                            tttn.MaPhongBan = px_value;
                            tttn.Ngay = ngaySXFix;
                            tttn.Ca = Convert.ToInt32(ca_value);
                            tttn.NgaySanXuat = Convert.ToInt32(ngaySX);
                            db.header_ThucHienTheoNgay.Add(tttn);
                            db.SaveChanges();

                            var headerIDDay = db.header_ThucHienTheoNgay.Where(x => x.MaPhongBan == px_value && x.Ngay == ngaySXFix && x.Ca == caSXConvert).Select(x => x.HeaderID).FirstOrDefault();

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
                                if (thucHien[i].Equals(""))
                                {
                                    thucHien[i] = "0";
                                }
                                if (keHoach[i].Equals(""))
                                {
                                    keHoach[i] = "0";
                                }
                                if (KHDC[i].Equals(""))
                                {
                                    KHDC[i] = "0";
                                }
                                string query = "insert ThucHien_TieuChi_TheoNgay (HeaderID, MaTieuChi, SanLuong, GhiChu) " +
                               "  values (" + headerIDDay + "," + maTieuChi[i] + "," + thucHien[i] + ",'" + ghiChu[i] + "') " +
                               "  insert into KeHoach_TieuChi_TheoNgay (HeaderID, MaTieuChi, KeHoach, ThoiGianNhapCuoiCung) " +
                               "  values(" + headerIDPlanDay + ", " + maTieuChi[i] + ", " + keHoach[i] + ", GETDATE())  " +
                               "  insert into KeHoach_TieuChi_TheoThang (HeaderID, MaTieuChi, SanLuong, ThoiGianNhapCuoiCung) " +
                               "  values(" + headerIDMonth + ", " + maTieuChi[i] + ", " + KHDC[i] + ", GETDATE())";
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