using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.Camera
{
    public class ChuaNghiemThuController : Controller
    {
        public class Documentary_Extend_Cam : Documentary
        {
            public int room_id { get; set; }
            public string room_name { get; set; }
            public string documentary_name { get; set; }
            public int broken_camera_quantity { get; set; }
            public int cameraStatus { get; set; }
        }


        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/Camera/Quyetdinh/ChuaNghiemThu.cshtml");
        }

        [Route("camera/nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string documentary_code, string room_name)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend_Cam> docList = new List<Documentary_Extend_Cam>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string query = @"select d.documentary_id, d.documentary_code, t.documentary_name, r.room_name, r.room_id, detail.broken_camera_quantity, c.cameraStatus
                    from Documentary d 
                    inner join Camera_Acceptance c on d.documentary_id = c.documentary_id
                    inner join Room r on c.room_id = r.room_id
                    inner join DocumentaryType t on d.documentary_type = t.documentary_type
                    inner join Documentary_camera_repair_details detail on detail.room_id = r.room_id
                    where d.documentary_code like @documentary_code and r.room_name like @room_name";
                docList = db.Database.SqlQuery<Documentary_Extend_Cam>(query + " order by " + sortColumnName + " " + sortDirection + " offset " + start + " rows fetch next " + length + " rows only",
                    new SqlParameter("documentary_code", "%" + documentary_code + "%"),
                    new SqlParameter("room_name", "%" + room_name + "%")).ToList();
                int totalrows = db.Database.SqlQuery<int>(query.Replace("d.documentary_id, d.documentary_code, t.documentary_name, r.room_name, r.room_id, detail.broken_camera_quantity, c.cameraStatus", "count(d.documentary_id)"),
                    new SqlParameter("documentary_code", "%" + documentary_code + "%"),
                    new SqlParameter("room_name", "%" + room_name + "%")).FirstOrDefault();

                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }
        [Auther(RightID = "193")]
        [HttpPost]
        [Route("camera/nghiem-thu/Edit")]
        public ActionResult Edit(int room_id, int documentary_id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Camera_Acceptance acceptance = db.Camera_Acceptance.Where(x => x.documentary_id == documentary_id && x.room_id == room_id).FirstOrDefault();
                    acceptance.cameraStatus = 1;
                    acceptance.acceptance_date = DateTime.Now;
                    db.SaveChanges();

                    int acceptanced = db.Database.SqlQuery<Camera_Acceptance>("SELECT * FROM Camera_Acceptance WHERE documentary_id = @documentary_id AND cameraStatus = 1",
                        new SqlParameter("documentary_id", documentary_id)).ToList().Count;

                    int total = db.Database.SqlQuery<Camera_Acceptance>("SELECT * FROM Camera_Acceptance WHERE documentary_id = @documentary_id",
                        new SqlParameter("documentary_id", documentary_id)).ToList().Count;

                    Documentary documentary = db.Documentaries.Find(documentary_id);
                    if (total == acceptanced)
                    {
                        documentary.documentary_status = 3;
                    }

                    Room r = db.Rooms.Find(room_id);
                    Documentary_camera_repair_details detail = db.Database.SqlQuery<Documentary_camera_repair_details>("SELECT * FROM Documentary_camera_repair_details WHERE documentary_id = @documentary_id AND room_id = @room_id",
                        new SqlParameter("room_id", room_id),
                        new SqlParameter("documentary_id", documentary.documentary_id)).FirstOrDefault();
                    r.camera_available += detail.broken_camera_quantity;

                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Nghiệm thu thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    transaction.Rollback();
                    return Json(new { success = false, message = "Nghiệm thu thất bại" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }

}