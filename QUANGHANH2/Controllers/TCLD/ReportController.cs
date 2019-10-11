using OfficeOpenXml;
using OfficeOpenXml.Style;
using QUANGHANH2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;
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
            if (date == null)
            {
                date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            if (donvi == null)
            {
                donvi = "DL1";
            }
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string headerca1 = getHeader(date, donvi, "1");
            string bodyca1 = Wherecondition(date, donvi, "1");
            string headerca2 = getHeader(date, donvi, "2");
            string bodyca2 = Wherecondition(date, donvi, "2");
            string headerca3 = getHeader(date, donvi, "3");
            string bodyca3 = Wherecondition(date, donvi, "3");
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.TenToChuc = db.Departments.ToList();
                ViewBag.HeaderCa1 = db.Database.SqlQuery<Ngay>(headerca1).ToList().First();
                ViewBag.Ca1 = db.Database.SqlQuery<Ngay>(bodyca1).ToList();
                Header_DiemDanh_NangSuat_LaoDong header1 = db.Header_DiemDanh_NangSuat_LaoDong.Find(1, donvi, ngay);
                ViewBag.Ca1Vang = db.DiemDanh_NangSuatLaoDong
                    .Where(a => a.LyDoVangMat != null)
                    .Where(a => a.HeaderID == header1.HeaderID)
                    .ToList();
                string mnv = "";
                List<Vang> lists = new List<Vang>();
                 for(int i=0; i< ViewBag.HeaderCa1.TongNghi; i++)
                {
                     mnv = ViewBag.Ca1Vang[i].MaNV;
                    Vang v = new Vang
                    {
                        Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
                        MaNV = ViewBag.Ca1Vang[i].MaNV,
                        ChucVu = db.NhanViens.Where(a =>a.MaNV == mnv).ToList().First().LoaiNhanVien,
                        LyDo = ViewBag.Ca1Vang[i].LyDoVangMat,
                    };
                    lists.Add(v);
                }
                ViewBag.Ca1Vang = lists;
                ViewBag.HeaderCa2 = db.Database.SqlQuery<Ngay>(headerca2).ToList().First();
                ViewBag.Ca2 = db.Database.SqlQuery<Ngay>(bodyca2).ToList();
                Header_DiemDanh_NangSuat_LaoDong header2 = db.Header_DiemDanh_NangSuat_LaoDong.Find(2, donvi, ngay);
                ViewBag.Ca2Vang = db.DiemDanh_NangSuatLaoDong
                   .Where(a => a.LyDoVangMat != null)
                   .Where(a => a.HeaderID == header2.HeaderID)
                   .ToList();
                List<Vang> lists2 = new List<Vang>();
                for (int i = 0; i < ViewBag.HeaderCa2.TongNghi; i++)
                {
                     mnv = ViewBag.Ca2Vang[i].MaNV;
                    Vang v = new Vang
                    {
                        Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
                        MaNV = ViewBag.Ca2Vang[i].MaNV,
                        ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
                        LyDo = ViewBag.Ca2Vang[i].LyDoVangMat,
                    };
                    lists2.Add(v);
                }
                ViewBag.Ca2Vang = lists2;
                ViewBag.HeaderCa3 = db.Database.SqlQuery<Ngay>(headerca3).ToList().First();
                ViewBag.Ca3 = db.Database.SqlQuery<Ngay>(bodyca3).ToList();
                Header_DiemDanh_NangSuat_LaoDong header3 = db.Header_DiemDanh_NangSuat_LaoDong.Find(3, donvi, ngay);
                ViewBag.Ca3Vang = db.DiemDanh_NangSuatLaoDong
                    .Where(a => a.LyDoVangMat != null)
                    .Where(a => a.HeaderID == header3.HeaderID)
                    .ToList();
                List<Vang> lists3 = new List<Vang>();
                for (int i = 0; i < ViewBag.HeaderCa3.TongNghi; i++)
                {
                     mnv = ViewBag.Ca3Vang[i].MaNV;
                    Vang v = new Vang
                    {
                        Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
                        MaNV = ViewBag.Ca3Vang[i].MaNV,
                        ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
                        LyDo = ViewBag.Ca3Vang[i].LyDoVangMat,
                    };
                    lists3.Add(v);
                }
                ViewBag.Ca3Vang = lists3;
                ViewBag.Tong = new Ngay
                {
                    LoaiNhanVien = "Tổng",
                    LDTheoDS = ViewBag.HeaderCa1.LDTheoDS + ViewBag.HeaderCa2.LDTheoDS + ViewBag.HeaderCa3.LDTheoDS,
                    LDSX = ViewBag.HeaderCa1.LDSX + ViewBag.HeaderCa2.LDSX + ViewBag.HeaderCa3.LDSX,
                    Phep = ViewBag.HeaderCa1.Phep + ViewBag.HeaderCa2.Phep + ViewBag.HeaderCa3.Phep,
                    Om = ViewBag.HeaderCa1.Om + ViewBag.HeaderCa2.Om + ViewBag.HeaderCa3.Om,
                    Bu = ViewBag.HeaderCa1.Bu + ViewBag.HeaderCa2.Bu + ViewBag.HeaderCa3.Bu,
                    TT = ViewBag.HeaderCa1.TT + ViewBag.HeaderCa2.TT + ViewBag.HeaderCa3.TT,
                    VLD = ViewBag.HeaderCa1.VLD + ViewBag.HeaderCa2.VLD + ViewBag.HeaderCa3.VLD,
                    H = ViewBag.HeaderCa1.H + ViewBag.HeaderCa2.H + ViewBag.HeaderCa3.H,
                    TongNghi = ViewBag.HeaderCa1.TongNghi + ViewBag.HeaderCa2.TongNghi + ViewBag.HeaderCa3.TongNghi,
                };
                ViewBag.TongDetail = new ArrayList();
                for (int i = 0; i < ViewBag.Ca1.Count; i++)
                {
                    ViewBag.TongDetail.Add(new Ngay
                    {
                        LoaiNhanVien = ViewBag.Ca1[i].LoaiNhanVien,
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


        
        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-ngay")]
        public ActionResult DailyAll(string date)
        {
            DateTime dateTime = DateTime.Now;
            if (date != null)
            {
                dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string varname1 = 
               "SELECT Isnull(tongsodiem, 0)  AS TongSoDiem, " + "\n"
             + "       Isnull(tongsothan, 0)  AS TongSoThan, " + "\n"
             + "       Isnull(tongsometlo, 0) AS TongSoMetLo, " + "\n"
             + "       Isnull(tongsoxen, 0)   AS TongSoXen, " + "\n"
             + "       de.department_id       AS Name " + "\n"
             + "FROM   (SELECT Sum(totaleffort)   AS TongSoDiem, " + "\n"
             + "               Sum(thanthuchien)  AS TongSoThan, " + "\n"
             + "               Sum(metlothuchien) AS TongSoMetLo, " + "\n"
             + "               Sum(xenthuchien)   AS TongSoXen, " + "\n"
             + "               maphongban " + "\n"
             + "        FROM   header_diemdanh_nangsuat_laodong " + "\n"
             + "        WHERE  ngaydiemdanh = @NgayDiemDanh " + "\n"
             + "        GROUP  BY maphongban) h " + "\n"
             + "       RIGHT JOIN department de " + "\n"
             + "               ON de.department_id = h.maphongban " + "\n"
             + "WHERE  de.department_type LIKE N'%Chính%' " + "\n"
             + "       AND de.department_id != 'PXST' " + "\n"
             + "       AND de.department_id != 'PXLT'";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                ViewBag.TatCaDonVi = db.Database.SqlQuery<BaoCaoNgayDB>(varname1, new SqlParameter("NgayDiemDanh", dateTime)).ToList();
                //string[] teststring = new string[ViewBag.TatCaDonVi.Count];
                //for (int i = 0; i < ViewBag.TatCaDonVi.Count; i++)
                //{
                //    teststring[i] = ViewBag.TatCaDonVi[i].Name;
                //}
                //ViewBag.TenDonVi = teststring;

                //int CBQL = 0;
                //int KT = 0;
                //int CD = 0;
                //int HSTT = 0;
                //int TongLaoDong = 0;
                //int LDTheoDS = 0;
                //int LDSX = 0;
                //int Om = 0;
                //int VLD = 0;
                //int Khac = 0;
                //int TongNghi = 0;
                //decimal TyLe = 0;
                //foreach (var item in ViewBag.TatCaDonVi)
                //{
                //    CBQL += item.CBQL;
                //    KT += item.KT;
                //    CD += item.CD;
                //    HSTT += item.HSTT;
                //    TongLaoDong += item.TongLaoDong;
                //    LDTheoDS += item.LDTheoDS;
                //    LDSX += item.LDSX;
                //    Om += item.Om;
                //    VLD += item.VLD;
                //    Khac += item.Khac;
                //    TongNghi += item.TongNghi;
                //    TyLe += item.TyLe;
                //};
                //if (ViewBag.TatCaDonVi.Count > 0)
                //{
                //    TyLe = Math.Round(TyLe / ViewBag.TatCaDonVi.Count, 2);
                //};
                //ViewBag.TatCaDonViFooter = new TatCaDonVI
                //{
                //    Name = "Tổng",
                //CBQL = CBQL,
                //    KT = KT,
                //    CD = CD,
                //    HSTT = HSTT,
                //    TongLaoDong = TongLaoDong,
                //    LDTheoDS = LDTheoDS,
                //    LDSX = LDSX,
                //    Om = Om,
                //    VLD = VLD,
                //    Khac = Khac,
                //    TongNghi = TongNghi,
                //    TyLe = TyLe
                //};
            }
            return View("/Views/TCLD/Report/DailyAll.cshtml");
        }


        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-ngay/excel")]
        public void ReturnExcel(string date)
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Report/Báo cáo năng suất lao động và tiền lương theo các phân xưởng theo ngày.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                if (date == null)
                {
                    date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
                }
                string tatcadonvi = QueryForReportAlll(date);
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    ViewBag.TatCaDonVi = db.Database.SqlQuery<TatCaDonVI>(tatcadonvi).ToList();
                    int CBQL = 0;
                    int KT = 0;
                    int CD = 0;
                    int HSTT = 0;
                    int TongLaoDong = 0;
                    int LDTheoDS = 0;
                    int LDSX = 0;
                    int Om = 0;
                    int VLD = 0;
                    int Khac = 0;
                    int TongNghi = 0;
                    decimal TyLe = 0;
                    foreach (var item in ViewBag.TatCaDonVi)
                    {
                        CBQL += item.CBQL;
                        KT += item.KT;
                        CD += item.CD;
                        HSTT += item.HSTT;
                        TongLaoDong += item.TongLaoDong;
                        LDTheoDS += item.LDTheoDS;
                        LDSX += item.LDSX;
                        Om += item.Om;
                        VLD += item.VLD;
                        Khac += item.Khac;
                        TongNghi += item.TongNghi;
                        TyLe += item.TyLe;
                    };
                    if (ViewBag.TatCaDonVi.Count > 0)
                    {
                        TyLe = Math.Round(TyLe / ViewBag.TatCaDonVi.Count, 2);
                    };
                    ViewBag.TatCaDonViFooter = new TatCaDonVI
                    {
                        Name = "Tổng",
                        //CBQL = CBQL,
                        //KT = KT,
                        //CD = CD,
                        //HSTT = HSTT,
                        //TongLaoDong = TongLaoDong,
                        //LDTheoDS = LDTheoDS,
                        //LDSX = LDSX,
                        //Om = Om,
                        //VLD = VLD,
                        //Khac = Khac,
                        //TongNghi = TongNghi,
                        //TyLe = TyLe
                    };
                    excelWorksheet.Cells[1, 1].Value = "BÁO CÁO THỰC HIỆN LAO ĐỘNG, TIỀN LƯƠNG CÔNG NHÂN TRỰC TIẾP NGÀY " + date;
                   
                    int k = 8;
                    int stt = 1;
                    for (int i = 0; i < ViewBag.TatCaDonVi.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = stt.ToString();
                        excelWorksheet.Cells[k, 2].Value = ViewBag.TatCaDonVi[i].Name;
                        excelWorksheet.Cells[k, 3].Value = ViewBag.TatCaDonVi[i].CBQL;
                        excelWorksheet.Cells[k, 4].Value = ViewBag.TatCaDonVi[i].KT;
                        excelWorksheet.Cells[k, 5].Value = ViewBag.TatCaDonVi[i].CD;
                        excelWorksheet.Cells[k, 6].Value = ViewBag.TatCaDonVi[i].HSTT;
                        excelWorksheet.Cells[k, 7].Value = ViewBag.TatCaDonVi[i].TongLaoDong;
                        excelWorksheet.Cells[k, 12].Value = ViewBag.TatCaDonVi[i].LDTheoDS;
                        excelWorksheet.Cells[k, 13].Value = ViewBag.TatCaDonVi[i].LDSX;
                        excelWorksheet.Cells[k, 14].Value = ViewBag.TatCaDonVi[i].VLD;
                        excelWorksheet.Cells[k, 15].Value = ViewBag.TatCaDonVi[i].Om;
                        excelWorksheet.Cells[k, 16].Value = ViewBag.TatCaDonVi[i].Khac;
                        excelWorksheet.Cells[k, 17].Value = ViewBag.TatCaDonVi[i].TongNghi;
                        excelWorksheet.Cells[k, 18].Value = ViewBag.TatCaDonVi[i].TyLe;
                        k++;
                        stt++;
                    }
                    excelWorksheet.Cells[k, 1,k,25].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 1].Value = ViewBag.TatCaDonViFooter.Name;
                    excelWorksheet.Cells[k, 3].Value = ViewBag.TatCaDonViFooter.CBQL;
                    excelWorksheet.Cells[k, 4].Value = ViewBag.TatCaDonViFooter.KT;
                    excelWorksheet.Cells[k, 5].Value = ViewBag.TatCaDonViFooter.CD;
                    excelWorksheet.Cells[k, 6].Value = ViewBag.TatCaDonViFooter.HSTT;
                    excelWorksheet.Cells[k, 7].Value = ViewBag.TatCaDonViFooter.TongLaoDong;
                    excelWorksheet.Cells[k, 12].Value = ViewBag.TatCaDonViFooter.LDTheoDS;
                    excelWorksheet.Cells[k, 13].Value = ViewBag.TatCaDonViFooter.LDSX;
                    excelWorksheet.Cells[k, 14].Value = ViewBag.TatCaDonViFooter.VLD;
                    excelWorksheet.Cells[k, 15].Value = ViewBag.TatCaDonViFooter.Om;
                    excelWorksheet.Cells[k, 16].Value = ViewBag.TatCaDonViFooter.Khac;
                    excelWorksheet.Cells[k, 17].Value = ViewBag.TatCaDonViFooter.TongNghi;
                    excelWorksheet.Cells[k, 18].Value = ViewBag.TatCaDonViFooter.TyLe;
                    string location = HostingEnvironment.MapPath("/excel/TCLD/download");
                    excelPackage.SaveAs(new FileInfo(location + "/Báo cáo năng suất lao động và tiền lương theo các phân xưởng theo ngày.xlsx"));
                }

            }
        }

        private string Wherecondition(string date, string donvi, string ca)
        {
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "select distinct NhanVien.LoaiNhanVien, ISNULL(b.LDTheoDS,0) as LDTheoDS, ISNULL(b.LĐSX,0) as LDSX, " +
                "ISNULL(b.Phep,0) as Phep, ISNULL(b.Om,0) as Om, ISNULL(b.Bu,0) as Bu, ISNULL(b.TT,0) as TT, " +
                "ISNULL(b.VLD,0) as VLD, ISNULL(b.H,0) as H, ISNULL(b.TongNghi,0) as TongNghi" +
                "from NhanVien  left join  (select *, (Phep+Om+Bu+TT+VLD+H)as " +
                "TongNghi from  (select  n.LoaiNhanVien, COUNT(d.CaDiemDanh) as LDTheoDS, " +
                "Sum(CASE WHEN LyDoVangMat is null THEN 1 ELSE 0 END)  as LĐSX, " +
                "Sum(CASE WHEN LyDoVangMat like N'Phép' THEN 1 ELSE 0 END) AS Phep , " +
                "Sum(CASE WHEN LyDoVangMat like N'Ốm' THEN 1 ELSE 0 END) AS Om , " +
                "Sum(CASE WHEN LyDoVangMat like N'Bù' THEN 1 ELSE 0 END) AS Bu , " +
                "Sum(CASE WHEN LyDoVangMat like N'TT' THEN 1 ELSE 0 END) AS TT , " +
                "Sum(CASE WHEN LyDoVangMat like N'VLD' THEN 1 ELSE 0 END) AS VLD , " +
                "Sum(CASE WHEN LyDoVangMat like N'H' THEN 1 ELSE 0 END) AS H" +
                "NhanVien n, DiemDanh_NangSuatLaoDong d, " +
                "Department de, Header_DiemDanh_NangSuat_LaoDong h " +
                "where n.MaNV = d.MaNV and de.department_id = h.MaPhongBan and d.HeaderID = h.HeaderID" +
                "h.Ca = " + ca + "  and h.NgayDiemDanh = '" + ngay + "' and h.MaPhongBan like " +
                "'" + donvi + "' group by   n.LoaiNhanVien) a) b on NhanVien.LoaiNhanVien= b.LoaiNhanVien   where NhanVien.LoaiNhanVien iS not NULL";
            return query;
        }

        private string getHeader(string date, string donvi, string ca)
        {
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query = "select 'CA " + ca + "' as LoaiNhanVien, *, (Phep+Om+Bu+TT+VLD+H) as TongNghi " +
                "from (select  COUNT(d.CaDiemDanh) as LDTheoDS, Isnull( Sum(CASE WHEN LyDoVangMat " +
                "is null THEN 1 ELSE Null END),0)  as LDSX, Isnull( Sum(CASE WHEN LyDoVangMat " +
                "like N'Phép' THEN 1 ELSE 0 END),0) AS Phep , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'Ốm' THEN 1 ELSE 0 END),0) AS Om ,  Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'Bù' THEN 1 ELSE 0 END),0) AS Bu ,Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'TT' THEN 1 ELSE 0 END),0) AS TT , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'VLD' THEN 1 ELSE 0 END),0) AS VLD , Isnull(Sum(CASE WHEN LyDoVangMat " +
                "like N'H' THEN 1 ELSE 0 END),0) AS H" +
                "from  NhanVien n, DiemDanh_NangSuatLaoDong d,Department de where " +
                "n.MaNV = d.MaNV and de.department_id = d.MaDonVi and  CaDiemDanh = " + ca + "  and " +
                "NgayDiemDanh = '" + ngay + "' and department_id like '" + donvi + "' ) a";

            return query;
        }

        public static string QueryForReportAlll(string date)
        {
            var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string query= "SELECT DISTINCT department.department_id AS [Name], \n"
            + "                Row_number() \n"
            + "                  OVER ( \n"
            + "                    ORDER BY department.department_id)    AS [STT], \n"
            + "                Isnull(b.cbql, 0)                         AS CBQL, \n"
            + "                Isnull(b.kt, 0)                           AS KT, \n"
            + "                Isnull(b.cd, 0)                           AS CD, \n"
            + "                Isnull(b.hstt, 0)                         AS HSTT, \n"
            + "                Isnull(( b.kt + b.cd + b.hstt ), 0)       AS TongLaoDong, \n"
            + "                Isnull(b.ldtheods, 0)                     AS LDTheoDS, \n"
            + "                Isnull(b.ldsx, 0)                         AS LDSX, \n"
            + "                Isnull(b.om, 0)                           AS Om, \n"
            + "                Isnull(b.vld, 0)                          AS VLD, \n"
            + "                Isnull(( b.phep + b.bu + b.tt + b.h ), 0) AS Khac, \n"
            + "                Isnull(b.tongnghi, 0)                     AS TongNghi, \n"
            + "                Cast(CASE \n"
            + "                       WHEN ( b.ldtheods ) != 0 THEN \n"
            + "                       ( b.ldsx ) * 1.0 / ( b.ldtheods ) * 100 \n"
            + "                       ELSE 100 \n"
            + "                     END AS NUMERIC(36, 2))               AS TyLe \n"
            + "FROM   department \n"
            + "       LEFT JOIN (SELECT *, \n"
            + "                         ( phep + om + bu + tt + vld + h )AS TongNghi \n"
            + "                  FROM   (SELECT de.department_id, \n"
            + "                                 Count(d.manv)      AS LDTheoDS, \n"
            + "                                 (Count(d.manv) \n"
            + "								 -Sum(CASE WHEN lydovangmat LIKE N'Phép' THEN 1  ELSE 0  END)\n"
            + "							     -Sum(CASE WHEN lydovangmat LIKE N'Ốm' THEN 1  ELSE 0 END) \n"
            + "							     -Sum(CASE WHEN lydovangmat LIKE N'Bù' THEN 1 ELSE 0 END)  \n"
            + "							     -Sum(CASE WHEN lydovangmat LIKE N'TT' THEN 1 ELSE 0 END)   \n"
            + "							     -Sum(CASE  WHEN lydovangmat LIKE N'VLD' THEN 1 ELSE 0  END) \n"
            + "							     -Sum(CASE  WHEN lydovangmat LIKE N'H' THEN 1  ELSE 0  END)   \n"
            + "								 )  AS LDSX, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'Phép' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS Phep, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'Ốm' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS Om, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'Bù' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS Bu, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'TT' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS TT, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'VLD' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS VLD, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN lydovangmat LIKE N'H' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS H, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN loainhanvien LIKE N'CBQL' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS CBQL, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN loainhanvien LIKE N'CNKT' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS KT, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN loainhanvien LIKE N'Cơ Điện' \n"
            + "                                     THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS CD, \n"
            + "                                 Sum(CASE \n"
            + "                                       WHEN loainhanvien LIKE N'HSTT' THEN 1 \n"
            + "                                       ELSE 0 \n"
            + "                                     END)             AS HSTT \n"
            + "                          FROM   nhanvien n, \n"
            + "                                 diemdanh_nangsuatlaodong d, \n"
            + "                                 department de, \n"
            + "                                 Header_DiemDanh_NangSuat_LaoDong h"
            + "                          WHERE  n.manv = d.manv \n"
            + "                                 AND de.department_id = h.MaPhongBan \n"
            + "                                 AND h.HeaderID = d.HeaderID \n"
            + "                                 AND h.NgayDiemDanh = '" + ngay + "' \n"
            + "                          GROUP  BY de.department_id) a) b \n"
            + "              ON department.department_id = b.department_id \n"
            + "              WHERE  department.department_type = N'Phân xưởng sản xuất chính' \n"
            + "                     AND department.department_id != 'PXLT' AND department.department_id != 'PXST' ";
            return query;
        }
    }
    public class Ngay
    {
        public string LoaiNhanVien { get; set; }
        public int LDTheoDS { get; set; }
        public int LDSX { get; set; }
        public int Phep { get; set; }
        public int Om { get; set; }
        public int Bu { get; set; }
        public int TT { get; set; }
        public int VLD { get; set; }
        public int H { get; set; }
        public int TongNghi { get; set; }
    }

    public class TatCaDonVI
    {
        public string Name { get; set; }
        public int TyLe { get; set; }
        public double TongSoDiem { get; set; }
        public double TongSoThan { get; set; }
        public double TongSoMetLo { get; set; }
        public double TongSoXen { get; set; }
    }

    public class Vang
    {
        public string Name { get; set; }
        public string MaNV { get; set; }
        public string ChucVu { get; set; }
        public string LyDo { get; set; }
    }
}
