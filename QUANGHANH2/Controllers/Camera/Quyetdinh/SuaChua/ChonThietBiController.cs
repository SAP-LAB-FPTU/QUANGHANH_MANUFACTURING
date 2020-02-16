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
            ViewBag.ListSelected = Request["ListSelected"];
            return View("/Views/Camera/Sua_chua_camera.cshtml");
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

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string query = "select r.room_id, r.room_name, d.department_name, r.camera_available, r.camera_quantity " +
                    "from Room r inner join Department d on r.department_id = d.department_id " +
                    "where r.room_name like @room_name and d.department_name like @department_name";
                List<RoomList> rooms = db.Database.SqlQuery<RoomList>(query + " order by " + sortColumnName + " " + sortDirection + " offset " + start + " rows fetch next " + length + "rows only",
                    new SqlParameter("room_name", '%' + room_name + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).ToList();

                int totalrows = db.Database.SqlQuery<int>(query.Replace("r.room_id, r.room_name, d.department_name, r.camera_available, r.camera_quantity", "count(r.room_id)"),
                    new SqlParameter("room_name", '%' + room_name + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).FirstOrDefault();

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