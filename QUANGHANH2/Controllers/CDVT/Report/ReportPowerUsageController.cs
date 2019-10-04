using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    [Auther(RightID ="43")]
    public class ReportPowerUsageController : Controller
    {
        /*aa*/
        [Route("phong-cdvt/bao-cao/dien-nang")]
        public ActionResult Quarter(string type, string date, string month, string quarter, string year)
        {
            var noww = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ViewBag.now = noww;
            Wherecondition(type, date, month, quarter, year);
            if (ViewBag.ContentReport != null)
            {
                int total = 0;
                foreach(var item in ViewBag.ContentReport)
                {
                    total += item.LuongTieuThu;
                }
                ViewBag.Dien = total;
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
            return View("/Views/CDVT/Report/QuarterPowerUsage.cshtml");
        }
        private void getContentbyDay(DateTime date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.Dien = 0;
                }
                else
                {
                    ViewBag.Dien = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date == date).Sum(a => a.consumption_value);
                }
                if (db.Activities.Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.SanLuong = 0;
                }
                else
                {
                    ViewBag.SanLuong = db.Activities.Where(a => a.date == date).Sum(a => a.quantity);
                }
            }
        }
        private void getContentbyMonth(int month, int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.Dien = 0;
                }
                else
                {
                    ViewBag.Dien = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Activities.Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.SanLuong = 0;
                }
                else
                {
                    ViewBag.SanLuong = db.Activities.Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.quantity);
                }
            }
        }
        private void getContentbyYear(int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.Dien = 0;
                }
                else
                {
                    ViewBag.Dien = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Activities.Where(a => a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.SanLuong = 0;
                }
                else
                {
                    ViewBag.SanLuong = db.Activities.Where(a => a.date.Year == year).Sum(a => a.quantity);
                }
            }
        }
        private void getContentbyQuater(int quarter, int year)
        {
            int low = 1;
            int high = 3;
            if (quarter == 1)
            {
                low = 1;
                high = 3;
            }
            if (quarter == 2)
            {
                low = 4;
                high = 6;
            }
            if (quarter == 3)
            {
                low = 7;
                high = 9;
            }
            if (quarter == 4)
            {
                low = 10;
                high = 12;
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.Dien = 0;
                }
                else
                {
                    ViewBag.Dien = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DIEN").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Activities.Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.SanLuong = 0;
                }
                else
                {
                    ViewBag.SanLuong = db.Activities.Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.quantity);
                }
            }
        }
        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = '" + ngay + "' and a.date = ac.date";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date,"dd/MM/yyyy",null).ToString("yyyy-MM-dd");
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = '" + ngay + "' and a.date = ac.date";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = " + nam + " and MONTH(a.date) = " + thang;
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
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = " + nam + " and Month(a.date) in " + quy;
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = " select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = ac.date and YEAR(a.date) = " + nam;
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.ContentReport = db.Database.SqlQuery<contentreportPower>(query).ToList();
            }
        }
        [Route("phong-cdvt/bao-cao/dien-nang/excel")]
        public ActionResult Export(string type, string date, string month, string quarter, string year)
        {
            string path = HostingEnvironment.MapPath("/excel/CDVT/diennang.xlsx");
            string saveAsPath = ("/excel/CDVT/download/diennang.xlsx");
            FileInfo file = new FileInfo(path);
            using(ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Wherecondition(type, date, month, quarter, year);
                    int totaltieuthu = 0; int totalsanluong = 0;
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
                    int k = 3;
                    List<contentreportPower> content = ViewBag.ContentReport;
                    for (int i = 0; i < content.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = content.ElementAt(i).Thang + "/" + content.ElementAt(i).Nam;
                        excelWorksheet.Cells[k, 2].Value = content.ElementAt(i).MaThietBi;
                        excelWorksheet.Cells[k, 3].Value = content.ElementAt(i).TenThietBi;
                        excelWorksheet.Cells[k, 4].Value = content.ElementAt(i).LuongTieuThu;
                        excelWorksheet.Cells[k, 5].Value = content.ElementAt(i).SanLuong;
                        k++;
                    }
                    excelWorksheet.Cells[k, 3].Value = "Tổng";
                    excelWorksheet.Cells[k, 4].Value = totaltieuthu;
                    excelWorksheet.Cells[k, 5].Value = totalsanluong;
                    excelWorksheet.Cells[k, 3].Style.Font.Bold = true;
                    excelWorksheet.Cells[k, 3].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 4].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelWorksheet.Cells[k, 5].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath(saveAsPath)));
                }
            }
            return Json(new { success = true, location = saveAsPath }, JsonRequestBehavior.AllowGet);
        }
    }

    public class contentreportPower
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public int LuongTieuThu { get; set; }
        public double SanLuong { get; set; }
    }
}