using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Cap_nhat.Chitiet
{
    public class VattucuaQDController : Controller
    {
        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetSupply")]
        [HttpPost]
        public ActionResult GetSupply(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_EquipmentDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_EquipmentDB>("SELECT * FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            return Json(supplies);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetSupplyDuPhong")]
        [HttpPost]
        public ActionResult GetSupplyDuPhong(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_EquipmentDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_EquipmentDB>("SELECT * FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            return Json(supplies);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetEquipAttached")]
        [HttpPost]
        public ActionResult GetEquipAttached(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_EquipmentDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_EquipmentDB>("SELECT * FROM Supply_Documentary_Equipment doc INNER JOIN Equipment e on doc.equipmentId_dikem = e.equipmentId WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            return Json(supplies);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetSupply2")]
        [HttpPost]
        public ActionResult GetSupply2(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_EquipmentDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_EquipmentDB>("SELECT * FROM Supply_Documentary_Equipment WHERE equipmentId = @equipmentId AND documentary_id = @documentary_id",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            return Json(supplies);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetSupplyName")]
        [HttpPost]
        public ActionResult GetSupplyName(string supply_id)
        {
            try
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                Supply supply = DBContext.Database.SqlQuery<Supply>("SELECT * FROM Supply WHERE supply_id = @supply_id",
                    new SqlParameter("supply_id", supply_id)).First();
                return Json(supply);
            }
            catch (Exception)
            {
                Response.Write("Mã vật tư không tồn tại");
                return new HttpStatusCodeResult(400);
            }
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/EditSupplyStatus")]
        [HttpPost]
        public ActionResult EditSupplyStatus(string documentary_id, string equipmentId, string listSupplies)
        {
            if (listSupplies != "")
            {
                QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
                using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                {
                    try
                    {
                        listSupplies = listSupplies.Substring(0, listSupplies.Length - 1);
                        char[] spearator = { '^' };
                        String[] list = listSupplies.Split(spearator,
                           StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item in list)
                        {
                            DBContext.Database.ExecuteSqlCommand("UPDATE Supply_Documentary_Equipment SET supply_documentary_status = 1 WHERE supply_id = @supply_id AND equipmentId = @equipmentId AND documentary_id = @documentary_id",
                                new SqlParameter("supply_id", item),
                                new SqlParameter("equipmentId", equipmentId),
                                new SqlParameter("documentary_id", documentary_id));
                        }

                        DBContext.SaveChanges();
                        transaction.Commit();
                        return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = true, message = "Lưu thành công" }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/AddSupply")]
        [HttpPost]
        public ActionResult AddSupply(string list, int documentary_id, string equipmentId)
        {
            //string type = Request["type"];  //0 là vật tư, 1 là thiết bị con
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    JObject json = JObject.Parse(list);
                    JArray arr = (JArray)json.SelectToken("list");  //list của thiết bị con đi kèm và vật tư dự phòng
                    foreach (JObject item in arr)
                    {
                        string supply_id = (string)item["supply_id"];
                        Supply_Documentary_Equipment temp;
                        if (DBContext.Supplies.Find(supply_id) == null)
                        {
                            temp = DBContext.Supply_Documentary_Equipment.Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.equipmentId_dikem == supply_id).FirstOrDefault();
                        }
                        else
                        {
                            temp = DBContext.Supply_Documentary_Equipment.Where(a => a.documentary_id == documentary_id && a.equipmentId == equipmentId && a.supply_id == supply_id).FirstOrDefault();
                        }
                        if (temp == null)
                        {
                            temp = new Supply_Documentary_Equipment();
                            temp.documentary_id = documentary_id;
                            temp.equipmentId = equipmentId;
                            temp.quantity_in = (int)item["quantity_in"];
                            temp.quantity_out = (int)item["quantity_out"];
                            temp.quantity_plan = (int)item["quantity_plan"];
                            temp.quantity_used = (int)item["quantity_used"];
                            temp.supplyStatus = (string)item["supplyStatus"];
                            temp.supply_id = (string)item["supply_id"];
                            DBContext.Supply_Documentary_Equipment.Add(temp);
                        }
                        else
                        {
                            temp.quantity_in = (int)item["quantity_in"];
                            temp.quantity_out = item["quantity_out"] == null ? 0 : (int)item["quantity_out"];
                            temp.quantity_used = item["quantity_used"] == null ? 0 : (int)item["quantity_used"];
                            temp.supplyStatus = (string)item["supplyStatus"];
                        }
                        DBContext.SaveChanges();
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Cập nhật thành công" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
        }

        [Route("phong-cdvt/thiet-bi/get-supply")]
        [HttpPost]
        public ActionResult GetSupply(string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //List<Supply_DiKem> supply_DiKem = DBContext.Supply_DiKem.Where(s => s.equipmentId == equipmentId).ToList();
            var supply_DiKem = (from s in DBContext.Supply_DiKem
                                where s.equipmentId.Equals(equipmentId)
                                select new
                                {
                                    supply_id = s.equipmentId_dikem,
                                    quantity = s.quantity
                                }).ToList();
            return Json(supply_DiKem);
        }

        [Route("phong-cdvt/thiet-bi/get-supply2")]
        [HttpPost]
        public ActionResult GetSupply2(string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //List<Supply_DiKem> supply_DiKem = DBContext.Supply_DiKem.Where(s => s.equipmentId == equipmentId).ToList();
            var supply_DiKem = (from s in DBContext.Supply_DuPhong
                                where s.equipmentId.Equals(equipmentId)
                                select new
                                {
                                    supply_id = s.supply_id,
                                    quantity = s.quantity
                                }).ToList();
            return Json(supply_DiKem);
        }

        [Route("phong-cdvt/thiet-bi/get-attached-equipment")]
        [HttpPost]
        public ActionResult GetAttachedEquip(string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<AttachedEquip> supply_DiKem = DBContext.Database.SqlQuery<AttachedEquip>(@"select a.equipmentId_dikem, e.equipment_name, a.quantity as quantity_dikem
from (select sdk.equipmentId_dikem, sdk.quantity
from Supply_DiKem sdk
where sdk.equipmentId = @equipmentId) as a inner join Equipment e on e.equipmentId = a.equipmentId_dikem", new SqlParameter("equipmentId", equipmentId)).ToList();
            return Json(supply_DiKem);
        }

        private class AttachedEquip
        {
            public string equipmentId_dikem { get; set; }
            public string equipment_name { get; set; }
            public int quantity_dikem { get; set; }
        }
    }
}