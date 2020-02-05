using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.Camera
{
    public class CapNhatTrangThaiController : Controller
    {
        // GET: CapNhatTrangThai
        [Route("camera/cap-nhat")]
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
                return View("/Views/Camera/CapNhatTrangThai.cshtml");
            }
        }

        [Route("camera/cap-nhat")]
        [HttpPost]
        public ActionResult Update()
        {
            try
            {
                QUANGHANHABCEntities db = new QUANGHANHABCEntities();
                db.Configuration.LazyLoadingEnabled = false;
                JArray list = JArray.Parse(Request["list"]);
                foreach (JObject item in list)
                {
                    Room r = db.Rooms.Find((int)item.GetValue("room_id"));
                    r.camera_available = (int)item.GetValue("available");
                    r.disk_status = item.GetValue("disk_status").ToString();
                    r.signal_loss_reason = item.GetValue("signal_loss_reason").ToString();
                    r.note = item.GetValue("note").ToString();
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Cập nhật thành công" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
                throw;
            }
        }
    }
}