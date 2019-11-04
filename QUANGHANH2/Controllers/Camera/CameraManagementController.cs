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
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.Camera
{
    public class CameraManagementController : Controller
    {
        [Route("camera")]
        [HttpGet]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Room> listroom = db.Database.SqlQuery<Room>("select * from Room").ToList();
            ViewBag.room = listroom;
            List<Status> liststatus = db.Database.SqlQuery<Status>("select * from Status").ToList();
            ViewBag.status = liststatus;
            return View("/Views/Camera/View.cshtml");
        }

        [Route("camera")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string sql = "select c.*, d.capacity, d.disk_status, d.series, r.room_name, de.department_name, s.statusname " +
                                "from Camera c inner join Disk d on c.camera_id = d.camera_id " +
                                "inner join Room r on c.room_id = r.room_id " +
                                "inner join Department de on r.department_id = de.department_id " +
                                "inner join Status s on c.camera_status = s.statusid";
                var equipList = db.Database.SqlQuery<camDB>(sql).ToList();
                int totalrows = equipList.Count;
                int totalrowsafterfiltering = equipList.Count;
                //sorting
                equipList = equipList.OrderBy(sortColumnName + " " + sortDirection).ToList<camDB>();
                //paging
                equipList = equipList.Skip(start).Take(length).ToList<camDB>();
                List<Department> listDepeartment = db.Departments.ToList<Department>();
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.bolEdit = false;
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Add(string code, string name, string room, string note, string seri, int capacty, string disk_status, string cam_status)
        {
            string sql = "insert into Camera values (@code,@name,@cam_status,@note,@room)";
            string query = "insert into Disk values (@code,@seri,@cap,@disk)";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand(sql, new SqlParameter("code", code)
                                                        , new SqlParameter("name", name)
                                                        , new SqlParameter("cam_status", cam_status)
                                                        , new SqlParameter("note", note)
                                                        , new SqlParameter("room", room));
                    db.Database.ExecuteSqlCommand(query, new SqlParameter("code", code)
                                                        , new SqlParameter("seri", seri)
                                                        , new SqlParameter("cap", capacty)
                                                        , new SqlParameter("disk", disk_status));
                    dbc.Commit();
                    db.SaveChanges();
                    return RedirectToAction("GetData");
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(string code, string name, string room, string note, string seri, int capacty, string disk_status, string cam_status)
        {
            string sql = "update Camera set camera_name = @name, camera_status = @cam_status, room_id = @room, note = @note where camera_id = @code";
            string query = "update Disk set disk_status = @disk, capacity = @cap where series = @seri and camera_id = @code";
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction dbc = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlCommand(sql, new SqlParameter("code", code)
                                                        , new SqlParameter("name", name)
                                                        , new SqlParameter("cam_status", cam_status)
                                                        , new SqlParameter("note", note)
                                                        , new SqlParameter("room", room));
                    db.Database.ExecuteSqlCommand(query, new SqlParameter("code", code)
                                                        , new SqlParameter("seri", seri)
                                                        , new SqlParameter("cap", capacty)
                                                        , new SqlParameter("disk", disk_status));
                    dbc.Commit();
                    db.SaveChanges();
                    return RedirectToAction("GetData");
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    dbc.Rollback();
                    return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public class camDB : Models.Camera
        {
            public string capacity { get; set; }
            public string disk_status { get; set; }
            public string series { get; set; }
            public string room_name { get; set; }
            public string department_name { get; set; }
            public string statusname { get; set; }
        }
    }
}