using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.Camera
{
    public class CapNhatTheoCaController : Controller
    {
        [Auther(RightID = "203")]
        [Route("phong-cdvt/camera/cap-nhat")]
        public ActionResult Index()
        {
            return View("/Views/Camera/CapNhatTheoCa.cshtml");
        }

        [Route("phong-cdvt/camera/cap-nhat")]
        [HttpPost]
        public ActionResult GetData(string stringDate)
        {
            //Server Side Parameter
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", null);

            int session = 0;
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 15 && DateTime.Now.Date == date) session = 1;
            if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 23 && DateTime.Now.Date == date) session = 2;
            if ((DateTime.Now.Hour >= 23 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 7 && DateTime.Now.Date.AddDays(-1) == date)) session = 3;

            string varname1 = @"select e.room_id, e.room_name, d.department_name, e.ca1, e.ca2, e.ca3 from
	            (select a.room_id, a.room_name, a.department_id, a.ca1, b.ca2, c.ca3 from   
		            (select r.room_id, r.room_name, r.department_id, rs.[session], rs.[fully_function] as ca1
		            from Room r left join Room_Status rs on r.room_id = rs.room_id   
		            where rs.[date] = @date and rs.[session] = 1) as a left join   
		            (select r.room_id, r.room_name, r.department_id, rs.[session], rs.[fully_function] as ca2
		            from Room r left join Room_Status rs on r.room_id = rs.room_id   
		            where rs.[date] = @date and rs.[session] = 2) as b on a.room_id = b.room_id   
		            left join   
		            (select r.room_id, r.room_name, r.department_id, rs.[session], rs.[fully_function] as ca3
		            from Room r left join Room_Status rs on r.room_id = rs.room_id   
		            where rs.[date] = @date and rs.[session] = 3) as c on b.room_id = c.room_id
	            ) as e
			            inner join Department as d on d.department_id = e.department_id";
            List<RoomDB> list = DBContext.Database.SqlQuery<RoomDB>(varname1,
                new SqlParameter("date", date)).ToList();
            if (!list.Any())
            {
                list = DBContext.Database.SqlQuery<RoomDB>("select r.room_id, r.room_name, d.department_name from Room r inner join Department d on r.department_id = d.department_id").ToList();
                foreach (RoomDB item in list)
                {
                    item.ca1 = true;
                    item.ca2 = true;
                    item.ca3 = true;
                }
            }
            int totalrows = list.Count;
            int totalrowsafterfiltering = list.Count;
            //sorting
            list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<RoomDB>();
            //paging
            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering, session = session });
        }

        [Auther(RightID = "204")]
        [Route("phong-cdvt/camera/cap-nhat/Update")]
        [HttpPost]
        public ActionResult Update(string stringjson)
        {
            bool redirect = false;
            JObject jObject = JObject.Parse(stringjson);
            DateTime date = DateTime.ParseExact((string)jObject["date"], "dd/MM/yyyy", null);
            int thisCa = 0;
            if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour < 15 && DateTime.Now.Date == date) thisCa = 1;
            if (DateTime.Now.Hour >= 15 && DateTime.Now.Hour < 23 && DateTime.Now.Date == date) thisCa = 2;
            if ((DateTime.Now.Hour >= 23 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 7 && DateTime.Now.Date.AddDays(-1) == date)) thisCa = 3;

            if (thisCa == 0)
                return Json(new { success = false, message = "Không được cập nhật ca này" });

            JArray jArray = (JArray)jObject["list"];
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (JObject item in jArray)
                    {
                        //Ca 1: 6h-14h
                        //Ca 2: 14h-22h
                        //Ca 3: 22h-6h
                        int equipmentId = (int)item["equipmentId"];
                        int ca = (int)item["ca"];

                        if (thisCa != ca)
                            continue;

                        bool available = (bool)item["available"];

                        if (redirect == false && available == false)
                            redirect = true;

                        Room_Status rs = DBContext.Room_Status.Find(equipmentId, date, ca);
                        if (rs == null)
                        {
                            rs = new Room_Status();
                            rs.fully_function = available ? true : false;
                            rs.date = date;
                            rs.room_id = equipmentId;
                            rs.session = ca;
                            DBContext.Room_Status.Add(rs);
                        }
                        else
                        {
                            rs.fully_function = available ? true : false;
                        }
                        DBContext.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
            return Json(new { success = true, message = "Cập nhật thành công", redirect = redirect });
        }

        private class RoomDB
        {
            public int room_id { get; set; }
            public string room_name { get; set; }
            public string department_name { get; set; }
            public Nullable<Boolean> ca1 { get; set; }
            public Nullable<Boolean> ca2 { get; set; }
            public Nullable<Boolean> ca3 { get; set; }
        }
    }
}