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
using System.Drawing;

namespace QUANGHANH2.Controllers.Camera
{
    public class CameraManagementController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/danh-sach")]
        [HttpGet]
        public ActionResult Index()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.departs = db.Departments.ToList().Select(x => new Department { department_id = x.department_id, department_name = x.department_name}).ToList();
                return View("/Views/Camera/DanhSachCamera.cshtml");
            }
        }

        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/danh-sach/photo")]
        [HttpGet]
        public ActionResult GetPhoto()
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    string id = Request["id"];
                    string path = HostingEnvironment.MapPath("/images/camera/" + Request["id"] + ".jfif");
                    using (StreamReader reader = new StreamReader(path))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(path);
                        string file = Convert.ToBase64String(bytes);
                        return Json(new { success = true, base64 = file }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [Auther(RightID = "197")]
        [Route("phong-cdvt/camera/danh-sach/photo")]
        [HttpPost]
        public ActionResult SetPhoto()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Room r = db.Rooms.Find(Request["room_id"]);
                    string path = "/images/camera/";
                    Image sourceimage = Image.FromStream(Request.Files["img"].InputStream, true, true);
                    r.image_link = r.room_id + ".jfif";
                    db.SaveChanges();
                    if (!Directory.Exists(HostingEnvironment.MapPath(path)))
                    {
                        Directory.CreateDirectory(HostingEnvironment.MapPath(path));
                    }
                    if (sourceimage.Size != null)
                    {
                        sourceimage.Save(HostingEnvironment.MapPath(path + r.image_link));
                    }
                    transaction.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Route("camera")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Request["length"] == "-1" ? int.MaxValue : Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string room_name = Request["location"];
            string disk_status = Request["status"];
            string reason = Request["reason"];
            string department = Request["department"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var sql = "select r.*, d.department_name from Room r " + 
                    "inner join Department d on r.department_id = d.department_id " + 
                    "where r.room_name like @room_name and r.disk_status like @disk_status and r.department_id like @department_id and r.camera_quantity != 0";
                if (reason != "")
                    sql += " and r.signal_loss_reason like @signal_loss_reason";
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

        [Auther(RightID = "196")]
        [Route("camera/add")]
        [HttpPost]
        public ActionResult Add()
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                Room r = new Room
                {
                    room_id = Request["id"],
                    capacity = Request["capacity"],
                    disk_status = Request["status"],
                    series = Request["serial"],
                    note = Request["note"],
                    room_name = Request["location"],
                    department_id = Request["department"],
                    camera_quantity = int.Parse(Request["quantity"].ToString()),
                    camera_available = int.Parse(Request["quantity"].ToString()),
                    signal_loss_reason = "",
                    disk_saveable = bool.Parse(Request["saveable"].ToString()),
                    login_information = Request["login"]
                };
                db.Rooms.Add(r);
                db.SaveChanges();
                if (Request.Files["img"] != null)
                {
                    Image sourceimage = Image.FromStream(Request.Files["img"].InputStream, true, true);
                    r.image_link = r.room_id + ".jfif";
                    db.SaveChanges();
                    string path = "/images/camera/";
                    if (!Directory.Exists(HostingEnvironment.MapPath(path)))
                    {
                        Directory.CreateDirectory(HostingEnvironment.MapPath(path));
                    }
                    if (sourceimage.Size != null)
                    {
                        sourceimage.Save(HostingEnvironment.MapPath(path + r.image_link));
                    }
                }
                return Json(new { success = true, message = "Thêm thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }
        [Auther(RightID = "199")]
        [Route("camera/edit")]
        [HttpPost]
        public ActionResult Edit()
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Room r = db.Rooms.Find(Request["room_id"]);
                    r.capacity = Request["capacity"];
                    r.disk_status = Request["status"];
                    r.series = Request["serial"];
                    r.note = Request["note"];
                    r.room_name = Request["location"];
                    r.department_id = Request["department"];
                    r.camera_quantity = int.Parse(Request["quantity"].ToString());
                    r.camera_available = int.Parse(Request["quantity"].ToString());
                    r.signal_loss_reason = "";
                    r.login_information = Request["login"];
                    db.SaveChanges();
                    return Json(new { success = true, message = "Chỉnh sửa thành công" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }

        [Auther(RightID = "198")]
        [Route("camera/delete")]
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Room r = db.Rooms.Find(Request["room_id"]);
                    r.camera_quantity = 0;
                    r.camera_available = 0;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }

        public class camDB : Room
        {
            public string department_name { get; set; }
        }
    }
}