using QUANGHANH2.EntityResult;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.Camera
{
    public class CameraManagementController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/danh-sach")]
        [HttpGet]
        public ActionResult Index()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ViewBag.departs = db.Departments.ToList().Select(x => new Department { department_id = x.department_id, department_name = x.department_name }).ToList();
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
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
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
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            string room_name = Request["location"];
            string disk_status = Request["status"];
            string reason = Request["reason"];
            string department = Request["department"];

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                //var equipList = db.Database.SqlQuery<GetListCamera_Result>("Camera.Get_List_Camera {0}, {1}, {2}, {3} ,{4}, {5}, {6}, {7}", 
                //    room_name, disk_status, reason, department, sortColumnName, sortDirection, start, length ).ToList();
                var equipList = (from r in db.Rooms
                                 join d in db.Departments on r.department_id equals d.department_id
                                 where r.room_name.Contains(room_name)
                                 && r.disk_status.Contains(disk_status)
                                 && (string.IsNullOrEmpty(reason) ? true : r.signal_loss_reason.Contains(reason))
                                 && r.department_id.Contains(department)
                                 select new GetListCamera_Result
                                 {
                                     camera_available = r.camera_available,
                                     camera_quantity = r.camera_quantity,
                                     department_id = r.department_id,
                                     capacity = r.capacity,
                                     department_name = d.department_name,
                                     disk_saveable = r.disk_saveable,
                                     disk_status = r.disk_status,
                                     image_link = r.image_link,
                                     login_information = r.login_information,
                                     note = r.note,
                                     room_id = r.room_id,
                                     room_name = r.room_name,
                                     series = r.series,
                                     signal_loss_reason = r.signal_loss_reason
                                 }).OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
                int totalrows = db.Database.SqlQuery<int>("Camera.Get_Count_Camera {0}, {1}, {2}, {3}",
                    room_name, disk_status, department, reason).FirstOrDefault();
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
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
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
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("delete from Room where room_id = @room_id", new SqlParameter("room_id", Request["room_id"]));
                    return Json(new { success = true, message = "Xóa thành công" });
                }
                catch (Exception)
                {
                    Room r = db.Rooms.Find(Request["room_id"]);
                    if (r != null)
                    {
                        r.camera_quantity = 0;
                        r.camera_available = 0;
                        db.SaveChanges();
                    }
                    return Json(new { success = true, message = "Xóa thành công" });
                }
            }
        }
    }
}