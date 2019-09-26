using QUANGHANH2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class ReportController : Controller
    {
        // GET: /<controller>/
        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-thang")]
        public ActionResult Monthly()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/Report/Monthly.cshtml");
        }
        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-ngay-trong-thang")]
        public ActionResult DepartmentMonthly()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/Report/DepartmentMonthly.cshtml");
        }

        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay")]
        public ActionResult Daily(string date, string donvi)
        {
            string headerca1 = getHeader("25/09/2019", "KT1", "1");
            string bodyca1 = Wherecondition("25/09/2019", "KT1", "1");
            string headerca2 = getHeader("25/09/2019", "KT1", "2");
            string bodyca2 = Wherecondition("25/09/2019", "KT1", "2");
            string headerca3 = getHeader("25/09/2019", "KT1", "3");
            string bodyca3 = Wherecondition("25/09/2019", "KT1", "3");
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.HeaderCa1 = db.Database.SqlQuery<Ngay>(headerca1).ToList().First();
                ViewBag.Ca1 = db.Database.SqlQuery<Ngay>(bodyca1).ToList();
                ViewBag.HeaderCa2 = db.Database.SqlQuery<Ngay>(headerca2).ToList().First();
                ViewBag.Ca2 = db.Database.SqlQuery<Ngay>(bodyca2).ToList();
                ViewBag.HeaderCa3 = db.Database.SqlQuery<Ngay>(headerca3).ToList().First();
                ViewBag.Ca3 = db.Database.SqlQuery<Ngay>(bodyca3).ToList();
                ViewBag.Tong = new Ngay {
                    Loai = "Tổng",
                    LDTheoDS = ViewBag.HeaderCa1.LDTheoDS + ViewBag.HeaderCa2.LDTheoDS + ViewBag.HeaderCa3.LDTheoDS,
                    LDSX = ViewBag.HeaderCa1.LDSX + ViewBag.HeaderCa2.LDSX + ViewBag.HeaderCa3.LDSX,
                    Phep = ViewBag.HeaderCa1.Phep + ViewBag.HeaderCa2.Phep + ViewBag.HeaderCa3.Phep,
                    Om = ViewBag.HeaderCa1.Om + ViewBag.HeaderCa2.Om + ViewBag.HeaderCa3.Om,
                    Bu = ViewBag.HeaderCa1.Bu + ViewBag.HeaderCa2.Bu + ViewBag.HeaderCa3.Bu,
                    TT = ViewBag.HeaderCa1.TT + ViewBag.HeaderCa2.TT + ViewBag.HeaderCa3.TT,
                    VLD = ViewBag.HeaderCa1.VLD + ViewBag.HeaderCa2.VLD + ViewBag.HeaderCa3.VLD,
                    H = ViewBag.HeaderCa1.H + ViewBag.HeaderCa2.H + ViewBag.HeaderCa3.H,
                    TongNghi = ViewBag.HeaderCa1.TongNghi + ViewBag.HeaderCa2.TongNghi + ViewBag.HeaderCa3.TongNghi,
                    NSLDThucHien = ViewBag.HeaderCa1.NSLDThucHien + ViewBag.HeaderCa2.NSLDThucHien + ViewBag.HeaderCa3.NSLDThucHien
                };
                ViewBag.TongDetail = new ArrayList();
                for (int i=0; i< ViewBag.Ca1.Count; i++)
                {
                    ViewBag.TongDetail.Add(new Ngay {
                        Loai = ViewBag.Ca1[i].Loai,
                        LDTheoDS = ViewBag.Ca1[i].LDTheoDS + ViewBag.Ca2[i].LDTheoDS + ViewBag.Ca3[i].LDTheoDS,
                        LDSX = ViewBag.Ca1[i].LDSX + ViewBag.Ca2[i].LDSX + ViewBag.Ca3[i].LDSX
                    });
                }
            }
            return View("/Views/TCLD/Report/Daily.cshtml");
        }

        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay")]
        [HttpPost]
        public ActionResult DailySearch(string date, string donvi)
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/Report/Daily.cshtml");
        }


        //
        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-ngay")]
        public ActionResult DailyAll()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/Report/DailyAll.cshtml");
        }

        private string Wherecondition(string date, string donvi, string ca)
        {
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "select distinct NhanVien.Loai, ISNULL(b.LDTheoDS,0) as LDTheoDS, ISNULL(b.LĐSX,0) as LDSX, " +
                "ISNULL(b.Phep,0) as Phep, ISNULL(b.Om,0) as Om, ISNULL(b.Bu,0) as Bu, ISNULL(b.TT,0), " +
                "ISNULL(b.VLD,0), ISNULL(b.H,0), ISNULL(b.TongNghi,0), ISNULL(b.NSLDThucHien,0) " +
                "from NhanVien  left join  (select *, (Phep+Om+Bu+TT+VLD+H)as " +
                "TongNghi from  (select  n.Loai, COUNT(d.CaDiemDanh) as LDTheoDS, " +
                "Sum(CASE WHEN LyDoVangMat is null THEN 1 ELSE Null END)  as LĐSX, " +
                "Sum(CASE WHEN LyDoVangMat like N'Phép' THEN 1 ELSE Null END) AS Phep , " +
                "Sum(CASE WHEN LyDoVangMat like N'Ốm' THEN 1 ELSE Null END) AS Om , " +
                "Sum(CASE WHEN LyDoVangMat like N'Bù' THEN 1 ELSE Null END) AS Bu , " +
                "Sum(CASE WHEN LyDoVangMat like N'TT' THEN 1 ELSE Null END) AS TT , " +
                "Sum(CASE WHEN LyDoVangMat like N'VLD' THEN 1 ELSE Null END) AS VLD , " +
                "Sum(CASE WHEN LyDoVangMat like N'H' THEN 1 ELSE Null END) AS H , " +
                "sum(NangSuatLaoDong) as NSLDThucHien from  NhanVien n, DiemDanh_NangSuatLaoDong " +
                "d,Department de where n.MaNV = d.MaNV and de.department_id = d.MaDonVi and " +
                "CaDiemDanh = "+ca+"  and NgayDiemDanh = '"+ngay+"' and department_id like " +
                "'"+donvi+"' group by   n.Loai) a) b on NhanVien.Loai= b.Loai   where NhanVien.Loai iS not NULL";
            return query;
        }

        private string getHeader(string date, string donvi, string ca)
        {
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "select 'CA "+ca+"' as Loai, *, (Phep+Om+Bu+TT+VLD+H) as TongNghi " +
                "from (select  COUNT(d.CaDiemDanh) as LDTheoDS, Isnull( Sum(CASE WHEN LyDoVangMat " +
                "is null THEN 1 ELSE Null END),0)  as LDSX, Isnull( Sum(CASE WHEN LyDoVangMat " +
                "like N'Phép' THEN 1 ELSE Null END),0) AS Phep , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'Ốm' THEN 1 ELSE Null END),0) AS Om ,  Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'Bù' THEN 1 ELSE Null END),0) AS Bu ,Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'TT' THEN 1 ELSE Null END),0) AS TT , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'VLD' THEN 1 ELSE Null END),0) AS VLD , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'H' THEN 1 ELSE Null END),0) AS H , Isnull(sum(NangSuatLaoDong),0) as " +
                "NSLDThucHien from  NhanVien n, DiemDanh_NangSuatLaoDong d,Department de where " +
                "n.MaNV = d.MaNV and de.department_id = d.MaDonVi and  CaDiemDanh = "+ca+"  and " +
                "NgayDiemDanh = '"+ngay+"' and department_id like '"+donvi+"' ) a";

            return query;
        }
    }
    public class Ngay
    {
        public string Loai { get; set; }
        public int LDTheoDS { get; set; }
        public int LDSX { get; set; }
        public int Phep { get; set; }
        public int Om { get; set; }
        public int Bu { get; set; }
        public int TT { get; set; }
        public int VLD { get; set; }
        public int H { get; set; }
        public double NSLDThucHien { get; set; }
        public int TongNghi { get; set; }
    }
}
