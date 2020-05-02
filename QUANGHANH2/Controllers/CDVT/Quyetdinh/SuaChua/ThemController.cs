using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.SupportClass;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data.Entity;
using System.IO;
using System.Web.Hosting;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ThemController : Controller
    {
        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/them")]
        [HttpPost]
        public ActionResult Index(string selected)
        {
            try
            {
                ViewBag.selected = selected;

                JObject convertedJson = JObject.Parse(selected);

                List<_Equipment> listEquip = new List<_Equipment>();

                foreach (var item in convertedJson)
                {
                    if (item.Value.HasValues)
                        foreach (var i in (JObject)item.Value)
                        {
                            listEquip.Add(new _Equipment
                            {
                                attachTo = item.Key,
                                equipmentId = i.Key,
                                quantity = int.Parse(i.Value.ToString())
                            });
                        }
                    else
                        listEquip.Add(new _Equipment
                        {
                            attachTo = null,
                            equipmentId = item.Key,
                            quantity = 1
                        });
                }

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    List<string> listId = listEquip.Select(x => x.equipmentId).Distinct().ToList();

                    var dict = db
                        .Equipments
                        .Where(x => listId.Contains(x.equipmentId))
                        .Select(x => new { x.equipmentId, x.equipment_name })
                        .AsEnumerable()
                        .ToDictionary(d => d.equipmentId, d => d.equipment_name);

                    listEquip.ForEach(x => x.equipment_name = dict[x.equipmentId]);

                    ViewBag.DataThietBi = listEquip;

                    List<Department> departments = db.Departments.ToList();

                    ViewBag.Departments = departments;
                }
                return View("/Views/CDVT/Quyetdinh/SuaChua/Them.cshtml");
            }
            catch (Exception ex)
            {
                LogError
                return Redirect("/phong-cdvt/quyet-dinh/sua-chua/chon-thiet-bi");
            }
        }

        public class _Equipment
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string attachTo { get; set; }
            public int quantity { get; set; }
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
                    documentary.documentary_type = 1;
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
                        string repair_type = (string)item.Value["repair_type"];
                        string repair_reason = (string)item.Value["repair_reason"];
                        string datestring = (string)item.Value["finish_date_plan"];
                        DateTime finish_date_plan = DateTime.ParseExact(datestring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Documentary_repair_details drd = new Documentary_repair_details();
                        Equipment e = DBContext.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.equipment_repair_status = 0;
                        drd.repair_type = repair_type;
                        drd.repair_reason = repair_reason;
                        drd.finish_date_plan = finish_date_plan;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        drd.isVisible = true;
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