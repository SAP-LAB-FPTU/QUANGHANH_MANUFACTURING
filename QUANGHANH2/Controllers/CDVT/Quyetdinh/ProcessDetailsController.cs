using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class ProcessDetailsController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/GetSupplyRepair")]
        [HttpPost]
        public ActionResult GetSupplyRepair(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 3 ",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else 
            return Json(supplies);
        }
        [Route("phong-cdvt/quyet-dinh/GetSupplyMoveLine")]
        [HttpPost]
        public ActionResult GetSupplyMoveLine(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 6 ",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else
                return Json(supplies);
        }
        [Route("phong-cdvt/quyet-dinh/GetSupplyBigMaintain")]
        [HttpPost]
        public ActionResult GetSupplyBigMaintain(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 9 or doc.supplyType = 10",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else
                return Json(supplies);
        }
        [Route("phong-cdvt/quyet-dinh/GetSupplyMaintain")]
        [HttpPost]
        public ActionResult GetSupplyMaintain(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 5 ",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else
                return Json(supplies);
        }
        [Route("phong-cdvt/quyet-dinh/GetSupplyRevoke")]
        [HttpPost]
        public ActionResult GetSupplyRevoke(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 7 ",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else
                return Json(supplies);
        }
        [Route("phong-cdvt/quyet-dinh/GetSupplyLiquidation")]
        [HttpPost]
        public ActionResult GetSupplyLiquidation(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("SELECT doc.supply_id as MaVT,s.supply_name as TenVT,doc.quantity as SLVT ,doc.supplyStatus as TLVT  FROM Supply_Documentary_Equipment doc INNER JOIN Supply s on doc.supply_id = s.supply_id WHERE doc.equipmentId = @equipmentId AND doc.documentary_id = @documentary_id and doc.supplyType = 8 ",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                Response.Write("Không có vật tư nào");
                return new HttpStatusCodeResult(400);
            }
            else
                return Json(supplies);
        }
    }
    public class Supply_Detail
    {
        public string MaVT { get; set; }
        public string TenVT { get; set; }
        public int SLVT { get; set; }
        public string TLVT { get; set; }
        public bool test { get; set; }
    }
}