using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.Camera.Quyetdinh
{
    public class ChonThietBiController : Controller
    {
        [Auther(RightID = "193")]
        [Route("camera/sua-chua")]
        public ActionResult AddSuaChua()
        {
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                ViewBag.room_name = db.Rooms.Select(x => x.room_name).ToList();
                ViewBag.department_name = db.Departments.Select(x => x.department_name).ToList();
            }
            ViewBag.ListSelected = Request["ListSelected"];
            return View("/Views/Camera/Quyetdinh/SuaChua/ChonThietBi.cshtml");
        }

        [Route("camera/sua-chua/search")]
        [HttpPost]
        public ActionResult SearchThem(string room_name, string department_name)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                List<RoomList> rooms = (from r in db.Rooms
                                        join d in db.Departments on r.department_id equals d.department_id
                                        where r.room_name.Contains(room_name) && d.department_name.Contains(department_name) && r.camera_quantity > 0 && r.camera_available < r.camera_quantity
                                        select new RoomList
                                        {
                                            room_id = r.room_id,
                                            room_name = r.room_name,
                                            department_name = d.department_name,
                                            camera_available = r.camera_available,
                                            camera_quantity = r.camera_quantity
                                        }).ToList();

                int totalrows = (from r in db.Rooms
                                 join d in db.Departments on r.department_id equals d.department_id
                                 where r.room_name.Contains(room_name) && d.department_name.Contains(department_name) && r.camera_quantity > 0 && r.camera_available < r.camera_quantity
                                 select r).Count();

                var listSelect = Request["room_id"];
                if (listSelect != null)
                    foreach (RoomList item in rooms)
                    {
                        if (listSelect.Contains(item.room_id.ToString()))
                            item.selected = true;
                        else
                            item.selected = false;
                    }
                return Json(new { success = true, data = rooms, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }

        public class RoomList : Room
        {
            public string department_name { get; set; }
            public bool selected { get; set; }
        }
    }
}