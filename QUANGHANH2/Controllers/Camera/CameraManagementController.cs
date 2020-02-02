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
    public class CameraManagementController : Controller
    {
        [Route("camera/export")]
        [HttpPost]
        public void Export()
        {
            string path = HostingEnvironment.MapPath("/excel/Camera/");
            string filename = "camera-temp.xlsx";
            FileInfo file = new FileInfo(path + filename);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorkbook excelWorkbook = excelPackage.Workbook;
                ExcelWorksheet excelWorksheet = excelWorkbook.Worksheets.First();

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {

                    string sql = "select c.*, d.capacity, d.disk_status, d.series, r.room_name, de.department_name, s.statusname " +
                                "from Camera c inner join Disk d on c.camera_id = d.camera_id " +
                                "inner join Room r on c.room_id = r.room_id " +
                                "inner join Department de on r.department_id = de.department_id " +
                                "inner join Status s on c.camera_status = s.statusid";
                    var equipList = db.Database.SqlQuery<camDB>(sql).ToList();
                    int k = 3;
                    for (int i = 0; i < equipList.Count; i++)
                    {
                        excelWorksheet.Cells[k, 1].Value = equipList.ElementAt(i).room_id;
                        excelWorksheet.Cells[k, 2].Value = equipList.ElementAt(i).camera_available;
                        excelWorksheet.Cells[k, 3].Value = equipList.ElementAt(i).room_name;
                        excelWorksheet.Cells[k, 4].Value = equipList.ElementAt(i).series;
                        excelWorksheet.Cells[k, 5].Value = equipList.ElementAt(i).capacity;
                        excelWorksheet.Cells[k, 6].Value = equipList.ElementAt(i).disk_status;
                        //excelWorksheet.Cells[k, 7].Value = equipList.ElementAt(i).statusname;
                        excelWorksheet.Cells[k, 8].Value = equipList.ElementAt(i).note;
                        k++;
                    }
                    excelPackage.SaveAs(new FileInfo(HostingEnvironment.MapPath("/excel/Camera/Download/camera-temp-download.xlsx")));
                }
            }
        }

        [Auther(RightID = "193")]
        [Route("camera")]
        [HttpGet]
        public ActionResult Index()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.departs = (from d in db.Departments
                                   select new
                                   {
                                       department_id = d.department_id,
                                       department_name = d.department_name
                                   }).ToList().Select(x => new Department
                                   {
                                       department_id = x.department_id,
                                       department_name = x.department_name
                                   }).ToList();
                return View("/Views/Camera/DanhSachCamera.cshtml");
            }
        }

        [Route("camera")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string room_name = Request["location"];
            string disk_status = Request["status"];
            string reason = Request["reason"];
            string department = Request["department"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var sql = "select r.*, d.department_name from Room r inner join Department d on r.department_id = d.department_id where r.room_name like @room_name and r.disk_status like @disk_status and r.signal_loss_reason like @signal_loss_reason and r.department_id like @department_id";
                var equipList = db.Database.SqlQuery<camDB>(sql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("room_name", '%' + room_name + '%'),
                    new SqlParameter("disk_status", '%' + disk_status + '%'),
                    new SqlParameter("department_id", '%' + department + '%'),
                    new SqlParameter("signal_loss_reason", '%' + reason + '%')).ToList();
                int totalrows = db.Database.SqlQuery<int>(sql.Replace("r.*, d.department_name", "count(*)"),
                    new SqlParameter("room_name", '%' + room_name + '%'),
                    new SqlParameter("disk_status", '%' + disk_status + '%'),
                    new SqlParameter("department_id", '%' + department + '%'),
                    new SqlParameter("signal_loss_reason", '%' + reason + '%')).FirstOrDefault();
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auther(RightID = "193")]
        [Route("camera/add")]
        [HttpPost]
        public ActionResult Add()
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                Room r = new Room();
                r.capacity = Request["capacity"];
                r.disk_status = Request["status"];
                r.series = Request["serial"];
                r.note = Request["note"];
                r.room_name = Request["location"];
                r.department_id = Request["department"];
                r.camera_quantity = int.Parse(Request["quantity"].ToString());
                r.camera_available = int.Parse(Request["quantity"].ToString());
                r.signal_loss_reason = "";
                db.Rooms.Add(r);
                db.SaveChanges();
                return Json(new { success = true, message = "Thêm thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }
        [Auther(RightID = "193")]
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

        private class camDB : Models.Room
        {
            public string department_name { get; set; }
        }
    }
}