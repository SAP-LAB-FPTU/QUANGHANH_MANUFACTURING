using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class ReportPowerUsageController : Controller
    {
        [Route("phong-cdvt/bao-cao/dien-nang")]
        public ActionResult Quarter(string type, string date, string month, string quarter, string year)
        {
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                getContentbyDay(ngay);
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                getContentbyDay(ngay);
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                getContentbyMonth(thang, nam);
            }
            if (type == "quarter")
            {
                int quy = Convert.ToInt32(quarter);
                int nam = Convert.ToInt32(year);
                getContentbyQuater(quy, nam);
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                getContentbyYear(nam);
            }
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
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = "select MONTH(a.date) as Thang, YEAR(a.date) as Nam,c.equipmentId as MaThietBi, " +
                " equipment_name as TenThietBi,consumption_value as " +
                " LuongTieuThu,ac.quantity as SanLuong from Fuel_activities_consumption a , Supply b, Equipment c , Activity ac " +
                " where a.fuel_type = b.supply_id and a.equipmentId = c.equipmentId  and ac.equipmentId = c.equipmentId " +
                " and fuel_type in ('DIEN') and a.date = '" + ngay + "' and a.date = ac.date";
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
        public ActionResult Export()
        {
            return File("~/excel/CDVT/diennang.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "diennang.xls");
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