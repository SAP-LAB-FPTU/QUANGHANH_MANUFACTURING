using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.DK.ReportHuman
{
    public class ReportHumanController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class report
        {
            //thong so chung
            public string MaPhongBan { get; set; }
            public int tong_tru_nghidai { get; set; }
            public int tong_DS { get; set; }
            public int QL_CTy { get; set; }
            public int tong_LDDS { get; set; }
            public int LDPX { get; set; }
            public int tong_nghidai { get; set; }
            //thong so tong 3 ca
            public int tong { get; set; }
            public int tong_LDTT { get; set; }
            public int tong_KT { get; set; }
            public int tong_CD { get; set; }
            public int tong_QL { get; set; }
            public int tong_vang { get; set; }
            public int tong_vld { get; set; }
            public int tong_om { get; set; }
            public int tong_p { get; set; }
            public int tong_khac { get; set; }
            public double tile { get; set; }
            //thong so ca 1
            public int tong1 { get; set; }
            public int LDTT1 { get; set; }
            public int KT1 { get; set; }
            public int CD1 { get; set; }
            public int QL1 { get; set; }
            public int vang1 { get; set; }
            public int vld1 { get; set; }
            public int om1 { get; set; }
            public int p1 { get; set; }
            public int khac1 { get; set; }
            //thong so ca 2
            public int tong2 { get; set; }
            public int LDTT2 { get; set; }
            public int KT2 { get; set; }
            public int CD2 { get; set; }
            public int QL2 { get; set; }
            public int vang2 { get; set; }
            public int vld2 { get; set; }
            public int om2 { get; set; }
            public int p2 { get; set; }
            public int khac2 { get; set; }
            //thong so ca 3
            public int tong3 { get; set; }
            public int LDTT3 { get; set; }
            public int KT3 { get; set; }
            public int CD3 { get; set; }
            public int QL3 { get; set; }
            public int vang3 { get; set; }
            public int vld3 { get; set; }
            public int om3 { get; set; }
            public int p3 { get; set; }
            public int khac3 { get; set; }

        }


        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-ngay")]
        [HttpGet]
        public ActionResult Daily()
        {
            DateTime date = DateTime.Today;
            string d = date.ToString("yyyy/MM/dd");
            string s = date.ToString("dd/MM/yyyy");
            ViewBag.dat = s;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            string sql = @"select a.MaPhongBan,a.KT1,a.CD1,a.QL1,b.om1,b.vld1,b.p1,b.khac1,a.KT2,a.CD2,a.QL2,b.om2,b.vld2,b.p2,b.khac2,a.KT3,a.CD3,a.QL3,b.om3,b.vld3,b.p3,b.khac3,b.tong_nghidai,a.tong_DS,a.QL_CTy,
                            (case when (a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) != 0 then cast(a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 as float) / cast((a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) as float) * 100 else 0 end) as 'tile'
                             from (select n.MaPhongBan, sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'KT1'
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'CD1'
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'QL1'
                               , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'KT2'
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'CD2'
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'QL2'
                               , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'KT3'
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'CD3'
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'QL3'
                               , count(n.MaNV) as 'tong_DS'
                               , sum(case when ncv.MaNhomCongViec = 10 then 1 else 0 end) as 'QL_CTy'
                             from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV
                             left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID
                             join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
                            join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec
                             where h.NgayDiemDanh = @day
                             group by n.MaPhongBan) a full join
	                            (select n.MaPhongBan, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'vld1'
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'om1'
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'p1'
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'khac1'
                               , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'vld2'
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'om2'
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'p2'
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'khac2'
                               , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'vld3'
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'om3'
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'p3'
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'khac3'
                               , SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') then 1 else 0 end) as 'tong_nghidai'
                             from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV
                             left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID
                             where h.NgayDiemDanh = @day
                             group by n.MaPhongBan) b on a.MaPhongBan = b.MaPhongBan";
            List<report> list = db.Database.SqlQuery<report>(sql, new SqlParameter("day", d)).ToList();
            foreach (var item in list)
            {

                //thong so ca 1
                item.LDTT1 = item.KT1 + item.CD1;
                item.tong1 = item.LDTT1 + item.QL1;
                item.vang1 = item.om1 + item.p1 + item.vld1 + item.khac1;
                //thong so ca 2
                item.LDTT2 = item.KT2 + item.CD2;
                item.tong2 = item.LDTT2 + item.QL2;
                item.vang2 = item.om2 + item.p2 + item.vld2 + item.khac2;
                //thong so ca 3
                item.LDTT3 = item.KT3 + item.CD3;
                item.tong3 = item.LDTT3 + item.QL3;
                item.vang3 = item.om3 + item.p3 + item.vld3 + item.khac3;
                //thong so tong
                item.tong_CD = item.CD1 + item.CD2 + item.CD3;
                item.tong_KT = item.KT1 + item.KT2 + item.KT3;
                item.tong_QL = item.QL1 + item.QL2 + item.QL3;
                item.tong_vld = item.vld1 + item.vld2 + item.vld3;
                item.tong_om = item.om1 + item.om2 + item.om3;
                item.tong_p = item.p1 + item.p2 + item.p3;
                item.tong_khac = item.khac1 + item.khac2 + item.khac3;
                item.tong_LDTT = item.tong_CD + item.tong_KT;
                item.tong = item.tong_LDTT + item.tong_QL;
                item.tong_vang = item.tong_vld + item.tong_om + item.tong_p + item.tong_khac + item.tong_nghidai;
                //thong so chung
                item.LDPX = item.tong + item.tong_vang;
                item.tong_tru_nghidai = item.tong_DS - item.tong_nghidai;
                //item.tong_LDTT = item.tong_tru_nghidai - item.QL_CTy;

            }
            ViewBag.list = list;
            return View("/Views/DK/ReportHuman/Daily.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-ngay")]
        [HttpPost]
        public ActionResult DailySearch(string d)
        {
            ViewBag.dat = d;
            string[] temp = d.Split('/');
            d = temp[2] + "-" + temp[1] + "-" + temp[0];
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            string sql = @"select a.MaPhongBan,a.KT1,a.CD1,a.QL1,b.om1,b.vld1,b.p1,b.khac1,a.KT2,a.CD2,a.QL2,b.om2,b.vld2,b.p2,b.khac2,a.KT3,a.CD3,a.QL3,b.om3,b.vld3,b.p3,b.khac3,b.tong_nghidai,a.tong_DS,a.QL_CTy, 
                            (case when (a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) != 0 then cast(a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 as float) / cast((a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) as float) * 100 else 0 end) as 'tile' 
                             from (select n.MaPhongBan, sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'KT1' 
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'CD1' 
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'QL1' 
                               , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'KT2' 
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'CD2' 
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'QL2' 
                               , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'KT3' 
                               , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'CD3' 
                               , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'QL3'
                               , count(n.MaNV) as 'tong_DS' 
                               , sum(case when ncv.MaNhomCongViec = 10 then 1 else 0 end) as 'QL_CTy' 
                             from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV 
                             left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID 
                             join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                            join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                             where h.NgayDiemDanh = @day 
                             group by n.MaPhongBan) a full join 
	                            (select n.MaPhongBan, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'vld1' 
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'om1' 
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'p1' 
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'khac1' 
                               , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'vld2' 
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'om2' 
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'p2' 
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'khac2' 
                               , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'vld3' 
                               , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'om3' 
                               , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'p3' 
                               , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'khac3' 
                               , SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') then 1 else 0 end) as 'tong_nghidai' 
                             from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV 
                             left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID 
                             where h.NgayDiemDanh = @day 
                             group by n.MaPhongBan) b on a.MaPhongBan = b.MaPhongBan";
            List<report> list = db.Database.SqlQuery<report>(sql, new SqlParameter("day", d)).ToList();
            foreach (var item in list)
            {

                //thong so ca 1
                item.LDTT1 = item.KT1 + item.CD1;
                item.tong1 = item.LDTT1 + item.QL1;
                item.vang1 = item.om1 + item.p1 + item.vld1 + item.khac1;
                //thong so ca 2
                item.LDTT2 = item.KT2 + item.CD2;
                item.tong2 = item.LDTT2 + item.QL2;
                item.vang2 = item.om2 + item.p2 + item.vld2 + item.khac2;
                //thong so ca 3
                item.LDTT3 = item.KT3 + item.CD3;
                item.tong3 = item.LDTT3 + item.QL3;
                item.vang3 = item.om3 + item.p3 + item.vld3 + item.khac3;
                //thong so tong
                item.tong_CD = item.CD1 + item.CD2 + item.CD3;
                item.tong_KT = item.KT1 + item.KT2 + item.KT3;
                item.tong_QL = item.QL1 + item.QL2 + item.QL3;
                item.tong_vld = item.vld1 + item.vld2 + item.vld3;
                item.tong_om = item.om1 + item.om2 + item.om3;
                item.tong_p = item.p1 + item.p2 + item.p3;
                item.tong_khac = item.khac1 + item.khac2 + item.khac3;
                item.tong_LDTT = item.tong_CD + item.tong_KT;
                item.tong = item.tong_LDTT + item.tong_QL;
                item.tong_vang = item.tong_vld + item.tong_om + item.tong_p + item.tong_khac + item.tong_nghidai;
                //thong so chung
                item.LDPX = item.tong + item.tong_vang;
                item.tong_tru_nghidai = item.tong_DS - item.tong_nghidai;
                //item.tong_LDTT = item.tong_tru_nghidai - item.QL_CTy;

            }
            ViewBag.list = list;
            return View("/Views/DK/ReportHuman/Daily.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-ngay/export")]
        [HttpPost]
        public void export(string date)
        {
            string path = HostingEnvironment.MapPath("/excel/DK/");
            string filename = "reportdaily.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                string[] temp = date.Split('/');
                date = temp[2] + "-" + temp[1] + "-" + temp[0];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string sql = @"select a.MaPhongBan,a.KT1,a.CD1,a.QL1,b.om1,b.vld1,b.p1,b.khac1,a.KT2,a.CD2,a.QL2,b.om2,b.vld2,b.p2,b.khac2,a.KT3,a.CD3,a.QL3,b.om3,b.vld3,b.p3,b.khac3,b.tong_nghidai,a.tong_DS,a.QL_CTy, 
                                (case when (a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) != 0 then cast(a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 as float) / cast((a.KT1 + a.CD1 + a.KT2 + a.CD2 + a.KT3 + a.CD3 + b.vld1 + b.vld2 + b.vld3 + b.om1 + b.om2 + b.om3 + b.p1 + b.p2 + b.p3 + b.khac1 + b.khac2 + b.khac3) as float) * 100 else 0 end) as 'tile' 
                                 from (select n.MaPhongBan, sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'KT1' 
                                   , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'CD1' 
                                   , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '1' and d.DiLam = '1' then 1 else 0 end) as 'QL1' 
                                   , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'KT2' 
                                   , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'CD2' 
                                   , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '2' and d.DiLam = '1' then 1 else 0 end) as 'QL2' 
                                   , sum(case when ncv.MaNhomCongViec = 6 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'KT3' 
                                   , SUM(case when ncv.MaNhomCongViec = 7 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'CD3' 
                                   , SUM(case when ncv.MaNhomCongViec = 10 and h.Ca = '3' and d.DiLam = '1' then 1 else 0 end) as 'QL3'
                                   , count(n.MaNV) as 'tong_DS' 
                                   , sum(case when ncv.MaNhomCongViec = 10 then 1 else 0 end) as 'QL_CTy' 
                                 from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV 
                                 left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID 
                                 join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec 
                                join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec 
                                 where h.NgayDiemDanh = @day 
                                 group by n.MaPhongBan) a full join 
	                                (select n.MaPhongBan, SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'vld1' 
                                   , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'om1' 
                                   , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'p1' 
                                   , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '1' and d.DiLam = '0' then 1 else 0 end) as 'khac1' 
                                   , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'vld2' 
                                   , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'om2' 
                                   , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'p2' 
                                   , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '2' and d.DiLam = '0' then 1 else 0 end) as 'khac2' 
                                   , SUM(case when d.LyDoVangMat like N'Vô lý do' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'vld3' 
                                   , sum(case when d.LyDoVangMat like N'Ốm'  and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'om3' 
                                   , SUM(case when d.LyDoVangMat like N'Nghỉ phép' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'p3' 
                                   , SUM(case when d.LyDoVangMat like N'Khác' and h.Ca = '3' and d.DiLam = '0' then 1 else 0 end) as 'khac3' 
                                   , SUM(case when d.LyDoVangMat in (N'Tai nạn lao động',N'Ốm dài',N'Thai sản',N'Tạm hoãn lao động',N'Vô lý do dài') then 1 else 0 end) as 'tong_nghidai' 
                                 from NhanVien n left outer join DiemDanh_NangSuatLaoDong d on n.MaNV = d.MaNV 
                                 left outer join Header_DiemDanh_NangSuat_LaoDong h on d.HeaderID = h.HeaderID 
                                 where h.NgayDiemDanh = @day 
                                 group by n.MaPhongBan) b on a.MaPhongBan = b.MaPhongBan";
                    List<report> list = db.Database.SqlQuery<report>(sql, new SqlParameter("day", date)).ToList();
                    foreach (var item in list)
                    {

                        //thong so ca 1
                        item.LDTT1 = item.KT1 + item.CD1;
                        item.tong1 = item.LDTT1 + item.QL1;
                        item.vang1 = item.om1 + item.p1 + item.vld1 + item.khac1;
                        //thong so ca 2
                        item.LDTT2 = item.KT2 + item.CD2;
                        item.tong2 = item.LDTT2 + item.QL2;
                        item.vang2 = item.om2 + item.p2 + item.vld2 + item.khac2;
                        //thong so ca 3
                        item.LDTT3 = item.KT3 + item.CD3;
                        item.tong3 = item.LDTT3 + item.QL3;
                        item.vang3 = item.om3 + item.p3 + item.vld3 + item.khac3;
                        //thong so tong
                        item.tong_CD = item.CD1 + item.CD2 + item.CD3;
                        item.tong_KT = item.KT1 + item.KT2 + item.KT3;
                        item.tong_QL = item.QL1 + item.QL2 + item.QL3;
                        item.tong_vld = item.vld1 + item.vld2 + item.vld3;
                        item.tong_om = item.om1 + item.om2 + item.om3;
                        item.tong_p = item.p1 + item.p2 + item.p3;
                        item.tong_khac = item.khac1 + item.khac2 + item.khac3;
                        item.tong_LDTT = item.tong_CD + item.tong_KT;
                        item.tong = item.tong_LDTT + item.tong_QL;
                        item.tong_vang = item.tong_vld + item.tong_om + item.tong_p + item.tong_khac + item.tong_nghidai;
                        //thong so chung
                        item.LDPX = item.tong + item.tong_vang;
                        item.tong_tru_nghidai = item.tong_DS - item.tong_nghidai;
                        //item.tong_LDTT = item.tong_tru_nghidai - item.QL_CTy;

                    }
                    int k = 4;
                    for (int i = 0; i < list.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = list.ElementAt(i).MaPhongBan;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).tong_tru_nghidai;
                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).tong_DS;
                        excelWorksheet.Cells[k, 4].Value = list.ElementAt(i).QL_CTy;
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).tong_LDDS;
                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).LDPX;
                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).tong_nghidai;

                        excelWorksheet.Cells[k, 8].Value = list.ElementAt(i).tong;
                        excelWorksheet.Cells[k, 9].Value = list.ElementAt(i).tong_LDTT;
                        excelWorksheet.Cells[k, 10].Value = list.ElementAt(i).tong_KT;
                        excelWorksheet.Cells[k, 11].Value = list.ElementAt(i).tong_CD;
                        excelWorksheet.Cells[k, 12].Value = list.ElementAt(i).tong_QL;
                        excelWorksheet.Cells[k, 13].Value = list.ElementAt(i).tong_vang;
                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).tong_vld;
                        excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).tong_om;
                        excelWorksheet.Cells[k, 16].Value = list.ElementAt(i).tong_p;
                        excelWorksheet.Cells[k, 17].Value = list.ElementAt(i).tong_khac;

                        excelWorksheet.Cells[k, 18].Value = list.ElementAt(i).tong1;
                        excelWorksheet.Cells[k, 19].Value = list.ElementAt(i).LDTT1;
                        excelWorksheet.Cells[k, 20].Value = list.ElementAt(i).KT1;
                        excelWorksheet.Cells[k, 21].Value = list.ElementAt(i).CD1;
                        excelWorksheet.Cells[k, 22].Value = list.ElementAt(i).QL1;
                        excelWorksheet.Cells[k, 23].Value = list.ElementAt(i).vang1;
                        excelWorksheet.Cells[k, 24].Value = list.ElementAt(i).vld1;
                        excelWorksheet.Cells[k, 25].Value = list.ElementAt(i).om1;
                        excelWorksheet.Cells[k, 26].Value = list.ElementAt(i).p1;
                        excelWorksheet.Cells[k, 27].Value = list.ElementAt(i).khac1;

                        excelWorksheet.Cells[k, 28].Value = list.ElementAt(i).tong2;
                        excelWorksheet.Cells[k, 29].Value = list.ElementAt(i).LDTT2;
                        excelWorksheet.Cells[k, 30].Value = list.ElementAt(i).KT2;
                        excelWorksheet.Cells[k, 31].Value = list.ElementAt(i).CD2;
                        excelWorksheet.Cells[k, 32].Value = list.ElementAt(i).QL2;
                        excelWorksheet.Cells[k, 33].Value = list.ElementAt(i).vang2;
                        excelWorksheet.Cells[k, 34].Value = list.ElementAt(i).vld2;
                        excelWorksheet.Cells[k, 35].Value = list.ElementAt(i).om2;
                        excelWorksheet.Cells[k, 36].Value = list.ElementAt(i).p2;
                        excelWorksheet.Cells[k, 37].Value = list.ElementAt(i).khac2;

                        excelWorksheet.Cells[k, 38].Value = list.ElementAt(i).tong3;
                        excelWorksheet.Cells[k, 39].Value = list.ElementAt(i).LDTT3;
                        excelWorksheet.Cells[k, 40].Value = list.ElementAt(i).KT3;
                        excelWorksheet.Cells[k, 41].Value = list.ElementAt(i).CD3;
                        excelWorksheet.Cells[k, 42].Value = list.ElementAt(i).QL3;
                        excelWorksheet.Cells[k, 43].Value = list.ElementAt(i).vang3;
                        excelWorksheet.Cells[k, 44].Value = list.ElementAt(i).vld3;
                        excelWorksheet.Cells[k, 45].Value = list.ElementAt(i).om3;
                        excelWorksheet.Cells[k, 46].Value = list.ElementAt(i).p3;
                        excelWorksheet.Cells[k, 47].Value = list.ElementAt(i).khac3;

                        excelWorksheet.Cells[k, 48].Value = list.ElementAt(i).tile;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/DK/baocaongay.xlsx")));
                }


            }
        }

        public class reportMonth
        {
            public string MaPhongBan { get; set; }
            public int ds { get; set; }
            public int ql { get; set; }
            public int congnhan { get; set; }
            public int cd { get; set; }
            public int kt { get; set; }
            public int hstt { get; set; }
            public int vang { get; set; }
            public int bq { get; set; }
            public int dilam { get; set; }
            public int tile { get; set; }
            public int tuan1 { get; set; }
            public int tuan2 { get; set; }
            public int tuan3 { get; set; }
            public int tuan4 { get; set; }
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-thang")]
        [HttpGet]
        public ActionResult Monthly()
        {
            DateTime date = DateTime.Today;
            string s = date.ToString("yyyy-MM");
            ViewBag.dat = date.ToString("MM/yyyy");
            string[] data = s.Split('-');
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            string sql = @"select a.department_id as 'MaPhongBan',(a.kt + a.cd + a.hstt + a.ql) as 'ds', a.ql,(a.kt + a.cd + a.hstt) as 'congnhan', a.cd, a.kt, a.hstt,
	                        (case when b.vang is null then 0 else b.vang end) as 'vang',
	                        (case when b.vang is null then a.kt + a.cd + a.hstt else a.kt + a.cd + a.hstt - b.vang end) as 'dilam',
	                        (case when tuan1 != 0 then cast(cast(dilamtuan1 as float)/cast(b.tuan1 as float)*100 as int) else 0 end) as tuan1,
	                        (case when tuan2 != 0 then cast(cast(dilamtuan2 as float)/cast(b.tuan2 as float)*100 as int) else 0 end) as tuan2,
	                        (case when tuan3 != 0 then cast(cast(dilamtuan3 as float)/cast(b.tuan3 as float)*100 as int) else 0 end) as tuan3,
	                        (case when tuan4 != 0 then cast(cast(dilamtuan4 as float)/cast(b.tuan4 as float)*100 as int) else 0 end) as tuan4
                        from (select d.department_id,
		                        sum(case when a.LoaiNhomCongViec like '%QL%' then 1 else 0 end) as 'ql',
		                        sum(case when a.LoaiNhomCongViec like N'%CĐ%' then 1 else 0 end) as 'cd',
		                        sum(case when a.LoaiNhomCongViec like '%KT%' then 1 else 0 end) as 'kt',
		                        sum(case when a.LoaiNhomCongViec like '%HSTT%' then 1 else 0 end) as 'hstt'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join (select distinct n.MaNV,ncv.LoaiNhomCongViec, n.MaPhongBan
				                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
				                        join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
				                        join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec) a on n.MaNV = a.MaNV
		                        group by d.department_id) a
	                        left outer join (select d.department_id,
		                        sum(case when (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'tuan1',
		                        sum(case when (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'tuan2',
		                        sum(case when (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'tuan3',
		                        sum(case when (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'tuan4',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'dilamtuan1',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'dilamtuan2',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'dilamtuan3',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'dilamtuan4',
		                        sum(case when dn.LyDoVangMat in (N'Ốm dài',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month and year(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vang'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join DiemDanh_NangSuatLaoDong dn on n.MaNV = dn.MaNV
			                        join Header_DiemDanh_NangSuat_LaoDong h on h.HeaderID = dn.HeaderID
		                        group by d.department_id) b on a.department_id = b.department_id";

            List<reportMonth> list = db.Database.SqlQuery<reportMonth>(sql, new SqlParameter("month", data[1]), new SqlParameter("year", data[0]),
                            new SqlParameter("start1", s + "-01"), new SqlParameter("end1", s + "-07"),
                            new SqlParameter("start2", s + "-08"), new SqlParameter("end2", s + "-14"),
                            new SqlParameter("start3", s + "-15"), new SqlParameter("end3", s + "-21"),
                            new SqlParameter("start4", s + "-22"), new SqlParameter("end4", s + "-28")).ToList();
            foreach(var item in list)
            {
                if(item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4 != 0)
                {
                    item.tile = (item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4) / 4;
                }
                item.bq = item.dilam / 3;
            }
            ViewBag.list = list;
            return View("/Views/DK/ReportHuman/Monthly.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-thang")]
        [HttpPost]
        public ActionResult MonthlySearch(string date)
        {
            string[] data = date.Split(' ');
            string st = data[1] + "/" + data[2];
            string s = data[2] + "-" + data[1];
            ViewBag.dat = st;
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            string sql = @"select a.department_id as 'MaPhongBan',(a.kt + a.cd + a.hstt + a.ql) as 'ds', a.ql,(a.kt + a.cd + a.hstt) as 'congnhan', a.cd, a.kt, a.hstt,
	                        (case when b.vang is null then 0 else b.vang end) as 'vang',
	                        (case when b.vang is null then a.kt + a.cd + a.hstt else a.kt + a.cd + a.hstt - b.vang end) as 'dilam',
	                        (case when tuan1 != 0 then cast(cast(dilamtuan1 as float)/cast(b.tuan1 as float)*100 as int) else 0 end) as tuan1,
	                        (case when tuan2 != 0 then cast(cast(dilamtuan2 as float)/cast(b.tuan2 as float)*100 as int) else 0 end) as tuan2,
	                        (case when tuan3 != 0 then cast(cast(dilamtuan3 as float)/cast(b.tuan3 as float)*100 as int) else 0 end) as tuan3,
	                        (case when tuan4 != 0 then cast(cast(dilamtuan4 as float)/cast(b.tuan4 as float)*100 as int) else 0 end) as tuan4
                        from (select d.department_id,
		                        sum(case when a.LoaiNhomCongViec like '%QL%' then 1 else 0 end) as 'ql',
		                        sum(case when a.LoaiNhomCongViec like N'%CĐ%' then 1 else 0 end) as 'cd',
		                        sum(case when a.LoaiNhomCongViec like '%KT%' then 1 else 0 end) as 'kt',
		                        sum(case when a.LoaiNhomCongViec like '%HSTT%' then 1 else 0 end) as 'hstt'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join (select distinct n.MaNV,ncv.LoaiNhomCongViec, n.MaPhongBan
				                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
				                        join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
				                        join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec) a on n.MaNV = a.MaNV
		                        group by d.department_id) a
	                        left outer join (select d.department_id,
		                        sum(case when (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'tuan1',
		                        sum(case when (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'tuan2',
		                        sum(case when (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'tuan3',
		                        sum(case when (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'tuan4',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'dilamtuan1',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'dilamtuan2',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'dilamtuan3',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'dilamtuan4',
		                        sum(case when dn.LyDoVangMat in (N'Ốm dài',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month and year(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vang'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join DiemDanh_NangSuatLaoDong dn on n.MaNV = dn.MaNV
			                        join Header_DiemDanh_NangSuat_LaoDong h on h.HeaderID = dn.HeaderID
		                        group by d.department_id) b on a.department_id = b.department_id";

            List<reportMonth> list = db.Database.SqlQuery<reportMonth>(sql, new SqlParameter("month", data[1]), new SqlParameter("year", data[2]),
                            new SqlParameter("start1", s + "-01"), new SqlParameter("end1", s + "-07"),
                            new SqlParameter("start2", s + "-08"), new SqlParameter("end2", s + "-14"),
                            new SqlParameter("start3", s + "-15"), new SqlParameter("end3", s + "-21"),
                            new SqlParameter("start4", s + "-22"), new SqlParameter("end4", s + "-28")).ToList();
            foreach (var item in list)
            {
                if (item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4 != 0)
                {
                    item.tile = (item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4) / 4;
                }
                item.bq = item.dilam / 3;
            }
            ViewBag.list = list;
            return View("/Views/DK/ReportHuman/Monthly.cshtml");
        }

        [Route("phong-dieu-khien/bao-cao-nhan-luc/bao-cao-nhan-luc-theo-thang/export")]
        [HttpPost]
        public void export2(string date)
        {
            string path = HostingEnvironment.MapPath("/excel/DK/");
            string filename = "reportmonth.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                string[] data = date.Split('/');
                string s = data[1] + "-" + data[0];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    string sql = @"select a.department_id as 'MaPhongBan',(a.kt + a.cd + a.hstt + a.ql) as 'ds', a.ql,(a.kt + a.cd + a.hstt) as 'congnhan', a.cd, a.kt, a.hstt,
	                        (case when b.vang is null then 0 else b.vang end) as 'vang',
	                        (case when b.vang is null then a.kt + a.cd + a.hstt else a.kt + a.cd + a.hstt - b.vang end) as 'dilam',
	                        (case when tuan1 != 0 then cast(cast(dilamtuan1 as float)/cast(b.tuan1 as float)*100 as int) else 0 end) as tuan1,
	                        (case when tuan2 != 0 then cast(cast(dilamtuan2 as float)/cast(b.tuan2 as float)*100 as int) else 0 end) as tuan2,
	                        (case when tuan3 != 0 then cast(cast(dilamtuan3 as float)/cast(b.tuan3 as float)*100 as int) else 0 end) as tuan3,
	                        (case when tuan4 != 0 then cast(cast(dilamtuan4 as float)/cast(b.tuan4 as float)*100 as int) else 0 end) as tuan4
                        from (select d.department_id,
		                        sum(case when a.LoaiNhomCongViec like '%QL%' then 1 else 0 end) as 'ql',
		                        sum(case when a.LoaiNhomCongViec like N'%CĐ%' then 1 else 0 end) as 'cd',
		                        sum(case when a.LoaiNhomCongViec like '%KT%' then 1 else 0 end) as 'kt',
		                        sum(case when a.LoaiNhomCongViec like '%HSTT%' then 1 else 0 end) as 'hstt'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join (select distinct n.MaNV,ncv.LoaiNhomCongViec, n.MaPhongBan
				                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
				                        join CongViec_NhomCongViec cn on n.MaCongViec = cn.MaCongViec
				                        join NhomCongViec ncv on cn.MaNhomCongViec = ncv.MaNhomCongViec) a on n.MaNV = a.MaNV
		                        group by d.department_id) a
	                        left outer join (select d.department_id,
		                        sum(case when (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'tuan1',
		                        sum(case when (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'tuan2',
		                        sum(case when (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'tuan3',
		                        sum(case when (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'tuan4',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start1 and @end1) then 1 else 0 end) as 'dilamtuan1',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start2 and @end2) then 1 else 0 end) as 'dilamtuan2',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start3 and @end3) then 1 else 0 end) as 'dilamtuan3',
		                        sum(case when dn.DiLam =1 and (h.NgayDiemDanh between @start4 and @end4) then 1 else 0 end) as 'dilamtuan4',
		                        sum(case when dn.LyDoVangMat in (N'Ốm dài',N'Vô lý do dài') and MONTH(h.NgayDiemDanh) = @month and year(h.NgayDiemDanh) = @year then 1 else 0 end) as 'vang'
		                        from NhanVien n join Department d on n.MaPhongBan = d.department_id
			                        join DiemDanh_NangSuatLaoDong dn on n.MaNV = dn.MaNV
			                        join Header_DiemDanh_NangSuat_LaoDong h on h.HeaderID = dn.HeaderID
		                        group by d.department_id) b on a.department_id = b.department_id";

                    List<reportMonth> list = db.Database.SqlQuery<reportMonth>(sql, new SqlParameter("month", data[1]), new SqlParameter("year", data[0]),
                                    new SqlParameter("start1", s + "-01"), new SqlParameter("end1", s + "-07"),
                                    new SqlParameter("start2", s + "-08"), new SqlParameter("end2", s + "-14"),
                                    new SqlParameter("start3", s + "-15"), new SqlParameter("end3", s + "-21"),
                                    new SqlParameter("start4", s + "-22"), new SqlParameter("end4", s + "-28")).ToList();
                    foreach (var item in list)
                    {
                        if (item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4 != 0)
                        {
                            item.tile = (item.tuan1 + item.tuan2 + item.tuan3 + item.tuan4) / 4;
                        }
                        item.bq = item.dilam / 3;
                    }

                    int k = 3;
                    for (int i = 0; i < list.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = i + 1;
                        excelWorksheet.Cells[k, 2].Value = list.ElementAt(i).MaPhongBan;
                        excelWorksheet.Cells[k, 3].Value = list.ElementAt(i).ds;
                        excelWorksheet.Cells[k, 4].Value = list.ElementAt(i).ql;
                        excelWorksheet.Cells[k, 5].Value = list.ElementAt(i).congnhan;
                        excelWorksheet.Cells[k, 6].Value = list.ElementAt(i).cd;
                        excelWorksheet.Cells[k, 7].Value = list.ElementAt(i).kt;
                        excelWorksheet.Cells[k, 8].Value = list.ElementAt(i).hstt;
                        excelWorksheet.Cells[k, 9].Value = list.ElementAt(i).vang;
                        excelWorksheet.Cells[k, 10].Value = list.ElementAt(i).dilam;
                        excelWorksheet.Cells[k, 11].Value = list.ElementAt(i).bq;
                        excelWorksheet.Cells[k, 12].Value = list.ElementAt(i).tuan1;
                        excelWorksheet.Cells[k, 13].Value = list.ElementAt(i).tuan2;
                        excelWorksheet.Cells[k, 14].Value = list.ElementAt(i).tuan3;
                        excelWorksheet.Cells[k, 15].Value = list.ElementAt(i).tuan4;
                        excelWorksheet.Cells[k, 16].Value = list.ElementAt(i).tile;

                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/DK/baocaothang.xlsx")));
                }


            }
        }

    }
}