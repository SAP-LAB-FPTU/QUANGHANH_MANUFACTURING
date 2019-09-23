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
    public class NhienlieuController : Controller
    {
        [Route("phong-cdvt/bao-cao/nhien-lieu")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                getContentbyDay(ngay);
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
            return View("/Views/CDVT/Report/FuelConsumption.cshtml");
        }
        [Route("phong-cdvt/bao-cao/nhien-lieu/excel")]
        public ActionResult Export()
        {
            return File("~/excel/CDVT/nhienlieu.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "nhienlieu.xls");
        }

        private void getContentbyDay(DateTime date)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date == date).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date == date).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date == date).ToList().Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date == date).Sum(a => a.consumption_value);
                }

            }
        }
        private void getContentbyMonth(int month, int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month == month && a.date.Year == year).ToList().Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month == month && a.date.Year == year).Sum(a => a.consumption_value);
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
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
            }
        }
        private void getContentbyYear(int year)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauMo = 0;
                }
                else
                {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Sum(a => a.consumption_value); ;
                }
            }
        }


        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string query = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,c.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu from Fuel_activities_consumption a , Supply b, Equipment c " +
                "where a.fuel_type=b.supply_id and a.equipmentId =c.equipmentId " +
                "and fuel_type in ('XANG', 'DAU', 'DAUMO') and date = '" + ngay+"'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,c.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu from Fuel_activities_consumption a , Supply b, Equipment c " +
                "where a.fuel_type=b.supply_id and a.equipmentId =c.equipmentId " +
                "and fuel_type in ('XANG', 'DAU', 'DAUMO') and date = '" + ngay + "'";
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,c.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu from Fuel_activities_consumption a , Supply b, Equipment c " +
                "where a.fuel_type=b.supply_id and a.equipmentId =c.equipmentId " +
                "and fuel_type in ('XANG', 'DAU', 'DAUMO') and YEAR(date) = " + nam + " and MONTH(date) = " + thang;
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
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,c.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu from Fuel_activities_consumption a , Supply b, Equipment c " +
                "where a.fuel_type=b.supply_id and a.equipmentId =c.equipmentId " +
                "and fuel_type in ('XANG', 'DAU', 'DAUMO') and YEAR(date) = " + nam + " and Month(date) in "+quy;
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                query = "select MONTH(date) as Thang, YEAR(date) as Nam,c.equipmentId as MaThietBi, " +
                "equipment_name as TenThietBi, supply_name as LoaiNhienLieu,consumption_value as " +
                "LuongTieuThu from Fuel_activities_consumption a , Supply b, Equipment c " +
                "where a.fuel_type=b.supply_id and a.equipmentId =c.equipmentId " +
                "and fuel_type in ('XANG', 'DAU', 'DAUMO') and YEAR(date) = " + nam;
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.ContentReport = db.Database.SqlQuery<contentreport>(query).ToList();
            }
        }


    }
    public class tablevm
    {
        public int total { get; set; }
        public int month { get; set; }
    }

    public class contentreport
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string LoaiNhienLieu { get; set; }
        public int LuongTieuThu { get; set; }
    }
}