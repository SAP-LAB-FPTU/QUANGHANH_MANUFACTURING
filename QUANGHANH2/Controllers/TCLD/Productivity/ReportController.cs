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

        //[Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-ngay")]
        //public ActionResult Daily(string date, string donvi)
        //{
        //    if (date == null)
        //    {
        //        date = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
        //    }
        //    if (donvi == null)
        //    {
        //        donvi = "DL1";
        //    }
        //    var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    string headerca1 = getHeader(date, donvi, "1");
        //    string bodyca1 = Wherecondition(date, donvi, "1");
        //    string headerca2 = getHeader(date, donvi, "2");
        //    string bodyca2 = Wherecondition(date, donvi, "2");
        //    string headerca3 = getHeader(date, donvi, "3");
        //    string bodyca3 = Wherecondition(date, donvi, "3");
        //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //    {
        //        ViewBag.TenToChuc = db.Departments.ToList();
        //        ViewBag.HeaderCa1 = db.Database.SqlQuery<Ngay>(headerca1).ToList().First();
        //        ViewBag.Ca1 = db.Database.SqlQuery<Ngay>(bodyca1).ToList();
        //        Header_DiemDanh_NangSuat_LaoDong header1 = db.Header_DiemDanh_NangSuat_LaoDong.Find(1, donvi, ngay);
        //        ViewBag.Ca1Vang = db.DiemDanh_NangSuatLaoDong
        //            .Where(a => a.LyDoVangMat != null)
        //            .Where(a => a.HeaderID == header1.HeaderID)
        //            .ToList();
        //        string mnv = "";
        //        List<Vang> lists = new List<Vang>();
        //        for (int i = 0; i < ViewBag.HeaderCa1.TongNghi; i++)
        //        {
        //            mnv = ViewBag.Ca1Vang[i].MaNV;
        //            Vang v = new Vang
        //            {
        //                Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
        //                MaNV = ViewBag.Ca1Vang[i].MaNV,
        //                //ChucVu = db.NhanViens.Where(a =>a.MaNV == mnv).ToList().First().LoaiNhanVien,
        //                LyDo = ViewBag.Ca1Vang[i].LyDoVangMat,
        //            };
        //            lists.Add(v);
        //        }
        //        ViewBag.Ca1Vang = lists;
        //        ViewBag.HeaderCa2 = db.Database.SqlQuery<Ngay>(headerca2).ToList().First();
        //        ViewBag.Ca2 = db.Database.SqlQuery<Ngay>(bodyca2).ToList();
        //        Header_DiemDanh_NangSuat_LaoDong header2 = db.Header_DiemDanh_NangSuat_LaoDong.Find(2, donvi, ngay);
        //        ViewBag.Ca2Vang = db.DiemDanh_NangSuatLaoDong
        //           .Where(a => a.LyDoVangMat != null)
        //           .Where(a => a.HeaderID == header2.HeaderID)
        //           .ToList();
        //        List<Vang> lists2 = new List<Vang>();
        //        for (int i = 0; i < ViewBag.HeaderCa2.TongNghi; i++)
        //        {
        //            mnv = ViewBag.Ca2Vang[i].MaNV;
        //            Vang v = new Vang
        //            {
        //                Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
        //                MaNV = ViewBag.Ca2Vang[i].MaNV,
        //                //ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
        //                LyDo = ViewBag.Ca2Vang[i].LyDoVangMat,
        //            };
        //            lists2.Add(v);
        //        }
        //        ViewBag.Ca2Vang = lists2;
        //        ViewBag.HeaderCa3 = db.Database.SqlQuery<Ngay>(headerca3).ToList().First();
        //        ViewBag.Ca3 = db.Database.SqlQuery<Ngay>(bodyca3).ToList();
        //        Header_DiemDanh_NangSuat_LaoDong header3 = db.Header_DiemDanh_NangSuat_LaoDong.Find(3, donvi, ngay);
        //        ViewBag.Ca3Vang = db.DiemDanh_NangSuatLaoDong
        //            .Where(a => a.LyDoVangMat != null)
        //            .Where(a => a.HeaderID == header3.HeaderID)
        //            .ToList();
        //        List<Vang> lists3 = new List<Vang>();
        //        for (int i = 0; i < ViewBag.HeaderCa3.TongNghi; i++)
        //        {
        //            mnv = ViewBag.Ca3Vang[i].MaNV;
        //            Vang v = new Vang
        //            {
        //                Name = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().Ten,
        //                MaNV = ViewBag.Ca3Vang[i].MaNV,
        //                //ChucVu = db.NhanViens.Where(a => a.MaNV == mnv).ToList().First().LoaiNhanVien,
        //                LyDo = ViewBag.Ca3Vang[i].LyDoVangMat,
        //            };
        //            lists3.Add(v);
        //        }
        //        ViewBag.Ca3Vang = lists3;
        //        ViewBag.Tong = new Ngay
        //        {
        //            LoaiNhanVien = "Tổng",
        //            LDTheoDS = ViewBag.HeaderCa1.LDTheoDS + ViewBag.HeaderCa2.LDTheoDS + ViewBag.HeaderCa3.LDTheoDS,
        //            LDSX = ViewBag.HeaderCa1.LDSX + ViewBag.HeaderCa2.LDSX + ViewBag.HeaderCa3.LDSX,
        //            Phep = ViewBag.HeaderCa1.Phep + ViewBag.HeaderCa2.Phep + ViewBag.HeaderCa3.Phep,
        //            Om = ViewBag.HeaderCa1.Om + ViewBag.HeaderCa2.Om + ViewBag.HeaderCa3.Om,
        //            Bu = ViewBag.HeaderCa1.Bu + ViewBag.HeaderCa2.Bu + ViewBag.HeaderCa3.Bu,
        //            TT = ViewBag.HeaderCa1.TT + ViewBag.HeaderCa2.TT + ViewBag.HeaderCa3.TT,
        //            VLD = ViewBag.HeaderCa1.VLD + ViewBag.HeaderCa2.VLD + ViewBag.HeaderCa3.VLD,
        //            H = ViewBag.HeaderCa1.H + ViewBag.HeaderCa2.H + ViewBag.HeaderCa3.H,
        //            TongNghi = ViewBag.HeaderCa1.TongNghi + ViewBag.HeaderCa2.TongNghi + ViewBag.HeaderCa3.TongNghi,
        //        };
        //        ViewBag.TongDetail = new ArrayList();
        //        for (int i = 0; i < ViewBag.Ca1.Count; i++)
        //        {
        //            ViewBag.TongDetail.Add(new Ngay
        //            {
        //                LoaiNhanVien = ViewBag.Ca1[i].LoaiNhanVien,
        //                LDTheoDS = ViewBag.Ca1[i].LDTheoDS + ViewBag.Ca2[i].LDTheoDS + ViewBag.Ca3[i].LDTheoDS,
        //                LDSX = ViewBag.Ca1[i].LDSX + ViewBag.Ca2[i].LDSX + ViewBag.Ca3[i].LDSX
        //            });
        //        }
        //    }
        //    return View("/Views/TCLD/Report/Daily.cshtml");
        //}

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
            String varname1 = @"select a.department_id, a.QL, (a.KT + a.CD) as 'Tong', a.KT, a.CD, 0 as 'HSTT',
                                a.dilam, 
                                (a.vld + a.om + a.khac + a.phep) as 'vang',
                                a.vld ,a.om ,a.phep ,a.khac,
                                (case when (a.KT+ a.CD) = 0 then 0 else round(Convert(float, a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as 'tile',
                                b.than, b.metlo, b.xen,b.diemluong,
                                (case when a.dilam = 0 then 0 else round(Convert(float,(b.diemluong / a.dilam)),1) end) as 'tlbq_diemluong',
								(case when a.dilam = 0 then 0 else round(Convert(float,(b.than / a.dilam)),1) end) as 'nsld_thuchien',
								(case when a.dilam = 0 then 0 else round(Convert(float,0),1) end) as 'nsld_kehoach',
                                a.tong_nghidai,a.nghidai_om_tnld,a.nghidai_thhd,a.nghidai_vld
                                from
                                (select a.department_id, a.QL, a.KT, a.CD,
                                sum(case when d.DiLam = 1 and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'dilam',  
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'vld',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'om',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'phep',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'khac',
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Tạm hoãn lao động',N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'tong_nghidai',
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_vld',
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_thhd',
                                SUM(case when d.LyDoVangMat in (N'Ốm dài', N'Tai nạn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_om_tnld'
                                 from(select a.department_id,
                                sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL,
                                sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT,
                                sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec
                                where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%')
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
                Footer_SUM tatca = new Footer_SUM();

                foreach (var item in all)
                {
                    item.tong_ldtt_sau_tru_dai = item.Tong - item.tong_nghidai;
                    if (item.tong_ldtt_sau_tru_dai < 0) item.tong_ldtt_sau_tru_dai = 0;
                    item.tile = Math.Round(item.Tong != 0 ? (double)item.dilam / item.Tong * 100 : 0, 2);

                    tatca.tong_ldtt_theo_ds += item.Tong;
                    tatca.cbql += item.QL;
                    tatca.kt += item.KT;
                    tatca.cd += item.CD;
                    tatca.hstt += item.HSTT;
                    tatca.tong_ldtt_nghi_dai += item.tong_nghidai;
                    tatca.vld_dai += item.nghidai_vld;
                    tatca.om_tnld_dai += item.nghidai_om_tnld;
                    tatca.tong_ldtt_sau_tru_dai += item.tong_ldtt_sau_tru_dai;
                    tatca.ldbq_di_lam += item.dilam;
                    tatca.tongso_ld_vang += item.vang;
                    tatca.tyle_huydong += item.tile;
                }
                tatca.tyle_huydong = Math.Round(((double)tatca.tyle_huydong / all.Count), 2);
                ViewBag.TatCaDonVi = all;
                ViewBag.TatCaDonViFooter = tatca;


            }
            return View("/Views/TCLD/Report/DailyAll.cshtml");
        }

        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-ngay/excel")]
        public void ReturnExcel_Day(string date)
        {
            string path = HostingEnvironment.MapPath("/excel/TCLD/Report/Báo cáo năng suất lao động và tiền lương theo các phân xưởng theo ngày.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                DateTime dateTime = date == null ? DateTime.Now : DateTime.ParseExact(date, "dd/MM/yyyy", null);
                string tatcadonvi = @"select a.department_id, a.QL, (a.KT + a.CD) as 'Tong', a.KT, a.CD, 0 as 'HSTT',
                                        a.dilam, 
                                        (a.vld + a.om + a.khac + a.phep) as 'vang',
                                        a.vld ,a.om ,a.phep ,a.khac,
                                        (case when (a.KT+ a.CD) = 0 then 0 else round(Convert(float, a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as 'tile',
                                        b.than, b.metlo, b.xen,b.diemluong,
                                        (case when a.dilam = 0 then 0 else round(Convert(float,(b.diemluong / a.dilam)),1) end) as 'tlbq_diemluong',
								        (case when a.dilam = 0 then 0 else round(Convert(float,(b.than / a.dilam)),1) end) as 'nsld_thuchien',
								        (case when a.dilam = 0 then 0 else round(Convert(float,0),1) end) as 'nsld_kehoach',
                                        a.tong_nghidai,a.nghidai_om_tnld,a.nghidai_thhd,a.nghidai_vld
                                        from
                                        (select a.department_id, a.QL, a.KT, a.CD, 
                                        sum(case when d.DiLam = 1 and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'dilam', 
                                        sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'vld',
                                        sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'om',
                                        sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'phep',
                                        sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'khac',
                                        SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Tạm hoãn lao động',N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'tong_nghidai',
                                        SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_vld',
                                        SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_thhd',
                                        SUM(case when d.LyDoVangMat in (N'Ốm dài', N'Tai nạn lao động') and h.NgayDiemDanh = @NgayDiemDanh then 1 else 0 end) as 'nghidai_om_tnld'
                                         from(select a.department_id,
                                        sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL,
                                        sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT,
                                        sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD
                                        from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id
                                        join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
                                        join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec
                                        where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%')
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
                    ViewBag.TatCaDonVi = db.Database.SqlQuery<BaoCaoNgayDB>(tatcadonvi, new SqlParameter("NgayDiemDanh", dateTime)).ToList();

                    //LDTT theo DS
                    int cbql = 0;
                    int kt = 0;
                    int cd = 0;
                    int hstt = 0;
                    int tong_ldtt_theo_ds = 0;

                    //LDTT nghi dai
                    int vld_dai = 0;
                    int thhd = 0;
                    int om_tnld_dai = 0;
                    int tong_ldtt_nghi_dai = 0;

                    //Tong LDTT Sau Tru Nghi Dai
                    int tong_ldtt_sau_tru_dai = 0;

                    //LD thuc hien BQ
                    int ldbq_di_lam = 0;

                    //LD Vang
                    int vld_ngan = 0;
                    int om_ngan = 0;
                    int phep_ngan = 0;
                    int khac_ngan = 0;
                    int tongso_ld_vang = 0;

                    //Ty le huy dong
                    double tyle_huydong = 0;

                    //San luong th
                    double than = 0;
                    double metlo = 0;
                    double xen = 0;

                    //DiemLuong
                    double tongso_diemluong = 0;
                    double tlbq_diemluong = 0;

                    //NSLD
                    double nsld_thuchien = 0;
                    double nsld_kehoach = 0;

                    foreach (var item in ViewBag.TatCaDonVi)
                    {
                        cbql += item.QL;
                        kt += item.KT;
                        cd += item.CD;
                        hstt += item.HSTT;
                        tong_ldtt_theo_ds += item.Tong;

                        vld_dai += item.nghidai_vld;
                        thhd += item.nghidai_thhd;
                        om_tnld_dai += item.nghidai_om_tnld;
                        tong_ldtt_nghi_dai += item.tong_nghidai;

                        tong_ldtt_sau_tru_dai += item.tong_ldtt_sau_tru_dai;

                        ldbq_di_lam += item.dilam;

                        vld_ngan += item.vld;
                        om_ngan += item.om;
                        phep_ngan += item.phep;
                        khac_ngan += item.khac;
                        tongso_ld_vang += item.vang;

                        tyle_huydong += item.tile;

                        than += item.than;
                        metlo += item.metlo;
                        xen += item.xen;

                        tongso_diemluong += item.diemluong;
                        tlbq_diemluong += item.tlbq_diemluong;

                        nsld_thuchien += item.nsld_thuchien;
                        nsld_kehoach += item.nsld_kehoach;
                    };
                    if (ViewBag.TatCaDonVi.Count > 0)
                    {
                        tyle_huydong = Math.Round(tyle_huydong / ViewBag.TatCaDonVi.Count, 2);
                    };

                    //FOOTER
                    ViewBag.TatCaDonViFooter = new Footer_SUM
                    {
                        cbql = cbql,
                        kt = kt,
                        cd = cd,
                        hstt = hstt,
                        tong_ldtt_theo_ds = tong_ldtt_theo_ds,

                        vld_dai = vld_dai,
                        thhd = thhd,
                        om_tnld_dai = om_tnld_dai,
                        tong_ldtt_nghi_dai = tong_ldtt_nghi_dai,

                        tong_ldtt_sau_tru_dai = tong_ldtt_sau_tru_dai,

                        ldbq_di_lam = ldbq_di_lam,

                        vld_ngan = vld_ngan,
                        om_ngan = om_ngan,
                        phep_ngan = phep_ngan,
                        khac_ngan = khac_ngan,
                        tongso_ld_vang = tongso_ld_vang,

                        tyle_huydong = tyle_huydong,
                        than = than,
                        metlo = metlo,
                        xen = xen,

                        tongso_diemluong = tongso_diemluong,
                        tlbq_diemluong = tlbq_diemluong,

                        nsld_thuchien = nsld_thuchien,
                        nsld_kehoach = nsld_kehoach
                    };

                    //HEADER EXCEL
                    excelWorksheet.Cells[1, 1].Value = "BÁO CÁO THỰC HIỆN LAO ĐỘNG, TIỀN LƯƠNG CÔNG NHÂN TRỰC TIẾP NGÀY " + date;

                    int k = 8;
                    int stt = 1;
                    for (int i = 0; i < ViewBag.TatCaDonVi.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = stt.ToString();
                        excelWorksheet.Cells[k, 2].Value = ViewBag.TatCaDonVi[i].department_id;
                        excelWorksheet.Cells[k, 3].Value = ViewBag.TatCaDonVi[i].QL;
                        excelWorksheet.Cells[k, 4].Value = ViewBag.TatCaDonVi[i].Tong;
                        excelWorksheet.Cells[k, 5].Value = ViewBag.TatCaDonVi[i].KT;
                        excelWorksheet.Cells[k, 6].Value = ViewBag.TatCaDonVi[i].CD;
                        excelWorksheet.Cells[k, 7].Value = ViewBag.TatCaDonVi[i].HSTT;
                        excelWorksheet.Cells[k, 8].Value = ViewBag.TatCaDonVi[i].tong_nghidai;
                        excelWorksheet.Cells[k, 9].Value = ViewBag.TatCaDonVi[i].nghidai_vld;
                        excelWorksheet.Cells[k, 10].Value = ViewBag.TatCaDonVi[i].nghidai_thhd;
                        excelWorksheet.Cells[k, 11].Value = ViewBag.TatCaDonVi[i].nghidai_om_tnld;
                        excelWorksheet.Cells[k, 12].Value = (ViewBag.TatCaDonVi[i].Tong - ViewBag.TatCaDonVi[i].tong_nghidai);
                        excelWorksheet.Cells[k, 13].Value = ViewBag.TatCaDonVi[i].dilam;
                        excelWorksheet.Cells[k, 14].Value = ViewBag.TatCaDonVi[i].vang;
                        excelWorksheet.Cells[k, 15].Value = ViewBag.TatCaDonVi[i].vld;
                        excelWorksheet.Cells[k, 16].Value = ViewBag.TatCaDonVi[i].om;
                        excelWorksheet.Cells[k, 17].Value = ViewBag.TatCaDonVi[i].phep;
                        excelWorksheet.Cells[k, 18].Value = ViewBag.TatCaDonVi[i].khac;
                        excelWorksheet.Cells[k, 19].Value = ViewBag.TatCaDonVi[i].tile;
                        excelWorksheet.Cells[k, 20].Value = ViewBag.TatCaDonVi[i].than;
                        excelWorksheet.Cells[k, 21].Value = ViewBag.TatCaDonVi[i].metlo;
                        excelWorksheet.Cells[k, 22].Value = ViewBag.TatCaDonVi[i].xen;
                        excelWorksheet.Cells[k, 23].Value = ViewBag.TatCaDonVi[i].diemluong;
                        excelWorksheet.Cells[k, 24].Value = ViewBag.TatCaDonVi[i].tlbq_diemluong;
                        excelWorksheet.Cells[k, 25].Value = ViewBag.TatCaDonVi[i].nsld_thuchien;
                        excelWorksheet.Cells[k, 26].Value = ViewBag.TatCaDonVi[i].nsld_kehoach;
                        k++;
                        stt++;
                    }
                    excelWorksheet.Cells[k, 1, k, 27].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 2].Value = "TỔNG";
                    excelWorksheet.Cells[k, 3].Value = ViewBag.TatCaDonViFooter.cbql;
                    excelWorksheet.Cells[k, 4].Value = ViewBag.TatCaDonViFooter.tong_ldtt_theo_ds;
                    excelWorksheet.Cells[k, 5].Value = ViewBag.TatCaDonViFooter.kt;
                    excelWorksheet.Cells[k, 6].Value = ViewBag.TatCaDonViFooter.cd;
                    excelWorksheet.Cells[k, 7].Value = ViewBag.TatCaDonViFooter.hstt;
                    excelWorksheet.Cells[k, 8].Value = ViewBag.TatCaDonViFooter.tong_ldtt_nghi_dai;
                    excelWorksheet.Cells[k, 9].Value = ViewBag.TatCaDonViFooter.vld_dai;
                    excelWorksheet.Cells[k, 10].Value = ViewBag.TatCaDonViFooter.thhd;
                    excelWorksheet.Cells[k, 11].Value = ViewBag.TatCaDonViFooter.om_tnld_dai;
                    excelWorksheet.Cells[k, 12].Value = (ViewBag.TatCaDonViFooter.tong_ldtt_theo_ds - ViewBag.TatCaDonViFooter.tong_ldtt_nghi_dai);
                    excelWorksheet.Cells[k, 13].Value = (ViewBag.TatCaDonViFooter.tong_ldtt_theo_ds - ViewBag.TatCaDonViFooter.tong_ldtt_nghi_dai - ViewBag.TatCaDonViFooter.tongso_ld_vang);
                    excelWorksheet.Cells[k, 14].Value = ViewBag.TatCaDonViFooter.tongso_ld_vang;
                    excelWorksheet.Cells[k, 15].Value = ViewBag.TatCaDonViFooter.vld_ngan;
                    excelWorksheet.Cells[k, 16].Value = ViewBag.TatCaDonViFooter.om_ngan;
                    excelWorksheet.Cells[k, 17].Value = ViewBag.TatCaDonViFooter.phep_ngan;
                    excelWorksheet.Cells[k, 18].Value = ViewBag.TatCaDonViFooter.khac_ngan;
                    excelWorksheet.Cells[k, 19].Value = ViewBag.TatCaDonViFooter.tyle_huydong;
                    excelWorksheet.Cells[k, 20].Value = ViewBag.TatCaDonViFooter.than;
                    excelWorksheet.Cells[k, 21].Value = ViewBag.TatCaDonViFooter.metlo;
                    excelWorksheet.Cells[k, 22].Value = ViewBag.TatCaDonViFooter.xen;
                    excelWorksheet.Cells[k, 23].Value = ViewBag.TatCaDonViFooter.tongso_diemluong;
                    excelWorksheet.Cells[k, 24].Value = ViewBag.TatCaDonViFooter.tlbq_diemluong;
                    excelWorksheet.Cells[k, 25].Value = ViewBag.TatCaDonViFooter.nsld_thuchien;
                    excelWorksheet.Cells[k, 26].Value = ViewBag.TatCaDonViFooter.nsld_kehoach;
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
            String varname1 = @"select a.department_id, a.QL, (a.KT + a.CD + a.HSTT) as 'Tong', 
                                a.KT, a.CD, a.HSTT,
                                a.tong_nghidai,a.nghidai_vld,a.nghidai_thhd,a.nghidai_om_tnld,
                                ((a.KT + a.CD + a.HSTT)-a.tong_nghidai) as 'tong_ldtt_sau_tru_dai',
                                a.dilam,
                                (a.vld + a.om + a.khac + a.phep) as vang, 
                                a.vld, a.om, a.phep, a.khac,
                                (case when (a.KT+ a.CD + a.HSTT) = 0 then 0 
                                else round(Convert(float,a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as 'tile', 
                                b.than, b.metlo, b.xen,b.diemluong,
                                (case when a.dilam = 0 then 0 else round(Convert(float,(b.diemluong / a.dilam)),1) end) as 'tlbq_diemluong',
								(case when a.dilam = 0 then 0 else round(Convert(float,(b.than / a.dilam)),1) end) as 'nsld_thuchien',
								(case when a.dilam = 0 then 0 else round(Convert(float,0),1) end) as 'nsld_kehoach'
                                from 
                                (select a.department_id, a.QL, a.KT, a.CD, a.HSTT,
                                sum(case when d.DiLam = 1 and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) / day(eomonth(@year + '-' + @month + '-' + '01')) as 'dilam',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vld', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'om', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'phep', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'khac', 
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Tạm hoãn lao động',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'tong_nghidai', 
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_vld', 
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_thhd', 
                                SUM(case when d.LyDoVangMat in (N'Ốm dài', N'Tai nạn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_om_tnld' 
                                 from(select a.department_id, 
                                sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD, 
                                sum(case when ncv.LoaiNhomCongViec like '%HSTT%' then  1 else 0 end) as HSTT 
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id 
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%') 
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
                    item.tong_nghidai = item.nghidai_vld + item.nghidai_thhd + item.nghidai_om_tnld;
                    item.tong_ldtt_sau_tru_dai = item.Tong - item.tong_nghidai;
                    ViewBag.sumLD += item.Tong;
                    ViewBag.sumKT += item.KT;
                    ViewBag.sumCD += item.CD;
                    ViewBag.sumHSTT += item.HSTT;
                    ViewBag.sumOmDai += item.nghidai_om_tnld;
                    ViewBag.daiVLD += item.nghidai_vld;
                    ViewBag.thamGia += item.Tong;
                    ViewBag.diLam += item.dilam;
                    ViewBag.koDiLam += item.vang;
                    rate += item.tong_ldtt_sau_tru_dai != 0 ? (double)item.dilam / item.tong_ldtt_sau_tru_dai * 100 : 0;
                    if (item.tong_ldtt_sau_tru_dai < 0) item.tong_ldtt_sau_tru_dai = 0;
                }
                ViewBag.rate = Math.Round(rate / all.Count(), 2);
                ViewBag.month = month;
                ViewBag.year = year;
                ViewBag.TatCaDonVi = all;
            }
            return View("/Views/TCLD/Report/Monthly.cshtml");
        }

        [Route("phong-tcld/nang-suat-lao-dong-va-tien-luong/nang-suat-lao-dong-va-tien-luong-theo-cac-px-trong-thang/excel")]
        public void ReturnExcel_Month(string month, string year)
        {
            try
            {
                string path = HostingEnvironment.MapPath("/excel/TCLD/Report/Báo cáo năng suất lao động và tiền lương theo các phân xưởng theo tháng.xlsx");
                FileInfo file = new FileInfo(path);
                using (ExcelPackage excelPackage = new ExcelPackage(file))
                {
                    ExcelWorkbook excelWorkbook_Month = excelPackage.Workbook;
                    ExcelWorksheet excelWorksheet_Month = excelWorkbook_Month.Worksheets.First();
                    //int month = thang == null ? DateTime.Now.Month : Convert.ToInt32(thang);
                    //int year = nam == null ? DateTime.Now.Year : Convert.ToInt32(nam);
                    var sqlMonth = @"select a.department_id, a.QL, (a.KT + a.CD + a.HSTT) as 'Tong', 
                                a.KT, a.CD, a.HSTT,
                                a.tong_nghidai,a.nghidai_vld,a.nghidai_thhd,a.nghidai_om_tnld,
                                ((a.KT + a.CD + a.HSTT)-a.tong_nghidai) as 'tong_ldtt_sau_tru_dai',
                                a.dilam,
                                (a.vld + a.om + a.khac + a.phep) as vang, 
                                a.vld, a.om, a.phep, a.khac,
                                (case when (a.KT+ a.CD + a.HSTT) = 0 then 0 
                                else round(Convert(float,a.dilam)/(a.KT + a.CD - a.tong_nghidai)*100,1) end) as 'tile', 
                                b.than, b.metlo, b.xen,b.diemluong,
                                (case when a.dilam = 0 then 0 else round(Convert(float,(b.diemluong / a.dilam)),1) end) as 'tlbq_diemluong',
								(case when a.dilam = 0 then 0 else round(Convert(float,(b.than / a.dilam)),1) end) as 'nsld_thuchien',
								(case when a.dilam = 0 then 0 else round(Convert(float,0),1) end) as 'nsld_kehoach'
                                from 
                                (select a.department_id, a.QL, a.KT, a.CD, a.HSTT,
                                sum(case when d.DiLam = 1 and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) / day(eomonth(@year + '-' + @month + '-' + '01')) as 'dilam',
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Vô lý do' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vld', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Ốm' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'om', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Nghỉ phép' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'phep', 
                                sum(case when d.DiLam = 0  and d.LyDoVangMat like N'Khác' and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'khac', 
                                SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Tạm hoãn lao động',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'tong_nghidai', 
                                SUM(case when d.LyDoVangMat in (N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_vld', 
                                SUM(case when d.LyDoVangMat in (N'Tạm hoãn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_thhd', 
                                SUM(case when d.LyDoVangMat in (N'Ốm dài', N'Tai nạn lao động') and MONTH(h.NgayDiemDanh) = @month AND YEAR(h.NgayDiemDanh) = @year then 1 else 0 end) as 'nghidai_om_tnld' 
                                 from(select a.department_id, 
                                sum(case when ncv.LoaiNhomCongViec = N'CBQL' then  1 else 0 end) as QL, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNKT' then  1 else 0 end) as KT, 
                                sum(case when ncv.LoaiNhomCongViec = N'CNCĐ' then  1 else 0 end) as CD, 
                                sum(case when ncv.LoaiNhomCongViec like '%HSTT%' then  1 else 0 end) as HSTT 
                                from Department a left outer join NhanVien n on n.MaPhongBan = a.department_id 
                                join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                where a.department_type like N'%chính%' and (a.department_id like N'%ĐL%' or a.department_id like N'%VTL%' or a.department_id like N'%KT%') 
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
                        List<BaoCaoNgayDB> listMonth = db.Database.SqlQuery<BaoCaoNgayDB>(sqlMonth,
                                                                                            new SqlParameter("month", month),
                                                                                            new SqlParameter("year", year)).ToList();
                        int cbql = 0;
                        int kt = 0;
                        int cd = 0;
                        int hstt = 0;
                        int tong_ldtt_theo_ds = 0;

                        //LDTT nghi dai
                        int vld_dai = 0;
                        int thhd = 0;
                        int om_tnld_dai = 0;
                        int tong_ldtt_nghi_dai = 0;

                        //Tong LDTT Sau Tru Nghi Dai
                        int tong_ldtt_sau_tru_dai = 0;

                        //LD thuc hien BQ
                        int ldbq_di_lam = 0;

                        //LD Vang
                        int vld_ngan = 0;
                        int om_ngan = 0;
                        int phep_ngan = 0;
                        int khac_ngan = 0;
                        int tongso_ld_vang = 0;

                        //Ty le huy dong
                        double tyle_huydong = 0;

                        //San luong th
                        double than = 0;
                        double metlo = 0;
                        double xen = 0;

                        //DiemLuong
                        double tongso_diemluong = 0;
                        double tlbq_diemluong = 0;

                        //NSLD
                        double nsld_thuchien = 0;
                        double nsld_kehoach = 0;

                        foreach (var item in listMonth)
                        {
                            cbql += item.QL;
                            kt += item.KT;
                            cd += item.CD;
                            hstt += item.HSTT;
                            tong_ldtt_theo_ds += item.Tong;

                            vld_dai += item.nghidai_vld;
                            thhd += item.nghidai_thhd;
                            om_tnld_dai += item.nghidai_om_tnld;
                            tong_ldtt_nghi_dai += item.tong_nghidai;

                            tong_ldtt_sau_tru_dai += item.tong_ldtt_sau_tru_dai;

                            ldbq_di_lam += item.dilam;

                            vld_ngan += item.vld;
                            om_ngan += item.om;
                            phep_ngan += item.phep;
                            khac_ngan += item.khac;
                            tongso_ld_vang += item.vang;

                            tyle_huydong += item.tile;

                            than += item.than;
                            metlo += item.metlo;
                            xen += item.xen;

                            tongso_diemluong += item.diemluong;
                            tlbq_diemluong += item.tlbq_diemluong;

                            nsld_thuchien += item.nsld_thuchien;
                            nsld_kehoach += item.nsld_kehoach;
                        };
                        if (listMonth.Count > 0)
                        {
                            tyle_huydong = Math.Round(tyle_huydong / listMonth.Count, 2);
                        };

                        //FOOTER
                        Footer_SUM listMonth_footer = new Footer_SUM()
                        {
                            cbql = cbql,
                            kt = kt,
                            cd = cd,
                            hstt = hstt,
                            tong_ldtt_theo_ds = tong_ldtt_theo_ds,

                            vld_dai = vld_dai,
                            thhd = thhd,
                            om_tnld_dai = om_tnld_dai,
                            tong_ldtt_nghi_dai = tong_ldtt_nghi_dai,

                            tong_ldtt_sau_tru_dai = tong_ldtt_sau_tru_dai,

                            ldbq_di_lam = ldbq_di_lam,

                            vld_ngan = vld_ngan,
                            om_ngan = om_ngan,
                            phep_ngan = phep_ngan,
                            khac_ngan = khac_ngan,
                            tongso_ld_vang = tongso_ld_vang,

                            tyle_huydong = tyle_huydong,
                            than = than,
                            metlo = metlo,
                            xen = xen,

                            tongso_diemluong = tongso_diemluong,
                            tlbq_diemluong = tlbq_diemluong,
                            nsld_thuchien = nsld_thuchien,
                            nsld_kehoach = nsld_kehoach
                        };

                        excelWorksheet_Month.Cells[1, 1].Value = "BÁO CÁO THỰC HIỆN LAO ĐỘNG, TIỀN LƯƠNG CÔNG NHÂN TRỰC TIẾP THÁNG " + month + " NĂM " + year;

                        int k = 8;
                        int stt = 1;
                        for (int i = 0; i < listMonth.Count; i++)
                        {
                            excelWorksheet_Month.Cells[k, 1].Value = stt.ToString();
                            excelWorksheet_Month.Cells[k, 2].Value = listMonth[i].department_id;
                            excelWorksheet_Month.Cells[k, 3].Value = listMonth[i].QL;
                            excelWorksheet_Month.Cells[k, 4].Value = listMonth[i].Tong;
                            excelWorksheet_Month.Cells[k, 5].Value = listMonth[i].KT;
                            excelWorksheet_Month.Cells[k, 6].Value = listMonth[i].CD;
                            excelWorksheet_Month.Cells[k, 7].Value = listMonth[i].HSTT;
                            excelWorksheet_Month.Cells[k, 8].Value = listMonth[i].tong_nghidai;
                            excelWorksheet_Month.Cells[k, 9].Value = listMonth[i].nghidai_vld;
                            excelWorksheet_Month.Cells[k, 10].Value = listMonth[i].nghidai_thhd;
                            excelWorksheet_Month.Cells[k, 11].Value = listMonth[i].nghidai_om_tnld;
                            excelWorksheet_Month.Cells[k, 12].Value = listMonth[i].tong_ldtt_sau_tru_dai;
                            excelWorksheet_Month.Cells[k, 13].Value = listMonth[i].dilam;
                            excelWorksheet_Month.Cells[k, 14].Value = listMonth[i].vang;
                            excelWorksheet_Month.Cells[k, 15].Value = listMonth[i].vld;
                            excelWorksheet_Month.Cells[k, 16].Value = listMonth[i].om;
                            excelWorksheet_Month.Cells[k, 17].Value = listMonth[i].phep;
                            excelWorksheet_Month.Cells[k, 18].Value = listMonth[i].khac;
                            excelWorksheet_Month.Cells[k, 19].Value = listMonth[i].tile;
                            excelWorksheet_Month.Cells[k, 20].Value = listMonth[i].than;
                            excelWorksheet_Month.Cells[k, 21].Value = listMonth[i].metlo;
                            excelWorksheet_Month.Cells[k, 22].Value = listMonth[i].xen;
                            excelWorksheet_Month.Cells[k, 23].Value = listMonth[i].diemluong;
                            excelWorksheet_Month.Cells[k, 24].Value = listMonth[i].tlbq_diemluong;
                            excelWorksheet_Month.Cells[k, 25].Value = listMonth[i].nsld_thuchien;
                            excelWorksheet_Month.Cells[k, 26].Value = listMonth[i].nsld_kehoach;
                            k++;
                            stt++;
                        }
                        excelWorksheet_Month.Cells[k, 1, k, 27].Style.Font.Bold = true;
                        excelWorksheet_Month.Cells[k, 2].Value = "TỔNG";
                        excelWorksheet_Month.Cells[k, 3].Value = listMonth_footer.cbql;
                        excelWorksheet_Month.Cells[k, 4].Value = listMonth_footer.tong_ldtt_theo_ds;
                        excelWorksheet_Month.Cells[k, 5].Value = listMonth_footer.kt;
                        excelWorksheet_Month.Cells[k, 6].Value = listMonth_footer.cd;
                        excelWorksheet_Month.Cells[k, 7].Value = listMonth_footer.hstt;
                        excelWorksheet_Month.Cells[k, 8].Value = listMonth_footer.tong_ldtt_nghi_dai;
                        excelWorksheet_Month.Cells[k, 9].Value = listMonth_footer.vld_dai;
                        excelWorksheet_Month.Cells[k, 10].Value = listMonth_footer.thhd;
                        excelWorksheet_Month.Cells[k, 11].Value = listMonth_footer.om_tnld_dai;
                        excelWorksheet_Month.Cells[k, 12].Value = listMonth_footer.tong_ldtt_sau_tru_dai;
                        excelWorksheet_Month.Cells[k, 13].Value = listMonth_footer.ldbq_di_lam;
                        excelWorksheet_Month.Cells[k, 14].Value = listMonth_footer.tongso_ld_vang;
                        excelWorksheet_Month.Cells[k, 15].Value = listMonth_footer.vld_ngan;
                        excelWorksheet_Month.Cells[k, 16].Value = listMonth_footer.om_ngan;
                        excelWorksheet_Month.Cells[k, 17].Value = listMonth_footer.phep_ngan;
                        excelWorksheet_Month.Cells[k, 18].Value = listMonth_footer.khac_ngan;
                        excelWorksheet_Month.Cells[k, 19].Value = listMonth_footer.tyle_huydong;
                        excelWorksheet_Month.Cells[k, 20].Value = listMonth_footer.than;
                        excelWorksheet_Month.Cells[k, 21].Value = listMonth_footer.metlo;
                        excelWorksheet_Month.Cells[k, 22].Value = listMonth_footer.xen;
                        excelWorksheet_Month.Cells[k, 23].Value = listMonth_footer.tongso_diemluong;
                        excelWorksheet_Month.Cells[k, 24].Value = listMonth_footer.tlbq_diemluong;
                        excelWorksheet_Month.Cells[k, 25].Value = listMonth_footer.nsld_thuchien;
                        excelWorksheet_Month.Cells[k, 26].Value = listMonth_footer.nsld_kehoach;
                        string location = HostingEnvironment.MapPath("/excel/TCLD/download");
                        excelPackage.SaveAs(new FileInfo(location + "/Báo cáo năng suất lao động và tiền lương theo các phân xưởng theo tháng.xlsx"));
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        //private string Wherecondition(string date, string donvi, string ca)
        //{
        //    var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    string query = "select distinct NhanVien.LoaiNhanVien, ISNULL(b.LDTheoDS,0) as LDTheoDS, ISNULL(b.LĐSX,0) as LDSX, " +
        //        "ISNULL(b.Phep,0) as Phep, ISNULL(b.Om,0) as Om, ISNULL(b.Bu,0) as Bu, ISNULL(b.TT,0) as TT, " +
        //        "ISNULL(b.VLD,0) as VLD, ISNULL(b.H,0) as H, ISNULL(b.TongNghi,0) as TongNghi" +
        //        "from NhanVien  left join  (select *, (Phep+Om+Bu+TT+VLD+H)as " +
        //        "TongNghi from  (select  n.LoaiNhanVien, COUNT(d.CaDiemDanh) as LDTheoDS, " +
        //        "Sum(CASE WHEN LyDoVangMat is null THEN 1 ELSE 0 END)  as LĐSX, " +
        //        "Sum(CASE WHEN LyDoVangMat like N'Phép' THEN 1 ELSE 0 END) AS Phep , " +
        //        "Sum(CASE WHEN LyDoVangMat like N'Ốm' THEN 1 ELSE 0 END) AS Om , " +
        //        "Sum(CASE WHEN LyDoVangMat like N'Bù' THEN 1 ELSE 0 END) AS Bu , " +
        //        "Sum(CASE WHEN LyDoVangMat like N'TT' THEN 1 ELSE 0 END) AS TT , " +
        //        "Sum(CASE WHEN LyDoVangMat like N'VLD' THEN 1 ELSE 0 END) AS VLD , " +
        //        "Sum(CASE WHEN LyDoVangMat like N'H' THEN 1 ELSE 0 END) AS H" +
        //        "NhanVien n, DiemDanh_NangSuatLaoDong d, " +
        //        "Department de, Header_DiemDanh_NangSuat_LaoDong h " +
        //        "where n.MaNV = d.MaNV and de.department_id = h.MaPhongBan and d.HeaderID = h.HeaderID" +
        //        "h.Ca = " + ca + "  and h.NgayDiemDanh = '" + ngay + "' and h.MaPhongBan like " +
        //        "'" + donvi + "' group by   n.LoaiNhanVien) a) b on NhanVien.LoaiNhanVien= b.LoaiNhanVien   where NhanVien.LoaiNhanVien iS not NULL";
        //    return query;
        //}

        //private string getHeader(string date, string donvi, string ca)
        //{
        //    var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    string query = "select 'CA " + ca + "' as LoaiNhanVien, *, (Phep+Om+Bu+TT+VLD+H) as TongNghi " +
        //        "from (select  COUNT(d.CaDiemDanh) as LDTheoDS, Isnull( Sum(CASE WHEN LyDoVangMat " +
        //        "is null THEN 1 ELSE Null END),0)  as LDSX, Isnull( Sum(CASE WHEN LyDoVangMat " +
        //        "like N'Phép' THEN 1 ELSE 0 END),0) AS Phep , Isnull(Sum(CASE WHEN LyDoVangMat " +
        //        "like N'Ốm' THEN 1 ELSE 0 END),0) AS Om ,  Isnull(Sum(CASE WHEN LyDoVangMat " +
        //        "like N'Bù' THEN 1 ELSE 0 END),0) AS Bu ,Isnull(Sum(CASE WHEN LyDoVangMat " +
        //        "like N'TT' THEN 1 ELSE 0 END),0) AS TT , Isnull(Sum(CASE WHEN LyDoVangMat " +
        //        "like N'VLD' THEN 1 ELSE 0 END),0) AS VLD , Isnull(Sum(CASE WHEN LyDoVangMat " +
        //        "like N'H' THEN 1 ELSE 0 END),0) AS H" +
        //        "from  NhanVien n, DiemDanh_NangSuatLaoDong d,Department de where " +
        //        "n.MaNV = d.MaNV and de.department_id = d.MaDonVi and  CaDiemDanh = " + ca + "  and " +
        //        "NgayDiemDanh = '" + ngay + "' and department_id like '" + donvi + "' ) a";

        //    return query;
        //}
    }
    //public class Ngay
    //{
    //    public string LoaiNhanVien { get; set; }
    //    public int LDTheoDS { get; set; }
    //    public int LDSX { get; set; }
    //    public int Phep { get; set; }
    //    public int Om { get; set; }
    //    public int Bu { get; set; }
    //    public int TT { get; set; }
    //    public int VLD { get; set; }
    //    public int H { get; set; }
    //    public int TongNghi { get; set; }
    //}

    public class Footer_SUM
    {
        public string donvi { get; set; }
        public int cbql { get; set; }
        public int kt { get; set; }
        public int cd { get; set; }
        public int hstt { get; set; }
        public int tong_ldtt_theo_ds { get; set; }
        public int vld_dai { get; set; }
        public int thhd { get; set; }
        public int om_tnld_dai { get; set; }
        public int tong_ldtt_nghi_dai { get; set; }
        public int tong_ldtt_sau_tru_dai { get; set; }
        public int ldbq_di_lam { get; set; }
        public int vld_ngan { get; set; }
        public int om_ngan { get; set; }
        public int phep_ngan { get; set; }
        public int khac_ngan { get; set; }
        public int tongso_ld_vang { get; set; }
        public double tyle_huydong { get; set; }
        public double than { get; set; }
        public double metlo { get; set; }
        public double xen { get; set; }
        public double tongso_diemluong { get; set; }
        public double tlbq_diemluong { get; set; }
        public double nsld_thuchien { get; set; }
        public double nsld_kehoach { get; set; }
    }

    public class Vang
    {
        public string Name { get; set; }
        public string MaNV { get; set; }
        public string ChucVu { get; set; }
        public string LyDo { get; set; }
    }
}
