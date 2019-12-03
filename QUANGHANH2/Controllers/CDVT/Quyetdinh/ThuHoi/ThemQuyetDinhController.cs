using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Text.RegularExpressions;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class kiemdinhchonController : Controller
    {
        [Auther(RightID = "89")]
        [Route("phong-cdvt/thu-hoi-chon")]
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
                    return Redirect("thu-hoi");
                    throw e;
                }
                
            }
            return View("/Views/CDVT/Work/thuhoichon.cshtml");
        }

        [Auther(RightID = "89")]
        [Route("phong-cdvt/thu-hoi-chon")]
        [HttpPost]
        public ActionResult GetData(string documentary_code, string out_in_come, string data, string department_id, string reason)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary();
                    documentary.documentary_code = documentary_code == "" ? null : documentary_code;
                    documentary.documentary_type = 4;
                    documentary.department_id = department_id;
                    documentary.department_id_to = "CDVT";
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
                        string equipment_revoke_reason = (string)item.Value["equipment_revoke_reason"];
                        if (documentary_code != "")
                        {
                            Equipment e = DBContext.Equipments.Find(equipmentId);
                            e.current_Status = 7;
                        }

                        Documentary_revoke_details drd = new Documentary_revoke_details();
                        drd.equipment_revoke_status = 0;
                        drd.equipment_revoke_reason = equipment_revoke_reason;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_revoke_details.Add(drd);
                        DBContext.SaveChanges();
                        List<Supply_DiKem> diKem = DBContext.Supply_DiKem.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_DiKem supply in diKem)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment();
                            s.documentary_id = documentary.documentary_id;
                            s.equipmentId = equipmentId;
                            s.quantity_plan = supply.quantity;
                            s.supply_id = supply.supply_id;
                            s.supplyStatus = supply.note;
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                        List<Supply_DuPhong> duPhong = DBContext.Supply_DuPhong.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_DuPhong supply in duPhong)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment();
                            s.documentary_id = documentary.documentary_id;
                            s.equipmentId = equipmentId;
                            s.quantity_plan = supply.quantity;
                            s.supply_id = supply.supply_id;
                            s.supply_documentary_status = 1;
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
            
                        return Redirect("quyet-dinh/thu-hoi");
                    
               
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("thu-hoi");
                    throw e;
                }
            }
        }
    }
}