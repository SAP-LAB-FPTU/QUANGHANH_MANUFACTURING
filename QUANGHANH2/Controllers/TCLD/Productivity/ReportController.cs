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
                for (int i = 0; i < ViewBag.HeaderCa1.TongNghi; i++)
                {
                    mnv = ViewBag.Ca1Vang[i].MaNV;
                    Vang v = new Vang
                    {
                        Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
                        MaNV = ViewBag.Ca1Vang[i].MaNV,
                        //ChucVu = db.NhanViens.Where(a =>a.MaNV == mnv).ToList().First().LoaiNhanVien,
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
                        //ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
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
                        //ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
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


        List<int> tiLeHuyDong = new List<int>();
        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-ngay")]
        public ActionResult DailyAll(string date)
        {
            DateTime dateTime = DateTime.Now.Date;
            if (date != null)
            {
                dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            String varname1 = @"select a.department_id, a.QL, (a.KT + a.CD) as Tong, a.KT, a.CD, 0 as 'HSTT',
                                a.dilam, (a.vld + a.om + a.khac + a.phep) as vang,
                                a.vld,a.om,a.phep,a.khac,
                                (case when (a.KT+ a.CD) = 0 then 0 else round(Convert(float,(a.KT + a.CD - a.tong_nghidai)-(a.vld + a.om + a.khac + a.phep))/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as tile,
                                b.than, b.metlo, b.xen,b.diemluong,a.tong_nghidai,a.nghidai_om,a.nghidai_thld,a.nghidai_vld
                                from
                                (select a.department_id, a.QL, a.KT, a.CD, sum(case when d.DiLam = 1 and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as dilam,
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'vld',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'om',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'phep',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'khac',
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'tong_nghidai',
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_vld',
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_thld',
                                SUM(case when d.LyDoVangMat in (N'Ốm dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_om'
                                 from(select a.department_id,
                                sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL,
                                sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT,
                                sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec
                                where a.department_type like N'%chính%' and a.department_id != 'PXST' and a.department_id != 'PXLT'
                                group by a.department_id)
                                 as a left outer join Header_DiemDanh_NangSuat_LaoDong h
                                on a.department_id = h.MaPhongBan left outer join DiemDanh_NangSuatLaoDong d
                                on h.HeaderID = d.HeaderID
                                group by a.department_id, a.QL, a.KT, a.CD) as a inner join
                                ( select a.department_id,
                                sum(case when h.ThanThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.ThanThucHien else 0 end) as 'than',
                                sum(case when h.MetLoThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.MetLoThucHien else 0 end) as 'metlo',
                                sum(case when h.XenThucHien is not null and h.NgayDiemDanh = @NgayDiemDanh then h.XenThucHien else 0 end) as 'xen',
                                sum(case when h.TotalEffort is not null and h.NgayDiemDanh = @NgayDiemDanh then h.TotalEffort else 0 end) as 'diemluong'
                                from Department a left outer join Header_DiemDanh_NangSuat_LaoDong h
                                on a.department_id = h.MaPhongBan
                                group by a.department_id
                                ) as b on a.department_id = b.department_id";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<BaoCaoNgayDB> all = db.Database.SqlQuery<BaoCaoNgayDB>(varname1, new SqlParameter("NgayDiemDanh", dateTime)).ToList();
                TatCaDonVI tatca = new TatCaDonVI();

                foreach (var item in all)
                {
                    item.tong_tru_nghidai = item.Tong - item.tong_nghidai;
                    if (item.tong_tru_nghidai < 0) item.tong_tru_nghidai = 0;
                    item.dilam = item.tong_tru_nghidai - item.vang;
                    item.tile_dis = Math.Round(item.Tong != 0 ? (double)item.dilam / item.Tong * 100 : 0, 2);

                    tatca.TongLaoDong += item.Tong;
                    tatca.CBQL += item.QL;
                    tatca.KT += item.KT;
                    tatca.CD += item.CD;
                    tatca.HSTT += item.HSTT;
                    tatca.TongNghi += item.tong_nghidai;
                    tatca.VLD += item.nghidai_vld;
                    tatca.LDTheoDS += item.tong_tru_nghidai;
                    tatca.LDSX += item.dilam;
                    tatca.TongNghi += item.vang;
                    tatca.TyLe += item.tile_dis;
                }
                tatca.TyLe = Math.Round(((double)tatca.TyLe / all.Count), 2);
                ViewBag.TatCaDonVi = all;
                ViewBag.TatCaDonViFooter = tatca;


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
                } else
                {
                    //date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                    double TyLe = 0;
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
                        CBQL = CBQL,
                        KT = KT,
                        CD = CD,
                        HSTT = HSTT,
                        TongLaoDong = TongLaoDong,
                        LDTheoDS = LDTheoDS,
                        LDSX = LDSX,
                        Om = Om,
                        VLD = VLD,
                        Khac = Khac,
                        TongNghi = TongNghi,
                        TyLe = TyLe
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
                    excelWorksheet.Cells[k, 1, k, 25].Style.Font.Bold = true;
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

        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-thang")]
        public ActionResult MonthlyAll(string month, string year)
        {
            DateTime dateTime = DateTime.Now.Date;
            if (month == null || year == null)
            {
                month = DateTime.Now.Month + "";
                year = DateTime.Now.Year + "";
            }
            String varname1 = @"select a.department_id, a.QL, (a.KT + a.CD + a.HSTT) as Tong, a.KT, a.CD, a.HSTT, 
                                (a.vld + a.om + a.khac + a.phep) as vang, 
                                a.vld, a.om, a.phep, a.khac, 
                                (case when (a.KT+ a.CD + a.HSTT) = 0 then 0 else round(Convert(float,(a.KT + a.CD - a.tong_nghidai)-(a.vld + a.om + a.khac + a.phep))/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as tile, 
                                b.than, b.metlo, b.xen,b.diemluong,a.tong_nghidai,a.nghidai_om_tnld,a.nghidai_thld,a.nghidai_vld 
                                from 
                                (select a.department_id, a.QL, a.KT, a.CD, a.HSTT, 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vld', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'om', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'phep', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'khac', 
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Tạm hoãn lao động',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'tong_nghidai', 
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_vld', 
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_thld', 
                                SUM(case when d.LyDoVangMat in (N'Ốm dài', N'Tai nạn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_om_tnld' 
                                 from(select a.department_id, 
                                sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD, 
                                sum(case when ncv.LoaiNhomCongViec like '%HSTT%' then  1 else 0 end) as HSTT 
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id 
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                where a.department_type like N'%chính%' and a.department_id != 'PXST' and a.department_id != 'PXLT' 
                                group by a.department_id) 
                                 as a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan left outer join DiemDanh_NangSuatLaoDong d 
                                on h.HeaderID = d.HeaderID 
                                group by a.department_id, a.QL, a.KT, a.CD,a.HSTT) as a inner join 
                                ( select a.department_id, 
                                sum(case when h.ThanThucHien is not null and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then h.ThanThucHien else 0 end) as 'than', 
                                sum(case when h.MetLoThucHien is not null and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then h.MetLoThucHien else 0 end) as 'metlo', 
                                sum(case when h.XenThucHien is not null and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then h.XenThucHien else 0 end) as 'xen', 
                                sum(case when h.TotalEffort is not null and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then h.TotalEffort else 0 end) as 'diemluong' 
                                from Department a left outer join Header_DiemDanh_NangSuat_LaoDong h 
                                on a.department_id = h.MaPhongBan 
                                group by a.department_id 
                                ) as b on a.department_id = b.department_id";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                List<BaoCaoNgayDB> all = db.Database.SqlQuery<BaoCaoNgayDB>(varname1,
                    new SqlParameter("month", month),
                    new SqlParameter("year", year)).ToList();
                int thisMonth = DateTime.Today.Month;
                if (!(thisMonth + "").Equals(month))
                {
                    ViewBag.subTable = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month)) + "/" + month;
                }
                else
                {
                    ViewBag.subTable = DateTime.Today.ToString("dd/MM");
                }
                ViewBag.sumLD = 0;
                ViewBag.sumKT = 0;
                ViewBag.sumCD = 0;
                ViewBag.sumHSTT = 0;
                ViewBag.sumOmDai = 0;
                ViewBag.daiVLD = 0;
                ViewBag.thamGia = 0;
                ViewBag.diLam = 0;
                ViewBag.koDiLam = 0;
                ViewBag.rate = 0;
                double rate = 0;
                foreach (var item in all)
                {
                    item.tong_nghidai = item.nghidai_vld + item.nghidai_thld + item.nghidai_om;
                    item.tong_tru_nghidai = item.Tong - item.tong_nghidai;
                    item.dilam = Convert.ToInt32(item.tong_tru_nghidai) - Convert.ToInt32(item.vang);
                    ViewBag.sumLD += item.Tong;
                    ViewBag.sumKT += item.KT;
                    ViewBag.sumCD += item.CD;
                    ViewBag.sumHSTT += item.HSTT;
                    ViewBag.sumOmDai += item.nghidai_om;
                    ViewBag.daiVLD += item.nghidai_vld;
                    ViewBag.thamGia += item.Tong;
                    ViewBag.diLam += item.dilam;
                    ViewBag.koDiLam += item.Tong - item.dilam;
                    rate += item.tong_tru_nghidai != 0 ? (double)item.dilam / item.tong_tru_nghidai * 100 : 0;
                    if (item.tong_tru_nghidai < 0) item.tong_tru_nghidai = 0;
                }
                ViewBag.rate = Math.Round(rate / all.Count(), 2);
                ViewBag.month = month;
                ViewBag.year = year;
                ViewBag.TatCaDonVi = all;
            }
            return View("/Views/TCLD/Report/Monthly.cshtml");
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
            string query = @"";
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
        public double TyLe { get; set; }
        public double TongSoDiem { get; set; }
        public double TongSoThan { get; set; }
        public double TongSoMetLo { get; set; }
        public double TongSoXen { get; set; }

        public int CBQL { get; set; }
        public int KT { get; set; }
        public int CD { get; set; }
        public int HSTT { get; set; }
        public int TongLaoDong { get; set; }
        public int LDTheoDS { get; set; }
        public int LDSX { get; set; }
        public int Om { get; set; }
        public int VLD { get; set; }
        public int Khac { get; set; }
        public int TongNghi { get; set; }
    }

    public class Vang
    {
        public string Name { get; set; }
        public string MaNV { get; set; }
        public string ChucVu { get; set; }
        public string LyDo { get; set; }
    }
}
