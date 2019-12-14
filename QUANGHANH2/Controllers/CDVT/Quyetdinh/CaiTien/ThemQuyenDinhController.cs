using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.SupportClass;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.CDVT.Work.CaiTien
{
    public class ThemCaiTienController : Controller
    {
        [Auther(RightID = "85")]
        [Route("phong-cdvt/cai-tien-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            var listConvert = listSelected;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<equipmentExtend> result = (from e in db.Equipments
                              where listConvert.Contains(e.equipmentId)
                              join d in db.Departments on e.department_id equals d.department_id
                              join c in db.Status on e.current_Status equals c.statusid
                              select new
                              {
                                  equipmentId = e.equipmentId,
                                  equipment_name = e.equipment_name,
                                  statusname = c.statusname,
                                  department_id = e.department_id,
                              }).ToList().Select(s => new equipmentExtend
                              {
                                  equipmentId = s.equipmentId,
                                  equipment_name = s.equipment_name,
                                  statusname = s.statusname,
                                  department_id = s.department_id,
                              }).OrderBy(l => l.equipmentId).ToList();
                ViewBag.DataThietBi = result;

                List<Supply_DiKem> vatTuDiKem = (from s in db.Supply_DiKem
                                                 where listConvert.Contains(s.equipmentId)
                                                 select s).ToList().Select(s => new Supply_DiKem
                                                 {
                                                     equipmentId_dikem = s.equipmentId_dikem,
                                                     equipmentId = s.equipmentId,
                                                 }).OrderBy(l => l.equipmentId).ToList();

                List<Equipment> supplies = db.Equipments.ToList();
                List <Department> departments = db.Departments.ToList();
                try
                {
                    int validate = 1;
                    var department_id = result.First().department_id;
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
                    ViewBag.vatTuDiKem = vatTuDiKem;
                    ViewBag.Supplies = supplies;
                    ViewBag.Departments = departments;
                }
                catch (Exception e)
                {
                    ViewBag.alert = true;
                    TempData["shortMessage"] = true;
                    return Redirect("cai-tien");
                    throw e;
                }
            }
            return View("/Views/CDVT/Work/CaiTien/ThemCaiTien.cshtml");
        }

        [Auther(RightID = "85")]
        [Route("phong-cdvt/cai-tien-chon/add")]
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
                    documentary.documentary_type = 7;
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
                        Documentary_Improve_Detail drd = new Documentary_Improve_Detail();
                        Equipment e = DBContext.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.equipment_Improve_status = 0;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_Improve_Detail.Add(drd);
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
                            sde.equipmentId_dikem = supply_id;
                            sde.quantity_plan = quantity;
                            sde.supplyStatus = supplyStatus;
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Redirect("/phong-cdvt/quyet-dinh/cai-tien");


                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("/phong-cdvt/cai-tien");
                    throw e;

                }
            }
        }
    }
}