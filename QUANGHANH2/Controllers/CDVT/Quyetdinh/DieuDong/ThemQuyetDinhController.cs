using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data.Entity;
using System.Web.SessionState;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    [SessionState(SessionStateBehavior.Default)]
    public class DieudongchonController : Controller
    {
        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            var listConvert = listSelected;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var result = (from e in db.Equipments
                              where listConvert.Contains(e.equipmentId)
                              join d in db.Departments on e.department_id equals d.department_id
                              join c in db.Status on e.current_Status equals c.statusid
                              select new
                              {
                                  equipmentId = e.equipmentId,
                                  equipment_name = e.equipment_name,
                                  department_name = d.department_name,
                                  department_id = e.department_id,
                                  current_Status = e.current_Status,
                                  statusname = c.statusname,
                              }).ToList().Select(s => new equipmentExtend
                              {
                                  equipmentId = s.equipmentId,
                                  equipment_name = s.equipment_name,
                                  department_name = s.department_name,
                                  department_id = s.department_id,
                                  current_Status = s.current_Status,
                                  statusname = s.statusname,

                              }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply> supplies = db.Supplies.ToList();
                List<Department> departments = db.Departments.ToList();
                List<Equipment> equipAttached = db.Equipments.Where(x => x.isAttach == true).ToList().Select(x => new Equipment
                {
                    equipmentId = x.equipmentId,
                    equipment_name = x.equipment_name
                }).ToList();
                ViewBag.Supplies = supplies;
                ViewBag.Departments = departments;
                ViewBag.equipAttached = equipAttached;
            }
            return View("/Views/CDVT/Work/dieu_dong_va_chon.cshtml");
        }

        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon")]
        [HttpPost]
        public ActionResult GetData(string out_in_come, string data, string department_id, string reason)
        {
            string department_id_to = Request["department_id_to"];
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary();
                    documentary.documentary_type = 3;
                    documentary.department_id_to = department_id_to;
                    documentary.date_created = DateTime.Now;
                    documentary.person_created = Session["Name"] + "";
                    documentary.reason = reason;
                    documentary.out_in_come = out_in_come;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        string department_detail = (string)item.Value["department_detail"];
                        string equipment_moveline_reason = (string)item.Value["equipment_moveline_reason"];
                        string datestring = (string)item.Value["date_to"];
                        DateTime date_to = DateTime.ParseExact(datestring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Documentary_moveline_details drd = new Documentary_moveline_details();
                        Equipment e = DBContext.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.equipment_moveline_status = 0;
                        drd.department_detail = department_detail;
                        drd.date_to = date_to;
                        drd.equipment_moveline_reason = equipment_moveline_reason;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_moveline_details.Add(drd);
                        DBContext.SaveChanges();
                        JArray dikem = (JArray)item.Value.SelectToken("dikem");
                        foreach (JObject jObject in dikem)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            string supplyStatus = (string)jObject["supplyStatus"];
                            string department_id_temp = (string)jObject["department_id"];
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment();
                            sde.documentary_id = documentary.documentary_id;
                            sde.equipmentId = equipmentId;
                            sde.equipmentId_dikem = supply_id;
                            sde.quantity_plan = quantity;
                            sde.supplyStatus = supplyStatus;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                        JArray duphong = (JArray)item.Value.SelectToken("duphong");
                        foreach (JObject jObject in duphong)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            string supplyStatus = (string)jObject["supplyStatus"];
                            string department_id_temp = (string)jObject["department_id"];
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment();
                            sde.documentary_id = documentary.documentary_id;
                            sde.equipmentId = equipmentId;
                            sde.supply_id = supply_id;
                            sde.quantity_plan = quantity;
                            sde.supplyStatus = supplyStatus;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();

                        return Redirect("quyet-dinh/dieu-dong");
                                   
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("dieu-dong");
                    throw e;
                
                }
            }
        }
    }
}