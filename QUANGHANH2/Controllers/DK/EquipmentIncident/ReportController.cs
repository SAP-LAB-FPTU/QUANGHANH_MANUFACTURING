using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.EquipmentIncident
{
    public class ReportController : Controller
    {
        //[Auther(RightID = "19")]
        [Route("phong-dieu-khien/su-co/bao-cao")]
        public ActionResult Index()
        {
            var type = new[] { "month", "quarter", "year" }.Contains(Request["type"]) ? Request["type"] : "month";
            int year = Request["year"] == null ? DateTime.Now.Year : int.Parse(Request["year"]);
            var sql = @"select d.department_id, department_name, (case when total is null then 0 else total end) as total
                        from Department d left join 
	                        (select 
		                        department_id, count(*) as total 
		                        from Incident where year(start_time) = " + year;
            switch (type)
            {
                case "month":
                    int month = Request["month"] == null ? DateTime.Now.Month : int.Parse(Request["month"]);
                    sql += " and month(start_time) = " + month;
                    break;
                case "quarter":
                    int quarter = Request["quarter"] == null ? 1 : int.Parse(Request["quarter"]);
                    sql += " and month(start_time) between " + (quarter * 3 - 2) + " and " + (quarter * 3);
                    break;
                default:
                    break;
            }
            sql += @" group by department_id
	                        ) as i on d.department_id = i.department_id
                        where d.department_type like N'%phân xưởng%'";
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var list = db.Database.SqlQuery<Report>(sql).ToList();
                ViewBag.list = list;
            }
            return View("/Views/DK/EquipmentIncident/Report.cshtml");
        }

        public class Report
        {
            public string department_id { get; set; }
            public string department_name { get; set; }
            public int total { get; set; }
        }
    }
}