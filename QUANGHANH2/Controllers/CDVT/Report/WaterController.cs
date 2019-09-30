using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class WaterController : Controller
    {
        /*a*/
        [Route("phong-cdvt/bao-cao/thoat-nuoc")]
        public ActionResult Water(string type, string date, string month, string quarter, string year)
        {
            var noww = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ViewBag.now = noww;
            Wherecondition(type, date, month, quarter, year);
            if (ViewBag.ContentReport != null)
            {
                int total = 0;
                foreach (var item in ViewBag.ContentReport)
                {
                    total += item.LuongTieuThu;
                }
                ViewBag.TieuHao = total;
            }
            if (ViewBag.ContentReport != null)
            {
                int total = 0;
                foreach (var item in ViewBag.ContentReport)
                {
                    total += item.SanLuong;
                }
                ViewBag.SanLuong = total;
            }
            if (ViewBag.ContentReport != null)
            {
                int total = 0;
                foreach (var item in ViewBag.ContentReport)
                {
                    total += item.GioHoatDong;
                }
                ViewBag.GioHoatDong = total;
            }
            return View("/Views/CDVT/Report/WaterReport.cshtml");
        }

        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, "+
                 " d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong ,consumption_value as " +
                 " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac,Department d " +
                 " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId and d.department_id = c.department_id " +
                 " and fuel_type in ('DIEN') and a.date = '"+ngay+ "' and a.date = ac.date and c.Equipment_category_id = 'BNLT'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, " +
                 " d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong ,consumption_value as " +
                 " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac,Department d " +
                 " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                 " and d.department_id = c.department_id  and fuel_type in ('DIEN') and a.date = '" + ngay + "' and a.date = ac.date and c.Equipment_category_id = 'BNLT'";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, " +
                 " d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong ,consumption_value as " +
                 " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac,Department d " +
                 " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                 " and d.department_id = c.department_id and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = '" + nam+"' and MONTH(a.date) = '"+thang+ "' and c.Equipment_category_id = 'BNLT'";
            }
            if (type == "quarter")
            {
                int nam = Convert.ToInt32(year);
                string quy = "";
                if (quarter == "1")
                {
                    quy = " (1,2,3) ";
                }
                if (quarter == "2")
                {
                    quy = " (4,5,6) ";
                }
                if (quarter == "3")
                {
                    quy = " (7,8,9) ";
                }
                if (quarter == "4")
                {
                    quy = " (10,11,12) ";
                }
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, " +
                 " d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong ,consumption_value as " +
                 " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac,Department d " +
                 " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                 " and d.department_id = c.department_id and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = '" + nam+"' and MONTH(a.date) in "+quy+" and c.Equipment_category_id = 'BNLT'";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = " select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi,c.mark_code as MaTSCD, " +
                 " d.department_name as ViTriDat, equipment_name as TenThietBi, ac.hours_per_day as GioHoatDong ,consumption_value as " +
                 " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac,Department d " +
                 " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                 " and d.department_id = c.department_id and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = '" + nam+"' and c.Equipment_category_id = 'BNLT'";
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.ContentReport = db.Database.SqlQuery<contentreportWater>(query).ToList();
            }
        }
        [Route("phong-cdvt/bao-cao/thoat-nuoc/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/thoatnuoc.xlsx");
            string saveAsPath = ("/excel/CDVT/download/thoatnuoc.xlsx");
            FileInfo file = new FileInfo(path);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Wherecondition(type, date, month, quarter, year);
                    int totaltieuthu = 0, totalsanluong = 0, totalgio = 0;
                    if (ViewBag.ContentReport != null)
                    {
                        foreach (var item in ViewBag.ContentReport)
                        {
                            totaltieuthu += item.LuongTieuThu;
                        }
                    }
                    if (ViewBag.ContentReport != null)
                    {
                        foreach (var item in ViewBag.ContentReport)
                        {
                            totalsanluong += item.SanLuong;
                        }
                    }
                    if (ViewBag.ContentReport != null)
                    {
                        foreach (var item in ViewBag.ContentReport)
                        {
                            totalgio += item.GioHoatDong;
                        }
                    }
                    List<contentreportWater> content = ViewBag.ContentReport;
                    int k = 3;
                    for(int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).MaTSCD;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).ViTriDat;
                        excelWorksheet.Cells[k, 6].Value = content.ElementAt(i).GioHoatDong;
                        excelWorksheet.Cells[k, 7].Value = content.ElementAt(i).LuongTieuThu;
                        excelWorksheet.Cells[k, 8].Value = content.ElementAt(i).SanLuong;
                        k++;
                    }
                    excelWorksheet.Cells[k, 5].Value = "Tổng";
                    excelWorksheet.Cells[k, 6].Value = totalgio;
                    excelWorksheet.Cells[k, 7].Value = totaltieuthu;
                    excelWorksheet.Cells[k, 8].Value = totalsanluong;
                    excelWorksheet.Cells[k, 5].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 6].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 7].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 8].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
                return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }
    public class contentreportWater
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string ViTriDat { get; set; }
        public string TenThietBi { get; set; }
        public double GioHoatDong { get; set; }
        public int LuongTieuThu { get; set; }
        public double SanLuong { get; set; }
    }
}