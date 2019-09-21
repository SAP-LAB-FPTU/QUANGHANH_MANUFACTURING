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
        public ActionResult Index(string type, string date, string month, string quater, string year)
        {
            if(type == null)
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
            if (type == "quater")
            {
                int quy = Convert.ToInt32(quater);
                int nam = Convert.ToInt32(year);
                getContentbyQuater(quy, nam);
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                getContentbyYear(nam);
            }
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
        private void getContentbyQuater(int quater, int year)
        {
            int low = 1;
            int high = 3;
            if(quater == 1)
            {
                low = 1;
                high = 3;
            }
            if (quater == 2)
            {
                low = 4;
                high = 6;
            }
            if (quater == 3)
            {
                low = 7;
                high = 9;
            }
            if (quater == 4)
            {
                low = 10;
                high = 12;
            }
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if(db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.Xang = 0;
                }
                else
                {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value); 
                }
                if(db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
                {
                    ViewBag.DauNhuHoa = 0;
                }
                else
                {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Sum(a => a.consumption_value);
                }
                if(db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Month <= high && a.date.Month >= low && a.date.Year == year).Count() == 0)
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
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Count()==0) {
                    ViewBag.Xang = 0;
                }
                else {
                    ViewBag.Xang = db.Fuel_activities_consumption.Where(a => a.fuel_type == "XANG").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Count()==0) {
                    ViewBag.DauNhuHoa = 0;
                }
                else {
                    ViewBag.DauNhuHoa = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAU").Where(a => a.date.Year == year).Sum(a => a.consumption_value);
                }
                if (db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Count()==0) {
                    ViewBag.DauMo = 0;
                }
                else {
                    ViewBag.DauMo = db.Fuel_activities_consumption.Where(a => a.fuel_type == "DAUMO").Where(a => a.date.Year == year).Sum(a => a.consumption_value); ;
                }
            }
        }
    }
}