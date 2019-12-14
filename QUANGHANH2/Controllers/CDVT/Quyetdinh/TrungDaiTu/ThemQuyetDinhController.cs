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
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class sctxchonController : Controller
    {
        [Auther(RightID = "95")]
        [Route("phong-cdvt/trung-dai-tu-chon")]
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
                              select new equipmentExtend
                              {
                                  equipmentId = e.equipmentId,
                                  equipment_name = e.equipment_name,
                                  department_name = d.department_name,
                                  department_id = e.department_id,
                                  current_Status = e.current_Status,
                                  statusname = c.statusname,
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
            return View("/Views/CDVT/Work/sctx_va_chon.cshtml");
        }


        [Auther(RightID = "95")]
        [Route("phong-cdvt/trung-dai-tu-chon")]
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
                    documentary.documentary_type = 6;
                    documentary.department_id_to = department_id_to;
                    documentary.date_created = DateTime.Now;
                    documentary.person_created = Session["Name"]+"";
                    documentary.reason = reason;
                    documentary.out_in_come = out_in_come;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        string remodel_type = (string)item.Value["remodel_type"];
                        string equipment_big_maintain_reason = (string)item.Value["equipment_big_maintain_reason"];
                        string datestring = (string)item.Value["end_date"];
                        string next_remodel_type = (string)item.Value["next_remodel_type"];
                        DateTime end_date = DateTime.ParseExact(datestring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        datestring = (string)item.Value["next_end_time"];
                        double next_end_time = 100;
                        Documentary_big_maintain_details drd = new Documentary_big_maintain_details();
                        Equipment e = DBContext.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.equipment_big_maintain_status = 0;
                        drd.remodel_type = remodel_type;
                        drd.equipment_big_maintain_reason = equipment_big_maintain_reason;
                        drd.end_date = end_date;
                        drd.next_remodel_type = next_remodel_type;
                        drd.next_end_time = next_end_time;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_big_maintain_details.Add(drd);
                        DBContext.SaveChanges();
                        JArray dikem = (JArray)item.Value.SelectToken("dikem");
                        foreach (JObject jObject in dikem)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment();
                            sde.documentary_id = documentary.documentary_id;
                            sde.equipmentId = equipmentId;
                            sde.equipmentId_dikem = supply_id;
                            sde.quantity_plan = quantity;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                        JArray duphong = (JArray)item.Value.SelectToken("duphong");
                        foreach (JObject jObject in duphong)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment();
                            sde.documentary_id = documentary.documentary_id;
                            sde.equipmentId = equipmentId;
                            sde.supply_id = supply_id;
                            sde.quantity_plan = quantity;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
             
                        return Redirect("quyet-dinh/trung-dai-tu");
                    
             
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("trung-dai-tu");
                    throw e;
                }
            }
        }
    }
}