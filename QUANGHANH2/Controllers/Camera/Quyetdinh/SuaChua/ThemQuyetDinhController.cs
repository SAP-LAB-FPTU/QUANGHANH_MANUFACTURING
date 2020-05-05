using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QUANGHANH2.Controllers.Camera.Quyetdinh.ChonThietBiController;

namespace QUANGHANH2.Controllers.Camera.Quyetdinh.SuaChua
{
    public class ThemQuyetDinhController : Controller
    {
        [Auther(RightID = "193")]
        [Route("camera/sua-chua-chon")]
        [HttpPost]
        public ActionResult Index(string abc)
        {
            var listConvert = abc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var result = (from a in db.Rooms
                              where listConvert.Contains(a.room_id.ToString())
                              join r in db.Rooms on a.room_id equals r.room_id
                              join d in db.Departments on r.department_id equals d.department_id
                              where r.camera_available < r.camera_quantity && r.camera_quantity != 0
                              select new
                              {
                                  a.room_id,
                                  a.room_name,
                                  d.department_name,
                                  r.department_id,
                                  r.camera_available,
                                  r.camera_quantity
                              }).ToList().Select(s => new RoomList
                              {
                                  room_id = s.room_id,
                                  room_name = s.room_name,
                                  department_name = s.department_name,
                                  department_id = s.department_id,
                                  camera_available = s.camera_available,
                                  camera_quantity = s.camera_quantity
                              }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply> supplies = db.Supplies.ToList();
                List<Department> departments = db.Departments.ToList();

                ViewBag.ListSelected = abc;
                ViewBag.Supplies = supplies;
                ViewBag.Departments = departments;
            }
            return View("/Views/Camera/Quyetdinh/SuaChua/ThemQuyetDinh.cshtml");
        }

        [Route("camera/sua-chua-chon/add")]
        [HttpPost]
        public ActionResult GetData(string out_in_come, string data, string department_id, string reason)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary();
                    documentary.documentary_type = 8;
                    documentary.date_created = DateTime.Now;
                    documentary.person_created = Session["Name"] + ""; ;
                    documentary.reason = reason;
                    documentary.out_in_come = out_in_come;
                    documentary.department_id_to = department_id;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string room_id = item.Value["id"].ToString();
                        string repair_requirement = (string)item.Value["repair_requirement"];
                        string datestring = (string)item.Value["finish_date_plan"];

                        Documentary_camera_repair_details drd = new Documentary_camera_repair_details();
                        drd.Documentary_camera_repair_status = 0;
                        drd.documentary_id = documentary.documentary_id;
                        drd.room_id = room_id;
                        drd.broken_camera_quantity = (int)item.Value["broken_camera_quantity"];
                        drd.repair_requirement = repair_requirement;
                        drd.note = (string)item.Value["note"];
                        drd.department_id = (string)item.Value["department_id"];
                        DBContext.Documentary_camera_repair_details.Add(drd);
                        DBContext.SaveChanges();
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            Supply_Documentary_Camera sde = new Supply_Documentary_Camera();
                            sde.documentary_id = documentary.documentary_id;
                            sde.room_id = room_id;
                            sde.supply_id = supply_id;
                            sde.quantity_plan = quantity;
                            DBContext.Supply_Documentary_Camera.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false });
                }
            }
        }
    }
}