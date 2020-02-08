using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Threading;
using System.IO;
using System.Web.Hosting;
using OfficeOpenXml;
using System.Data.SqlClient;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.Camera
{
    public class TrangChuController : Controller
    {
        private class DashCam
        {
            public int sum { get; set; }
            public int done { get; set; }
            public int notdone { get; set; }

        }

        private class DashRoom
        {
            public int daydu { get; set; }
            public int kodaydu { get; set; }
            public int ko { get; set; }
        }
        [Route("camera/trang-chu")]
        public ActionResult Index()
        {
            DateTime d = DateTime.Today;
            ViewBag.today = d.ToString("MM yyyy");
            string query = @"select COUNT(ci.incident_id) as 'sum', SUM(case when ci.end_time is not null  then 1 else  0 end) as 'done'
                            from CameraIncident ci
                            where MONTH(ci.start_time) = @month and YEAR(ci.start_time) = @year";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            DashCam dc = db.Database.SqlQuery<DashCam>(query, new SqlParameter("month", d.Month), new SqlParameter("year", d.Year)).FirstOrDefault();
            dc.notdone = dc.sum - dc.done;
            ViewBag.dc = dc;

            string query2 = @"select SUM(case when r.camera_available = r.camera_quantity then 1 else 0 end) as 'daydu',
	                            SUM(case when r.camera_available < r.camera_quantity and r.camera_available > 0 then 1 else 0 end) as 'kodaydu',
	                            SUM(case when r.camera_available = 0 then 1 else 0 end) as 'ko'
                            from Room r";
            DashRoom dr = db.Database.SqlQuery<DashRoom>(query2).FirstOrDefault();
            ViewBag.dr = dr;
            return View("/Views/Camera/TrangChu.cshtml");
        }

        //[Route("camera/changedate")]
        [HttpPost]
        public ActionResult ChangeDate(string date)
        {
            string[] d = date.Split(' ');
            string query = @"select COUNT(ci.incident_id) as 'sum', case when SUM(case when ci.end_time is not null then 1 else 0 end) is null then 0 else SUM(case when ci.end_time is not null then 1 else 0 end) end  as 'done'
                            from CameraIncident ci
                            where MONTH(ci.start_time) = @month and YEAR(ci.start_time) = @year";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            DashCam dc = db.Database.SqlQuery<DashCam>(query, new SqlParameter("month", d[1]), new SqlParameter("year", d[2])).FirstOrDefault();
            dc.notdone = dc.sum - dc.done;
            return Json(new { success = true, message = "", dc = dc }, JsonRequestBehavior.AllowGet);
        }

        private class RoomThongKe
        {
            public string room_name { get; set; }
            public string department_name { get; set; }
            public int camera_available { get; set; }
            public int camera_quantity { get; set; }
        }
        [Route("camera/getList")]
        [HttpPost]
        public ActionResult getList(string type)
        {
            string query = @"select r.room_name, d.department_name, r.camera_available, r.camera_quantity
                                from Room r join Department d on r.department_id = d.department_id";
            if(type.Equals("Hoạt động không đầy đủ"))
            {
                query += " where r.camera_available < r.camera_quantity and r.camera_available > 0";
            } else if (type.Equals("Hoạt động đầy đủ"))
            {
                query += " where r.camera_available = r.camera_quantity";
            } else if(type.Equals("Không hoạt động"))
            {
                query += " where r.camera_available = 0";
            }
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<RoomThongKe> list = db.Database.SqlQuery<RoomThongKe>(query).ToList();
            return Json(new { success = true, message = "", listDB = list}, JsonRequestBehavior.AllowGet);
        }
    }
}