using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    [Route("phong-cdvt/thiet-bi")]
    public class LylichController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Redirect("/phong-cdvt/huy-dong");
        }

        [HttpPost]
        public ActionResult ABC(string id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            var years = DBContext.Database.SqlQuery<int>("SELECT distinct year(i.start_time) as years FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' order by years desc").ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                List<string> listtemp = DBContext.Database.SqlQuery<string>("SELECT distinct CONCAT(YEAR(i.start_time),'/',MONTH(i.start_time),'/',DAY(i.start_time)) as dates FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and year(start_time) = '" + year + "' order by dates desc").ToList();
                List<DateTime> dates = listtemp.Select(date => DateTime.Parse(date)).ToList<DateTime>();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT d.department_name, " +
                        "i.* FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                        "on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and DAY(start_time) = '" + date.Day + "' and MONTH(start_time) = '" + date.Month + "' and year(start_time) = '" + year + "' order by start_time desc").ToList();
                    count += tempdate.incidents.Count;
                    listbydate.Add(tempdate);
                }
                tempyear.year = year;
                tempyear.IncidentByDates = listbydate;
                tempyear.count = count;
                listbyyear.Add(tempyear);
            }
            ViewBag.incidents = listbyyear;
            var equipment = DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE Equipment.equipmentId = '" + id + "'").First();
            ViewBag.equipment = equipment;
            return View("/Views/CDVT/Thietbi/Lylich.cshtml");
        }

    }

    public class IncidentByDate
    {
        public List<IncidentDB> incidents { get; set; }
        public DateTime date { get; set; }
    }

    public class IncidentByYear
    {
        public int year { get; set; }
        public List<IncidentByDate> IncidentByDates { get; set; }
        public int count { get; set; }
    }

    public class IncidentDB : Incident
    {
        public string equipment_name { get; set; }
        public string department_name { get; set; }
    }
}