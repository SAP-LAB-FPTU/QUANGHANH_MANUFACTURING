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

        [Route("phong-cdvt/cap-nhat/quyet-dinh/GetSupply2")]
        [HttpPost]
        public ActionResult GetSupply2(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Documentary_EquipmentDB> supplies = DBContext.Database.SqlQuery<Supply_Documentary_EquipmentDB>("SELECT s.supply_id, supply_name, s.supplyStatus, s.quantity, a.quantity as reuse FROM (SELECT * FROM Supply_Documentary_Equipment where supplyType = 2 AND documentary_id = @documentary_id AND equipmentId = @equipmentId) as a inner join Supply_Documentary_Equipment as s on a.supply_id = s.supply_id inner join Supply on Supply.supply_id = s.supply_id WHERE s.documentary_id = @documentary_id AND s.equipmentId = @equipmentId AND s.supplyType = 1 ",
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
                        return new HttpStatusCodeResult(201);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                        return new HttpStatusCodeResult(400);
                    }
                }
            }
            return new HttpStatusCodeResult(201);
        }

        [Route("phong-cdvt/cap-nhat/quyet-dinh/AddSupply")]
        [HttpPost]
        public ActionResult AddSupply(string list, string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    JObject json = JObject.Parse(list);
                    JArray temp = (JArray)json.SelectToken("list");
                    int i = 0;
                    foreach (JObject item in temp)
                    {
                        if(i == 0 && (string)item["supply_id"] == null) return new HttpStatusCodeResult(201);
                        if (DBContext.Database.SqlQuery<Supply_Documentary_Equipment>("SELECT * FROM Supply_Documentary_Equipment WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId AND supply_id = @supply_id AND supplyType = @supplyType AND supplyStatus = @supplyStatus",
                            new SqlParameter("documentary_id", Int32.Parse(documentary_id)),
                            new SqlParameter("equipmentId", equipmentId),
                            new SqlParameter("supply_id", (string)item["supply_id"]),
                            new SqlParameter("quantity", (int)item["quantity"]),
                            new SqlParameter("supplyType", (int)item["supplyType"]),
                            new SqlParameter("supplyStatus", (string)item["supplyStatus"]),
                            new SqlParameter("supply_documentary_status", 1)).Count() == 0) { 
                            
                            DBContext.Database.ExecuteSqlCommand("INSERT INTO Supply_Documentary_Equipment values (@documentary_id, @equipmentId, @supply_id, @quantity, @supplyType, @supplyStatus, @supply_documentary_status)",
                                new SqlParameter("documentary_id", Int32.Parse(documentary_id)),
                                new SqlParameter("equipmentId", equipmentId),
                                new SqlParameter("supply_id", (string)item["supply_id"]),
                                new SqlParameter("quantity", (int)item["quantity"]),
                                new SqlParameter("supplyType", (int)item["supplyType"]),
                                new SqlParameter("supplyStatus", (string)item["supplyStatus"]),
                                new SqlParameter("supply_documentary_status", 1));
                        }
                        else
                        {
                            DBContext.Database.ExecuteSqlCommand("UPDATE Supply_Documentary_Equipment SET quantity = (quantity + @quantity) WHERE documentary_id = @documentary_id AND equipmentId = @equipmentId AND supply_id = @supply_id AND supplyType = @supplyType AND supplyStatus = @supplyStatus",
                                new SqlParameter("documentary_id", Int32.Parse(documentary_id)),
                                new SqlParameter("equipmentId", equipmentId),
                                new SqlParameter("supply_id", (string)item["supply_id"]),
                                new SqlParameter("quantity", (int)item["quantity"]),
                                new SqlParameter("supplyType", (int)item["supplyType"]),
                                new SqlParameter("supplyStatus", (string)item["supplyStatus"]),
                                new SqlParameter("supply_documentary_status", 1));
                        }
                        i++;
                        DBContext.SaveChanges();
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return new HttpStatusCodeResult(201);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                    return new HttpStatusCodeResult(400);
                }
            }
        }
    }
}