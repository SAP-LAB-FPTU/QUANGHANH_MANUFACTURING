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
            string varname1 = ""
            + "select a.equipmentId, a.equipment_name,a.ca1, a.reason1, b.ca2, b.reason2, c.ca3, c.reason3 from " + "\n"
            + "(select e.equipmentId, e.equipment_name, c.[session], c.available as \"ca1\", c.reason as \"reason1\" " + "\n"
            + "from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId " + "\n"
            + "where c.[date] = @date and c.[session] = 1) as a left join " + "\n"
            + "(select e.equipmentId, e.equipment_name, c.[session], c.available as \"ca2\", c.reason as \"reason2\" " + "\n"
            + "from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId " + "\n"
            + "where c.[date] = @date and c.[session] = 2) as b on a.equipmentId = b.equipmentId " + "\n"
            + "left join " + "\n"
            + "(select e.equipmentId, e.equipment_name, c.[session], c.available as \"ca3\", c.reason as \"reason3\" " + "\n"
            + "from Equipment e left join CarGPS c on e.equipmentId = c.equipmentId " + "\n"
            + "where c.[date] = @date and c.[session] = 3) as c on b.equipmentId = c.equipmentId";
            List<CarGPSDB> list = DBContext.Database.SqlQuery<CarGPSDB>(varname1,
                new SqlParameter("date", date)).ToList();
            if (!list.Any())
            {
                list = DBContext.Database.SqlQuery<CarGPSDB>("SELECT e.equipmentId, e.equipment_name FROM Equipment e inner join Car c on e.equipmentId = c.equipmentId").ToList();
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
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
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
            try
            {
                using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                {
                    foreach (JObject item in jArray)
                    {
                        string equipmentId = (string)item["equipmentId"];
                        int ca = (int)item["ca"];
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
                        DBContext.SaveChanges();
                    }
                    transaction.Commit();
                }
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
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
    }

    public class CarGPSDB
    {
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
        public Boolean ca1 { get; set; }
        public string reason1 { get; set; }
        public Boolean ca2 { get; set; }
        public string reason2 { get; set; }
        public Boolean ca3 { get; set; }
        public string reason3 { get; set; }
    }
}