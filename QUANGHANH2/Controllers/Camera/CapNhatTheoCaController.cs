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
using QUANGHANH2.EntityResult;

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

            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            DateTime date = DateTime.ParseExact(stringDate, "dd/MM/yyyy", null);

            int session = 0;
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14 && DateTime.Now.Date == date) session = 1;
            if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 22 && DateTime.Now.Date == date) session = 2;
            if ((DateTime.Now.Hour >= 22 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 6 && DateTime.Now.Date.AddDays(-1) == date)) session = 3;

            List<GetListStatus_Result> list = db.Database.SqlQuery<GetListStatus_Result>("Camera.Get_List_Status {0}", date).ToList();
            if (DateTime.Compare(date, DateTime.Now.Date) == 0)
            {
                list = list.Where(x => !(x.camera_quantity == 0 && x.ca1 == null && x.ca2 == null && x.ca3 == null)).ToList();
            }
            int totalrows = list.Count;

            list = list.OrderBy(sortColumnName + " " + sortDirection).ToList();

            return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, session });
        }

        [Auther(RightID = "204")]
        [Route("phong-cdvt/camera/cap-nhat/Update")]
        [HttpPost]
        public ActionResult Update(string stringjson)
        {
            bool redirect = false;
            JObject jObject = JObject.Parse(stringjson);
            DateTime date = DateTime.ParseExact((string)jObject["date"], "dd/MM/yyyy", null);
            int session = 0;
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour < 14 && DateTime.Now.Date == date) session = 1;
            if (DateTime.Now.Hour >= 14 && DateTime.Now.Hour < 22 && DateTime.Now.Date == date) session = 2;
            if ((DateTime.Now.Hour >= 22 && DateTime.Now.Date == date) || (DateTime.Now.Hour < 6 && DateTime.Now.Date.AddDays(-1) == date)) session = 3;

            if (session == 0)
                return Json(new { success = false, message = "Không được cập nhật ca này" });

            JArray jArray = (JArray)jObject["list"];
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (JObject item in jArray)
                    {
                        //Ca 1: 6h-14h
                        //Ca 2: 14h-22h
                        //Ca 3: 22h-6h
                        string equipmentId = item["equipmentId"].ToString();
                        int ca = (int)item["ca"];

                        if (session != ca)
                            continue;

                        bool available = (bool)item["available"];

                        if (redirect == false && available == false)
                            redirect = true;

                        Status rs = DBContext.Status.Find(equipmentId, date, ca);
                        if (rs == null)
                        {
                            rs = new Status
                            {
                                fully_function = available,
                                date = date,
                                room_id = equipmentId,
                                session = ca
                            };
                            DBContext.Status.Add(rs);
                        }
                        else
                        {
                            rs.fully_function = available;
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
            return Json(new { success = true, message = "Cập nhật thành công", redirect });
        }
    }
}