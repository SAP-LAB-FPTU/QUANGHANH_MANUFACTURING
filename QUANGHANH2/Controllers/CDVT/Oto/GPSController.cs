using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Oto
{
    public class GPSController : Controller
    {
        [Auther(RightID ="190")]
        [Route("phong-cdvt/oto/GPS")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/GPS.cshtml");
        }

        [Route("phong-cdvt/oto/GPS")]
        [HttpPost]
        public ActionResult GetData(string stringDate)
        {
            //Server Side Parameter
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int session = 0;
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14 && DateTime.Now.Date == date) session = 1;
            if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 22 && DateTime.Now.Date == date) session = 2;
            if ((DateTime.Now.Hour >= 22 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 6 && DateTime.Now.Date.AddDays(-1) == date)) session = 3;

            string varname1 = @"select d.equipmentId, e.Equipment_category_name, d.ca1, d.reason1, d.ca2, d.reason2, d.ca3, d.reason3 from
	(select a.equipmentId, a.equipment_name, a.Equipment_category_id, a.ca1, a.reason1, b.ca2, b.reason2, c.ca3, c.reason3 from   
		(select e.equipmentId, e.equipment_name, e.Equipment_category_id, c.[session], c.available as ca1, c.reason as reason1   
		from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId   
		where c.[date] = @date and c.[session] = 1) as a left join   
		(select e.equipmentId, e.equipment_name, e.Equipment_category_id, c.[session], c.available as ca2, c.reason as reason2   
		from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId   
		where c.[date] = @date and c.[session] = 2) as b on a.equipmentId = b.equipmentId   
		left join   
		(select e.equipmentId, e.equipment_name, e.Equipment_category_id, c.[session], c.available as ca3, c.reason as reason3   
		from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId   
		where c.[date] = @date and c.[session] = 3) as c on b.equipmentId = c.equipmentId
	) as d
			inner join Equipment_category as e on d.Equipment_category_id = e.Equipment_category_id";
            List<CarGPSDB> list = DBContext.Database.SqlQuery<CarGPSDB>(varname1,
                new SqlParameter("date", date)).ToList();
            if (!list.Any())
            {
                list = DBContext.Database.SqlQuery<CarGPSDB>("SELECT e.equipmentId, ec.Equipment_category_name FROM Equipment e inner join Car c on e.equipmentId = c.equipmentId inner join Equipment_category ec on e.Equipment_category_id = ec.Equipment_category_id").ToList();
                foreach (CarGPSDB item in list)
                {
                    item.ca1 = true;
                    item.ca2 = true;
                    item.ca3 = true;
                }
            }
            int totalrows = list.Count;
            int totalrowsafterfiltering = list.Count;
            //sorting
            list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<CarGPSDB>();
            //paging
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering, session = session });
        }
        [Auther(RightID = "191")]
        [Route("phong-cdvt/oto/GPS/Update")]
        [HttpPost]
        public ActionResult Update(string stringjson)
        {
            JObject jObject = JObject.Parse(stringjson);
            DateTime date = DateTime.ParseExact((string)jObject["date"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            JArray jArray = (JArray)jObject["list"];
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (JObject item in jArray)
                    {
                        //Ca 1: 7h-15h
                        //Ca 2: 15h-23h
                        //Ca 3: 23h-7h
                        string equipmentId = (string)item["equipmentId"];
                        int ca = (int)item["ca"];
                        int thisCa = 0;
                        if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 15 && DateTime.Now.Date == date) thisCa = 1;
                        if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 23 && DateTime.Now.Date == date) thisCa = 2;
                        if ((DateTime.Now.Hour >= 23 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 7 && DateTime.Now.Date.AddDays(-1) == date)) thisCa = 3;
                        bool available = (bool)item["available"];
                        CarGP car = DBContext.CarGPS.Find(equipmentId, date, ca);
                        if (car == null)
                        {
                            car = new CarGP();
                            car.available = available ? true : false;
                            car.date = date;
                            car.equipmentId = equipmentId;
                            car.reason = (string)item["reason"];
                            car.session = ca;
                            DBContext.CarGPS.Add(car);
                        }
                        else
                        {
                            car.available = available ? true : false;
                            car.reason = (string)item["reason"];
                        }
                        if (thisCa == ca)
                        {
                            Car c = DBContext.Cars.Find(equipmentId);
                            c.GPS = available;
                        }
                        DBContext.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false });
                }
            }
            return Json(new { success = true });
        }

        [Route("phong-cdvt/oto/GPS/GetReason")]
        [HttpPost]
        public ActionResult GetReason(string equipmentId, int ca, string stringdate)
        {
            DateTime dateTime = DateTime.ParseExact(stringdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime start = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 6, 0, 0);
            DateTime end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 14, 0, 0);
            if (ca == 2)
            {
                start = end;
                end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 22, 0, 0);
            }
            if (ca == 3)
            {
                start = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 22, 0, 0);
                end = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, 6, 0, 0);
            }
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string reason = DBContext.Database.SqlQuery<string>("select maintain_content from Maintain_Car where equipmentId = @equipmentId and [date] between @start and @end",
                new SqlParameter("equipmentid", equipmentId),
                new SqlParameter("start", start),
                new SqlParameter("end", end)).FirstOrDefault();
            return Json(new { reason = reason == null ? "" : reason });
        }

        private class CarGPSDB
        {
            public string equipmentId { get; set; }
            public string Equipment_category_name { get; set; }
            public Boolean ca1 { get; set; }
            public string reason1 { get; set; }
            public Boolean ca2 { get; set; }
            public string reason2 { get; set; }
            public Boolean ca3 { get; set; }
            public string reason3 { get; set; }
        }
    }
}