using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Controllers.DK;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Hosting;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;


namespace QUANGHANH2.Controllers.BGD.QuantityReport
{
    public class DepartmentDailyController : Controller
    {
        // GET: DepartmentDaily
        [Route("ban-giam-doc/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
        public ActionResult Index()
        {
            return View("/Views/BGD/QuantityReport/Factory.cshtml");
        }
        //
        dynamic getListReport(DateTime timeStart, DateTime timeEnd)
        {
            var query = "select PhongBan_TieuChi.MaPhongBan,PhongBan_TieuChi.MaTieuChi,department_name as TenPhongBan," +
                "(case when b.Ca1 is null then 0 else b.Ca1 end) as Ca1,(case when b.Ca2 is null then 0 else b.Ca2 end) as Ca2," +
                "(case when b.Ca3 is null then 0 else b.Ca3 end) as Ca3,(case when b.TH is null then 0 else b.TH end) as TH," +
                "(case when b.LUYKE is null then 0 else b.LUYKE end) as LUYKE from(" +
                "select MaPhongBan, MaTieuChi, SUM(Case when Ca = 1 and Ngay = @dateEnd then SanLuong else convert(float, 0) end) as [Ca1]," +
                "SUM(Case when Ca = 2 and Ngay = @dateEnd then SanLuong else convert(float, 0) end) as [Ca2]," +
                "SUM(Case when Ca = 3 and Ngay = @dateEnd  then SanLuong else convert(float, 0) end) as [Ca3]," +
                "SUM(Case when Ngay = @dateEnd  then SanLuong else convert(float, 0) end) as [TH]," +
                "SUM(SanLuong) as [LUYKE] from(" +
                "select header.HeaderID, th.MaTieuChi, th.SanLuong, header.MaPhongBan, header.Ca, header.Ngay from ThucHien_TieuChi_TheoNgay as th " +
                "inner join(select * from header_ThucHienTheoNgay where Ngay <= @dateEnd and Ngay >= @dateStart) as header on th.HeaderID = header.HeaderID) as a " +
                "group by MaPhongBan,MaTieuChi ) as b " +
                "right join(select* from PhongBan_TieuChi where PhongBan_TieuChi.Thang = 9) as PhongBan_TieuChi on b.MaPhongBan = PhongBan_TieuChi.MaPhongBan and PhongBan_TieuChi.MaTieuChi = b.MaTieuChi " +
                "join Department on PhongBan_TieuChi.MaPhongBan = department_id " +
                "order by MaPhongBan";
            var queryKHDC = "select PhongBan_TieuChi.MaPhongBan, PhongBan_TieuChi.MaTieuChi," +
                "(case when SanLuong is null then 0 else SanLuong end) as [SanLuong] from(select kh.MaTieuChi, kh.SanLuong, header.MaPhongBan from(" +
                "select KeHoach_TieuChi_TheoThang.* from(" +
                "select HeaderID, MaTieuChi, MAX(ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung from KeHoach_TieuChi_TheoThang group by HeaderID, MaTieuChi) " +
                "as a inner join KeHoach_TieuChi_TheoThang " +
                "on a.HeaderID = KeHoach_TieuChi_TheoThang.HeaderID and a.MaTieuChi = KeHoach_TieuChi_TheoThang.MaTieuChi " +
                "and a.ThoiGianNhapCuoiCung = KeHoach_TieuChi_TheoThang.ThoiGianNhapCuoiCung) as kh " +
                "inner join(select * from header_KeHoachTungThang where ThangKeHoach = @month and NamKeHoach = @year) as header on kh.HeaderID = header.HeaderID) as table1 " +
                "right join(select* from PhongBan_TieuChi where PhongBan_TieuChi.Thang = @month) as PhongBan_TieuChi on table1.MaPhongBan = PhongBan_TieuChi.MaPhongBan and PhongBan_TieuChi.MaTieuChi = table1.MaTieuChi " +
                "order by PhongBan_TieuChi.MaPhongBan";
            var querykHDaily = "select PhongBan_TieuChi.MaPhongBan, PhongBan_TieuChi.MaTieuChi," +
                "(case when SanLuong is null then 0 else SanLuong end) as [SanLuong] from " +
                "(select MaPhongBan, MaTieuChi, SUM(KeHoach) as SanLuong from( " +
                "select khtc.* from(select HeaderID, MaTieuChi, MAX(ThoiGianNhapCuoiCung) as ThoiGianNhapCuoiCung  from KeHoach_TieuChi_TheoNgay " +
                "group by HeaderID, MaTieuChi) as a " +
                "inner join KeHoach_TieuChi_TheoNgay as khtc " +
                "on a.HeaderID = khtc.HeaderID and a.MaTieuChi = khtc.MaTieuChi and a.ThoiGianNhapCuoiCung = khtc.ThoiGianNhapCuoiCung) as kh " +
                "inner join(select * from header_KeHoach_TieuChi_TheoNgay where NgayNhapKH = @date) as header " +
                "on kh.HeaderID = header.HeaderID " +
                "group by MaPhongBan, MaTieuChi) as table1 " +
                "right join(select* from PhongBan_TieuChi where PhongBan_TieuChi.Thang = @month) as PhongBan_TieuChi on table1.MaPhongBan = PhongBan_TieuChi.MaPhongBan and PhongBan_TieuChi.MaTieuChi = table1.MaTieuChi " +
                "order by PhongBan_TieuChi.MaPhongBan";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
                // var listKHDC = db.Database.SqlQuery<KHDCDepartmentEntity>(queryKHDC, new SqlParameter("month", timeEnd.Month), new SqlParameter("year", timeEnd.Year)).ToList();
                var listKHDC = db.Database.SqlQuery<KHDCDepartmentEntity>(queryKHDC, new SqlParameter("month", timeEnd.Month), new SqlParameter("year", timeEnd.Year)).ToList();
                // var listKHDaily = db.Database.SqlQuery<KHDCDepartmentEntity>(querykHDaily, new SqlParameter("date", timeEnd), new SqlParameter("month", timeEnd.Month)).ToList();
                var listKHDaily = db.Database.SqlQuery<KHDCDepartmentEntity>(querykHDaily, new SqlParameter("date", timeEnd), new SqlParameter("month", timeEnd.Month)).ToList();
                for (var index = 0; index < listReport.Count; index++)
                {
                    //if (index < listKHDC.Count)
                    //{
                    //    listReport[index].KHDC = listKHDC[index].SanLuong;
                    //    listReport[index].BQQHDC = listReport[index].KHDC / 16;
                    //}
                    //if (index < listKHDaily.Count)
                    //{
                    //    listReport[index].KH = listKHDaily[index].SanLuong;
                    //}
                }
                var departmentName = new string[] { "Phân xưởng khai thác 1", "Phân xưởng khai thác 2", "Phân xưởng khai thác 3", "Phân xưởng khai thác 4","Phân xưởng khai thác 5",
                                                    "Phân xưởng khai thác 6", "Phân xưởng khai thác 7", "Phân xưởng khai thác 8", "Phân xưởng khai thác 9","Phân xưởng khai thác 10",
                                                    "Phân xưởng khai thác 11", "Phân xưởng đào lò 3", "Phân xưởng đào lò 5", "Phân xưởng đào lò 7","Phân xưởng đào lò 7","Phân xưởng đào lò 8",
                                                    "Công Ty Dương Huy","Phân xưởng sàng tuyển","Phân xưởng lộ thiên","Công ty Xây lắp mỏ - TKV","Liên doanh nhà thầu Công ty CP thương mại - công nghệ CT Thăng Long và Công ty tư vấn Công ty Thăng Long",
                                                    "Công ty ASEAN"};
                List<reportEntity> reports = new List<reportEntity>();
                foreach (var name in departmentName)
                {
                    reportEntity rp = new reportEntity();
                    rp.TenPhongBan = name;
                    rp.isHeader = true;
                    reports.Add(rp);
                    foreach (var report in listReport)
                    {
                        if (report.TenPhongBan == name)
                        {
                            report.isHeader = false;
                            reports.Add(report);
                        }
                    }
                }
                foreach (var item in reports)
                {
                    item.percentageDC = ((item.luyke / item.KHDC) * 100);
                    item.SUM = item.KHDC - item.luyke;
                    item.perday = item.SUM / 16;
                    item.chenhlech = item.TH - item.KH;
                    item.percentage = item.KH == 0 ? 0 : (item.TH / item.KH);
                }
                return reports;
            }
        }
        //
        [Route("ban-giam-doc/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
        [HttpPost]
        public ActionResult GetData()
        {
            DateTime timeEnd = Convert.ToDateTime(Request["date"]);
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            var reports = getListReport(timeStart, timeEnd);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(reports, Formatting.Indented, jss);
            return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
        }

        [Route("ban-giam-doc/bao-cao-san-xuat-than/export-excel")]
        [HttpPost]
        public ActionResult ExportExcel()
        {
            DateTime timeEnd = Convert.ToDateTime(Request["date"]);
            var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
            var reports = getListReport(timeStart, timeEnd);
            var nam = Request["date"].Split('-')[0];
            var thang = Request["date"].Split('-')[1];
            var ngay = Request["date"].Split('-')[2];
            //////////////////////////////////////////////////////////////////////////////////////

            string path = HostingEnvironment.MapPath("/excel/DK/DailyDepartment/templateBaoCaoTheoPhanXuong.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                int k = 0;
                int count = 0;
                excelWorksheet.Cells[1, 4].Value = "Ngày " + ngay + " tháng " + thang + " năm " + nam;
                excelWorksheet.Cells[1, 11].Value = "Tháng " + thang;
                for (int i = 3; i <= reports.Count + 2; i++)
                {
                    if (reports[k].isHeader)
                    {
                        excelWorksheet.Cells[i, 1].Value = reports[k].TenPhongBan;
                        excelWorksheet.Cells[i, 1, i, 16].Merge = true;
                        excelWorksheet.Cells[i, 1, i, 16].Style.Font.Bold = true;
                        excelWorksheet.Cells[i, 1, i, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        excelWorksheet.Cells[i, 1, i, 16].Style.Font.Size = 13;

                        count = 1;
                    }
                    else
                    {
                        excelWorksheet.Cells[i, 1].Value = count;
                        excelWorksheet.Cells[i, 2].Value = reports[k].TenTieuChi;
                        excelWorksheet.Cells[i, 3].Value = reports[k].BQQHDC;
                        excelWorksheet.Cells[i, 4].Value = reports[k].Ca1;
                        excelWorksheet.Cells[i, 5].Value = reports[k].Ca2;
                        excelWorksheet.Cells[i, 6].Value = reports[k].Ca3;
                        excelWorksheet.Cells[i, 7].Value = reports[k].TH;
                        excelWorksheet.Cells[i, 8].Value = reports[k].KH;
                        excelWorksheet.Cells[i, 9].Value = reports[k].chenhlech;
                        if (reports[k].chenhlech > 0)
                        {
                            excelWorksheet.Cells[i, 9].Style.Font.Color.SetColor(Color.Green);
                        }
                        else
                        {
                            excelWorksheet.Cells[i, 9].Style.Font.Color.SetColor(Color.Red);
                        }
                        excelWorksheet.Cells[i, 10].Value = reports[k].percentage;
                        excelWorksheet.Cells[i, 11].Value = reports[k].luyke;
                        excelWorksheet.Cells[i, 12].Value = reports[k].KHDC;
                        excelWorksheet.Cells[i, 13].Value = reports[k].percentageDC;
                        excelWorksheet.Cells[i, 14].Value = reports[k].SUM;
                        excelWorksheet.Cells[i, 15].Value = reports[k].perday;
                        excelWorksheet.Cells[i, 16].Value = reports[k].GhiChu;
                        count++;
                    }
                    k++;

                }
                ExcelRange Rng = excelWorksheet.Cells[3, 1, reports.Count + 2, 16];
                Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Top.Color.SetColor(Color.Gray);
                Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Left.Color.SetColor(Color.Gray);
                Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Right.Color.SetColor(Color.Gray);
                Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Bottom.Color.SetColor(Color.Gray);

                string location = HostingEnvironment.MapPath("/excel/DK/DailyDepartment");
                excelPackage.SaveAs(new FileInfo(location + "/BaoCao.xlsx"));
                string handle = Guid.NewGuid().ToString();
                string downloadFilename = "BaoCaoPhanXuong.xlsx";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    excelPackage.SaveAs(memoryStream);
                    memoryStream.Position = 0;
                    TempData[handle] = memoryStream.ToArray();
                }

                return Json(new { success = true, data = new { FileGuid = handle, FileName = downloadFilename } }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        [HttpGet]
        [Route("ban-giam-doc/bao-cao-san-xuat-than/download")]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}