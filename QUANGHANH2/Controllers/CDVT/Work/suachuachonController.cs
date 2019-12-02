using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.SupportClass;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class suachuachonController : Controller
    {
        [Auther(RightID = "83")]
        [Route("phong-cdvt/sua-chua-chon")]
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
                    return Redirect("sua-chua");
                    throw e;
                }
               
            }
            return View("/Views/CDVT/Work/suachuachon.cshtml");
        }

        [Auther(RightID = "83")]
        [Route("phong-cdvt/sua-chua-chon")]
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
                    documentary.documentary_code = null;
                    documentary.documentary_type = 1;
                    documentary.department_id = department_id;
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
                        string repair_type = (string)item.Value["repair_type"];
                        string repair_reason = (string)item.Value["repair_reason"];
                        string datestring = (string)item.Value["finish_date_plan"];
                        DateTime finish_date_plan = DateTime.ParseExact(datestring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Documentary_repair_details drd = new Documentary_repair_details();
                        drd.equipment_repair_status = 0;
                        drd.repair_type = repair_type;
                        drd.repair_reason = repair_reason;
                        drd.finish_date_plan = finish_date_plan;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_repair_details.Add(drd);
                        DBContext.SaveChanges();
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
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
                            sde.supply_documentary_status = 0;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Redirect("quyet-dinh/sua-chua");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("sua-chua");
                    throw e;
                }
            }
        }
    }
}