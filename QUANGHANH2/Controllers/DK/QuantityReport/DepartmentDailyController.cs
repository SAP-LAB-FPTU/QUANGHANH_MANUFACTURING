//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using QUANGHANH2.Controllers.DK;
//using System.Data.SqlClient;
//using Newtonsoft.Json;
//using System.Web.Hosting;
//using System.IO;
//using OfficeOpenXml;
//using OfficeOpenXml.Style;
//using System.Drawing;

//namespace QUANGHANH2.Controllers.DK
//{
//    public class DepartmentDailyController : Controller
//    {
//        // GET: DepartmentDaily
//        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
//        public ActionResult Index()
//        {
//            return View("/Views/DK/QuantityReport/DepartmentDaily.cshtml");
//        }
//        //
//        dynamic getListReport(DateTime timeStart, DateTime timeEnd)
//        {
//            var query = @"select tmp1.*,TenTieuChi 
//					    from 
//					    (select department_name as [TenPhongBan], tmp2.* 
//					    from
//					    (select kht.MaPhongBan, kht.MaTieuChi,
//                        SUM(Case when Ca = 1 and Ngay = @dateEnd then SanLuong else 0 end) as [Ca1], 
//                        SUM(Case when Ca = 2 and Ngay = @dateEnd then SanLuong else 0 end) as [Ca2], 
//                        SUM(Case when Ca = 3 and Ngay = @dateEnd then SanLuong else 0 end) as [Ca3], 
//                        SUM(Case when(Ca = 3 or Ca = 2 or Ca = 1)and Ngay = @dateEnd then SanLuong else 0 end) as [TH], 
//                        SUM(Case when Ngay = @dateEnd then NgaySanXuat else 0 end) as [NgaySanXuat], 
//                        ISNULL(SUM(SanLuong),0) as [LuyKe] 
//					    from
//					    (select kht.MaPhongBan, khtctt.MaTieuChi, MAX(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung' 
//					    from 
//					    (select hd.HeaderID, hd.MaPhongBan from header_KeHoachTungThang hd join KeHoachTungThang khtt on hd.ThangID = khtt.ThangID
//					    where khtt.ThangKeHoach = Month(@dateEnd) and khtt.NamKeHoach = Year(@dateEnd)
//					    group by hd.HeaderID, hd.MaPhongBan) as kht 
//					    join KeHoach_TieuChi_TheoThang khtctt on khtctt.HeaderID = kht.HeaderID
//					    group by kht.MaPhongBan, khtctt.MaTieuChi) as kht
//					    LEFT JOIN
//                        (select MaPhongBan, MaTieuChi, Ca, Ngay, SanLuong, NgaySanXuat from
//                        (select h.*, t.NgaySanXuat, t.Ngay from header_ThucHienTheoNgay h join ThucHienTheoNgay t on h.NgayID = t.NgayID where Ngay between @dateStart and @dateEnd) as headerDaily
//                        inner join ThucHien_TieuChi_TheoNgay as th on headerDaily.HeaderID = th.HeaderID) as tmp1 on tmp1.MaTieuChi = kht.MaTieuChi and tmp1.MaPhongBan = kht.MaPhongBan
//                        Group by kht.MaPhongBan, kht.MaTieuChi) as tmp2
//					    inner join Department on tmp2.MaPhongBan = Department.department_id) as tmp1
//                        inner join TieuChi on tmp1.MaTieuChi = TieuChi.MaTieuChi
//                        order by MaPhongBan,MaTieuChi";

//            var querykHDaily = @"select 
//                                kht.MaPhongBan, 
//                                kht.MaTieuChi, 
//                                ISNULL(SUM(KeHoach), 0) as KeHoach
//                                from
//                                (select kht.MaPhongBan, khtctt.MaTieuChi, MAX(ThoiGianNhapCuoiCung) 'ThoiGianNhapCuoiCung'
//                                from
//                                (select hd.HeaderID, hd.MaPhongBan from header_KeHoachTungThang hd join KeHoachTungThang khtt on hd.ThangID = khtt.ThangID
//                                where khtt.ThangKeHoach = Month(@dateEnd) and khtt.NamKeHoach = Year(@dateEnd)
//                                group by hd.HeaderID, hd.MaPhongBan) as kht
//                                join KeHoach_TieuChi_TheoThang khtctt on khtctt.HeaderID = kht.HeaderID
//                                group by kht.MaPhongBan, khtctt.MaTieuChi) as kht
//                                LEFT JOIN
//                                (select MaPhongBan, MaTieuChi, KeHoach from
//                                (select* from header_KeHoach_TieuChi_TheoNgay where NgayNhapKH = @dateEnd) as headerDailyPlan
//                                inner join
//                                (select dailyPlan.*from KeHoach_TieuChi_TheoNgay as dailyPlan
//                                inner join
//                                (select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung] from KeHoach_TieuChi_TheoNgay
//                                group by HeaderID, MaTieuChi) as maxTime on maxTime.HeaderID = dailyPlan.HeaderID and maxTime.MaTieuChi = dailyPlan.MaTieuChi and maxTime.ThoiGianNhapCuoiCung = dailyPlan.ThoiGianNhapCuoiCung) as dailyPlan
//                                on headerDailyPlan.HeaderID = dailyPlan.HeaderID) as tmp1 on kht.MaPhongBan = tmp1.MaPhongBan and tmp1.MaTieuChi = kht.MaTieuChi
//                                group by kht.MaPhongBan, kht.MaTieuChi
//                                order by MaPhongBan, MaTieuChi";

//            var queryKHDC = @"select MaPhongBan,MaTieuChi,KHBD,KHDC,SoNgayLamViec from
//                            (select h.*, k.SoNgayLamViec from header_KeHoachTungThang h join KeHoachTungThang k on h.ThangID = k.ThangID where ThangKeHoach = @month and NamKeHoach = @year) as headerMonthlyPlan 
//                            inner join 
//                            (select HeaderID, MaTieuChi, 
//                            SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapBanDau then SanLuong else 0 end) as [KHBD], 
//                            SUM(Case when ThoiGianNhapCuoiCung = ThoiGianNhapCuoiCung_compare then SanLuong else 0 end) as [KHDC] 
//                            from 
//                            (select monthlyPlan.*, maxTime.ThoiGianNhapBanDau, maxTime.ThoiGianNhapCuoiCung as [ThoiGianNhapCuoiCung_compare] from KeHoach_TieuChi_TheoThang as monthlyPlan 
//                            inner join 
//                            (select HeaderID, MaTieuChi, Max(ThoiGianNhapCuoiCung) as [ThoiGianNhapCuoiCung], Min(ThoiGianNhapCuoiCung) as [ThoiGianNhapBanDau] from KeHoach_TieuChi_TheoThang 
//                            group by HeaderID, MaTieuChi) as maxTime 
//                            on maxTime.HeaderID = monthlyPlan.HeaderID and maxTime.MaTieuChi = monthlyPlan.MaTieuChi and(maxTime.ThoiGianNhapCuoiCung = monthlyPlan.ThoiGianNhapCuoiCung or maxTime.ThoiGianNhapBanDau = monthlyPlan.ThoiGianNhapCuoiCung)) as tmp1 
//                            group by HeaderID,MaTieuChi) as tmp2 
//                            on headerMonthlyPlan.HeaderID = tmp2.HeaderID 
//                            order by MaPhongBan,MaTieuChi";

//            List<reportEntity> reports = new List<reportEntity>();

//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                var listReport = db.Database.SqlQuery<reportEntity>(query, new SqlParameter("dateStart", timeStart), new SqlParameter("dateEnd", timeEnd)).ToList();
//                var listKHDC = db.Database.SqlQuery<KHDCDepartmentEntity>(queryKHDC, new SqlParameter("month", timeEnd.Month), new SqlParameter("year", timeEnd.Year)).ToList();
//                var listKHDaily = db.Database.SqlQuery<DailyPlanEntity>(querykHDaily, new SqlParameter("date", timeEnd), new SqlParameter("month", timeEnd.Month), new SqlParameter("dateEnd", timeEnd)).ToList();
//                if (listKHDaily.Count == 0)
//                {
//                    return reports;
//                }
//                for (var index = 0; index < listReport.Count; index++)
//                {
//                    listReport[index].KHDC = listKHDC[index].KHDC;
//                    listReport[index].KHBD = listKHDC[index].KHBD;
//                    listReport[index].KH = listKHDaily[index].KeHoach;
//                    listReport[index].BQQHDC = listReport[index].KHDC / listKHDC[index].SoNgayLamViec;
//                    listReport[index].BQQHDC_display = string.Format("{0:0.00}", listReport[index].BQQHDC);
//                    listReport[index].chenhlech = listReport[index].TH - listReport[index].KH;
//                    if (listReport[index].KH != 0)
//                    {
//                        listReport[index].percentage = 100 * listReport[index].TH / listReport[index].KH;
//                        listReport[index].percentage_display = string.Format("{0:0.00}", listReport[index].percentage);
//                    }
//                    if (listReport[index].KHDC != 0)
//                    {
//                        listReport[index].percentageDC = 100 * listReport[index].luyke / listReport[index].KHDC;
//                        listReport[index].percentageDC_display = string.Format("{0:0.00}", listReport[index].percentageDC);
//                    }
//                    listReport[index].SUM = listReport[index].KHDC - listReport[index].luyke;
//                    if (listReport[index].NgaySanXuat != listKHDC[index].SoNgayLamViec)
//                    {
//                        listReport[index].perday = listReport[index].SUM / (listKHDC[index].SoNgayLamViec - listReport[index].NgaySanXuat);
//                    }
//                    else
//                    {
//                        listReport[index].perday = listReport[index].SUM;
//                    }
//                    listReport[index].perday_display = string.Format("{0:0.00}", listReport[index].perday);

//                }
//                var departmentName = db.Departments.Where(x => x.department_type.Contains("Phân xưởng sản xuất chính") || x.department_type.Contains("Đơn vị sản xuất thuê ngoài")).OrderBy(x => x.department_name).ToList();
//                foreach (var name in departmentName)
//                {
//                    reportEntity rp = new reportEntity();
//                    rp.TenPhongBan = name.department_name;
//                    rp.isHeader = true;
//                    reports.Add(rp);
//                    foreach (var report in listReport)
//                    {
//                        if (report.TenPhongBan == name.department_name)
//                        {
//                            report.isHeader = false;
//                            reports.Add(report);
//                        }
//                    }
//                }
//                return reports;
//            }
//        }
//        //
//        [Route("phong-dieu-khien/bao-cao-san-xuat-than/bao-cao-san-luong-toan-cong-ty-theo-phan-xuong")]
//        [HttpPost]
//        public ActionResult GetData()
//        {
//            var date = Request["date"];
//            if (date == null || date == "")
//            {
//                return Json(new { error = true, title = "Lỗi", message = "Chưa chọn ngày xem sản xuất" });
//            }
//            else
//            {
//                DateTime timeEnd = Convert.ToDateTime(date);
//                var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
//                var reports = getListReport(timeStart, timeEnd);
//                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
//                var result = JsonConvert.SerializeObject(reports, Formatting.Indented, jss);
//                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        [Route("phong-dieu-khien/bao-cao-san-xuat-than/export-excel")]
//        [HttpPost]
//        public ActionResult ExportExcel()
//        {
//            var date = Request["date"];
//            if (date == null || date == "")
//            {
//                return Json(new { error = true, title = "Lỗi", message = "Chưa chọn ngày xem sản xuất" });
//            }
//            else
//            {
//                DateTime timeEnd = Convert.ToDateTime(date);
//                var timeStart = Convert.ToDateTime("" + timeEnd.Year + "-" + timeEnd.Month + "-1");
//                var reports = getListReport(timeStart, timeEnd);

//                var nam = Request["date"].Split('-')[0];
//                var thang = Request["date"].Split('-')[1];
//                var ngay = Request["date"].Split('-')[2];
//                //////////////////////////////////////////////////////////////////////////////////////

//                string path = HostingEnvironment.MapPath("/excel/DK/DailyDepartment/templateBaoCaoTheoPhanXuong.xlsx");
//                FileInfo file = new FileInfo(path);
//                using (ExcelPackage excelPackage = new ExcelPackage(file))
//                {
//                    ExcelWorkbook excelWorkbook = excelPackage.Workbook;
//                    ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

//                    int k = 0;
//                    int count = 0;
//                    excelWorksheet.Cells[1, 4].Value = "Ngày " + ngay + " tháng " + thang + " năm " + nam;
//                    excelWorksheet.Cells[1, 11].Value = "Tháng " + thang;

//                    if (reports.Count != 0)
//                    {
//                        for (int i = 3; i <= reports.Count + 2; i++)
//                        {
//                            if (reports[k].isHeader)
//                            {
//                                excelWorksheet.Cells[i, 1].Value = reports[k].TenPhongBan;
//                                excelWorksheet.Cells[i, 1, i, 16].Merge = true;
//                                excelWorksheet.Cells[i, 1, i, 16].Style.Font.Bold = true;
//                                excelWorksheet.Cells[i, 1, i, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
//                                excelWorksheet.Cells[i, 1, i, 16].Style.Font.Size = 13;

//                                count = 1;
//                            }
//                            else
//                            {
//                                excelWorksheet.Cells[i, 1].Value = count;
//                                excelWorksheet.Cells[i, 2].Value = string.Format("{0:0.00}", reports[k].TenTieuChi);
//                                excelWorksheet.Cells[i, 3].Value = string.Format("{0:0.00}", reports[k].BQQHDC);
//                                excelWorksheet.Cells[i, 4].Value = string.Format("{0:0.00}", reports[k].Ca1);
//                                excelWorksheet.Cells[i, 5].Value = string.Format("{0:0.00}", reports[k].Ca2);
//                                excelWorksheet.Cells[i, 6].Value = string.Format("{0:0.00}", reports[k].Ca3);
//                                excelWorksheet.Cells[i, 7].Value = string.Format("{0:0.00}", reports[k].TH);
//                                excelWorksheet.Cells[i, 8].Value = string.Format("{0:0.00}", reports[k].KH);
//                                excelWorksheet.Cells[i, 9].Value = string.Format("{0:0.00}", reports[k].chenhlech);
//                                if (reports[k].chenhlech > 0)
//                                {
//                                    excelWorksheet.Cells[i, 9].Style.Font.Color.SetColor(Color.Green);
//                                }
//                                else
//                                {
//                                    excelWorksheet.Cells[i, 9].Style.Font.Color.SetColor(Color.Red);
//                                }
//                                excelWorksheet.Cells[i, 10].Value = string.Format("{0:0.00}", reports[k].percentage);
//                                excelWorksheet.Cells[i, 11].Value = string.Format("{0:0.00}", reports[k].luyke);
//                                excelWorksheet.Cells[i, 12].Value = string.Format("{0:0.00}", reports[k].KHBD);
//                                excelWorksheet.Cells[i, 13].Value = string.Format("{0:0.00}", reports[k].KHDC);
//                                excelWorksheet.Cells[i, 14].Value = string.Format("{0:0.00}", reports[k].percentageDC);
//                                excelWorksheet.Cells[i, 15].Value = string.Format("{0:0.00}", reports[k].SUM);
//                                excelWorksheet.Cells[i, 16].Value = string.Format("{0:0.00}", reports[k].perday);
//                                excelWorksheet.Cells[i, 17].Value = reports[k].GhiChu;
//                                count++;
//                            }
//                            k++;

//                        }
//                        ExcelRange Rng = excelWorksheet.Cells[3, 1, reports.Count + 2, 16];
//                        Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
//                        Rng.Style.Border.Top.Color.SetColor(Color.Gray);
//                        Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
//                        Rng.Style.Border.Left.Color.SetColor(Color.Gray);
//                        Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
//                        Rng.Style.Border.Right.Color.SetColor(Color.Gray);
//                        Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
//                        Rng.Style.Border.Bottom.Color.SetColor(Color.Gray);
//                    }

//                    string location = HostingEnvironment.MapPath("/excel/DK/DailyDepartment");
//                    excelPackage.SaveAs(new FileInfo(location + "/BaoCao.xlsx"));
//                    string handle = Guid.NewGuid().ToString();
//                    string downloadFilename = "BaoCaoPhanXuong.xlsx";
//                    using (MemoryStream memoryStream = new MemoryStream())
//                    {
//                        excelPackage.SaveAs(memoryStream);
//                        memoryStream.Position = 0;
//                        TempData[handle] = memoryStream.ToArray();
//                    }
//                    return Json(new { success = true, data = new { FileGuid = handle, FileName = downloadFilename } }, JsonRequestBehavior.AllowGet);
//                }
//                //return null;
//            }
//        }
//        [HttpGet]
//        [Route("phong-dieu-khien/bao-cao-san-xuat-than/download")]
//        public virtual ActionResult Download(string fileGuid, string fileName)
//        {
//            if (TempData[fileGuid] != null)
//            {
//                byte[] data = TempData[fileGuid] as byte[];
//                return File(data, "application/vnd.ms-excel", fileName);
//            }
//            else
//            {
//                return new EmptyResult();
//            }
//        }
//    }
//    public class KHDCDepartmentEntity
//    {
//        public int MaTieuChi { get; set; }
//        public double KHBD { get; set; }
//        public double KHDC { get; set; }
//        public int SoNgayLamViec { get; set; }
//        public string MaPhongBan { get; set; }
//    }

//    public class DailyPlanEntity
//    {
//        public int MaTieuChi { get; set; }
//        public string MaPhongBan { get; set; }

//        public double KeHoach { get; set; }
//    }

//}

