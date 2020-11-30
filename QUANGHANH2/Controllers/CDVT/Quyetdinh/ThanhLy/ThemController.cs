using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class ThanhlychonController : Controller
    {
        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            var listConvert = listSelected;
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
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
                try
                {
                    int validate = 1;
                    var department_id = result[0].department_id;
                    foreach (var item in result)
                    {
                        if (!item.department_id.Equals(department_id))
                        {
                            validate = 0;
                            break;
                        }
                    }
                    Department department = db.Departments.Find(department_id);
                    ViewBag.validate = validate;
                    ViewBag.department_name = department.department_name;
                    ViewBag.department_id = department.department_id;
                    ViewBag.Supplies = supplies;
                    ViewBag.Departments = departments;
                }
                catch(Exception e)
                {
                    ViewBag.alert = true;
                    TempData["shortMessage"] = true;
                    return Redirect("thanh-ly");
                    throw e;
                }

               
            }
            return View("/Views/CDVT/Quyetdinh/ThanhLy/Them.cshtml");
        }


        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly-chon")]
        [HttpPost]
        public ActionResult GetData(string out_in_come, string data, string department_id, string reason)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary
                    {
                        documentary_type = 5,
                        department_id_to = "CV",
                        date_created = DateTime.Now,
                        person_created = Session["Name"] + "",
                        reason = reason,
                        out_in_come = out_in_come,
                        documentary_status = 1
                    };
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        string buyer = (string)item.Value["buyer"];
                        string equipment_liquidation_reason = (string)item.Value["equipment_liquidation_reason"];
                        Equipment e = DBContext.Equipments.Find(equipmentId);
                        Documentary_liquidation_details drd = new Documentary_liquidation_details
                        {
                            department_id_from = e.department_id,
                            equipment_liquidation_status = 0,
                            buyer = buyer,
                            equipment_liquidation_reason = equipment_liquidation_reason,
                            documentary_id = documentary.documentary_id,
                            equipmentId = equipmentId
                        };
                        DBContext.Documentary_liquidation_details.Add(drd);
                        DBContext.SaveChanges();
                        List<Supply_DiKem> diKem = DBContext.Supply_DiKem.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_DiKem supply in diKem)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                equipmentId_dikem = supply.equipmentId_dikem,
                                supplyStatus = supply.note,
                                quantity_plan = supply.quantity
                            };
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                        List<Supply_SCTX> duPhong = DBContext.Supply_SCTX.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_SCTX supply in duPhong)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                quantity_plan = supply.quantity,
                                supply_id = supply.supply_id
                            };
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return Json(new { success = false });
                    throw e;
                }
            }
        }
    }
}