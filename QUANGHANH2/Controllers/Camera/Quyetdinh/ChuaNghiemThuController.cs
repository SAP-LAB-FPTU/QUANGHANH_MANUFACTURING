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
using System.Data.SqlTypes;

namespace QUANGHANH2.Controllers.Camera
{
    public class ChuaNghiemThuController : Controller
    {
        public class Documentary_Extend_Cam : Documentary
        {
            public string room_id { get; set; }
            public string room_name { get; set; }
            public string documentary_name { get; set; }
            public int acceptance_camera_quantity { get; set; }
            public string string_created { get; set; }
            public string string_acceptance { get; set; }
            public DateTime? acceptance_date { get; set; }
            public bool QDQT { get; set; }
        }

        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/Camera/Quyetdinh/ChuaNghiemThu.cshtml");
        }

        [Route("camera/nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string documentary_code, string room_name, string dateStart)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            DateTime dtStart_0 = new DateTime();
            DateTime dtStart_1 = new DateTime();

            if (dateStart != null && dateStart.Contains("-"))
            {
                var temp = dateStart.Split('-');
                dtStart_0 = DateTime.ParseExact(temp[0].Trim(), "dd/MM/yyyy", null);
                dtStart_1 = DateTime.ParseExact(temp[1].Trim(), "dd/MM/yyyy", null).AddDays(1);
            }
            else if (!string.IsNullOrEmpty(dateStart))
            {
                dtStart_0 = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
                dtStart_1 = dtStart_0.AddDays(1);
            }

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var docList = (from d in db.Documentaries
                               join c in db.Acceptances on d.documentary_id equals c.documentary_id
                               join r in db.Rooms on c.room_id equals r.room_id
                               join t in db.DocumentaryTypes on d.documentary_type equals t.documentary_type
                               join a in db.Important_Documentary on d.documentary_id equals a.documentary_id into docs
                               from i in docs.DefaultIfEmpty()
                               where d.documentary_code.Contains(documentary_code)
                               && r.room_name.Contains(room_name)
                               && (string.IsNullOrEmpty(dateStart) || (c.acceptance_date >= dtStart_0 && c.acceptance_date < dtStart_1))
                               select new Documentary_Extend_Cam
                               {
                                   documentary_id = d.documentary_id,
                                   documentary_code = d.documentary_code,
                                   documentary_name = t.documentary_name,
                                   room_name = r.room_name,
                                   room_id = r.room_id,
                                   acceptance_camera_quantity = c.acceptance_camera_quantity,
                                   date_created = d.date_created,
                                   acceptance_date = c.acceptance_date,
                                   person_created = d.person_created,
                                   QDQT = i != null
                               }).ToList();

                foreach (var item in docList)
                {
                    item.string_created = item.date_created.ToString("dd/MM/yyyy");
                    item.string_acceptance = item.acceptance_date == null ? "" : item.acceptance_date.Value.ToString("dd/MM/yyyy");
                }

                int totalrows = (from d in db.Documentaries
                                 join c in db.Acceptances on d.documentary_id equals c.documentary_id
                                 join r in db.Rooms on c.room_id equals r.room_id
                                 join t in db.DocumentaryTypes on d.documentary_type equals t.documentary_type
                                 where d.documentary_code.Contains(documentary_code)
                                 && r.room_name.Contains(room_name)
                                 && (string.IsNullOrEmpty(dateStart) || (c.acceptance_date >= dtStart_0 && c.acceptance_date < dtStart_1))
                                 select c).Count();

                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows });
            }
        }

        [Auther(RightID = "193")]
        [HttpPost]
        [Route("camera/nghiem-thu/Edit")]
        public ActionResult Edit(string room_id, int documentary_id)
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Acceptance acceptance = db.Acceptances.Where(x => x.documentary_id == documentary_id && x.room_id == room_id).FirstOrDefault();
                    if (acceptance != null && acceptance.acceptance_date != null)
                        return Json(new { success = false, message = "Thiết bị đã được nghiệm thu" });

                    acceptance.acceptance_date = DateTime.Now;
                    db.SaveChanges();

                    int acceptance_left = db.Acceptances.Where(x => x.documentary_id == documentary_id && x.acceptance_date != null).Count();

                    if (acceptance_left == 0)
                    {
                        Documentary documentary = db.Documentaries.Find(documentary_id);
                        documentary.documentary_status = 3;
                    }

                    Room r = db.Rooms.Find(room_id);
                    CameraRepairDetail detail = db.CameraRepairDetails.Where(x => x.documentary_id == documentary_id && x.room_id == room_id).FirstOrDefault();
                    r.camera_available += detail.broken_camera_quantity;

                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Nghiệm thu thành công" });
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    transaction.Rollback();
                    return Json(new { success = false, message = "Nghiệm thu thất bại" });
                }
            }
        }

        [Auther(RightID = "193")]
        [HttpPost]
        [Route("phong-cdvt/camera/nghiem-thu/getProfile")]
        public ActionResult getProfile(int documentary_id)
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                var temp = (from doc in db.Documentaries
                            join depa in db.Departments on doc.department_id_to equals depa.department_id
                            where doc.documentary_id.Equals(documentary_id)
                            select new
                            {
                                doc.documentary_code,
                                doc.reason,
                                doc.out_income,
                                depa.department_name
                            }).FirstOrDefault();
                return Json(temp);
            }
        }
    }
}