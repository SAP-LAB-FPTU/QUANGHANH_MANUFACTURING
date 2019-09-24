using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{

    public class LylichController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/thiet-bi")]
        public ActionResult Index()
        {
            return Redirect("/phong-cdvt/huy-dong");
        }

        [Route("phong-cdvt/thiet-bi")]
        [HttpPost]
        public ActionResult ABC(string id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //NK su co
            var years = DBContext.Database.SqlQuery<int>("SELECT distinct year(i.start_time) as years FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' order by years desc").ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                var dates = DBContext.Database.SqlQuery<DateTime>("SELECT distinct i.start_time as dates FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and year(start_time) = '" + year + "' order by dates desc").ToList();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT d.department_name, " +
                        "i.* FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                        "on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and start_time = '" + date + "' and year(start_time) = '" + year + "' order by start_time desc").ToList();
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
            //NK dieu dong
            var yearDD = DBContext.Database.SqlQuery<int>("SELECT distinct year(d.date_created) as years FROM Documentary d, Documentary_moveline_details dm, Equipment e where e.equipmentId = '" + id + "' and e.equipmentId = dm.equipmentId and dm.documentary_id = d.documentary_id order by years desc").ToList<int>();
            List<moveLineByYear> listDD = new List<moveLineByYear>();
            foreach (int year in yearDD)
            {
                List<myMoveline> listMML = DBContext.Database.SqlQuery<myMoveline>("select dm.equipmentId, dm.date_to,dm.department_detail,d.department_id,d.person_created,dm.documentary_id,d.reason,d.date_created from Equipment e, Documentary_moveline_details dm, Documentary d where e.equipmentId = dm.equipmentId and d.documentary_id = dm.documentary_id and dm.equipmentId = '" + id + "' and YEAR(d.date_created) = '" + year + "' ").ToList();
                moveLineByYear MLY = new moveLineByYear();
                foreach(var x in listMML)
                {
                    string s = toStringDate(x.date_created);
                    x.date = s;
                }
                MLY.listmoveline = listMML;
                MLY.year = year;
                MLY.count = listMML.Count();
                listDD.Add(MLY);
            }
            ViewBag.listDD = listDD;
            //NK sua chua
            return View("/Views/CDVT/Thietbi/Lylich.cshtml");
        }



        public string toStringDate(DateTime date)
        {
            string data = date.ToString("dddd-dd-MM");
            string[] words = data.Split('-');
            string result = "";
            switch(words[0])
            {
                case "Monday": result += "Thứ 2";break;
                case "Tuesday": result += "Thứ 3";break;
                case "Wednesday": result += "Thứ 4";break;
                case "Thursday": result += "Thứ 5";break;
                case "Friday": result += "Thứ 6";break;
                case "Saturday": result += "Thứ 7";break;
                case "Sunday": result += "Chủ nhật";break;
            }
            result += ", ngày " + words[1] + ", tháng " + words[2];
            return result;
        }


    }

    public class moveLineByYear
    {
        public List<myMoveline> listmoveline { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
    public class myMoveline : Documentary_moveline_details
    {
        public string person_created { get; set; }
        public System.DateTime date_created { get; set; }
        public string reason { get; set; }
        public string department_id { get; set; }
        public string date { get; set; }
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

    public class IncidentDB
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public string department_name { get; set; }
        public DateTime start_time { get; set; }
        public Nullable<DateTime> end_time { get; set; }
        public string reason { get; set; }
        public string incident_type { get; set; }
        public int incident_id { get; set; }
    }
}