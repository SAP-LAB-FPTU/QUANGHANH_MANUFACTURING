using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ChiTietController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/chi-tiet")]
        public ActionResult LoadPage(int id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<Detail> details = (from a in db.Documentary_repair_details
                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                        where (b.documentary_id == id)
                                        select new Detail
                                        {
                                            documentary_repair_id = a.documentary_repair_id,
                                            equipmentId = a.attach_to == null ? a.equipmentId : (a.equipmentId + "  (" + a.attach_to + ")"),
                                            attach_to = a.attach_to,
                                            repair_reason = a.repair_reason,
                                            repair_type = a.repair_type,
                                            finish_date_plan = a.finish_date_plan,
                                            quantity = a.quantity
                                        }).ToList();
                List<string> equipmentId = details.Select(x => x.equipmentId).ToList();

                var dict = db.Equipments
                    .Where(x => equipmentId.Contains(x.equipmentId))
                    .Select(x => new { x.equipmentId, x.equipment_name })
                    .AsEnumerable()
                    .ToDictionary(x => x.equipmentId, x => x.equipment_name);

                details.ForEach(x => x.equipment_name = dict[x.equipmentId]);
                ViewBag.details = details;
            }
            return View("/Views/CDVT/Quyetdinh/SuaChua/ChiTiet.cshtml");
        }

        [Auther(RightID = "30,84,179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phong-cdvt/quyet-dinh/sua-chua/chi-tiet")]
        public ActionResult GetDetail(int documentary_repair_id, bool isSupply)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    if (isSupply)
                    {
                        var list = (from a in db.Supplies
                                    join b in db.Supply_Documentary_Repair_Equipment on a.supply_id equals b.supply_id
                                    where b.documentary_repair_id == documentary_repair_id
                                    select new
                                    {
                                        a.supply_id,
                                        a.supply_name,
                                        b.quantity_plan,
                                        b.quantity_in,
                                        b.quantity_out,
                                        b.quantity_used,
                                        b.supplyDocumentaryEquipmentId
                                    }).ToList();
                        return Json(new { success = true, data = list });
                    }
                    else
                    {
                        var list = (from a in db.Equipments
                                    join b in db.Supply_Documentary_Repair_Equipment on a.equipmentId equals b.equipmentId
                                    where b.documentary_repair_id == documentary_repair_id
                                    select new
                                    {
                                        a.equipmentId,
                                        a.equipment_name,
                                        b.quantity_plan,
                                        b.quantity_in,
                                        b.quantity_out,
                                        b.quantity_used,
                                        b.supplyDocumentaryEquipmentId
                                    }).ToList();
                        return Json(new { success = true, data = list });
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        public class Detail
        {
            public int documentary_repair_id { get; set; }
            public string equipmentId { get; set; }
            public string attach_to { get; set; }
            public string equipment_name { get; set; }
            public string repair_reason { get; set; }
            public string repair_type { get; set; }
            public DateTime finish_date_plan { get; set; }
            public int quantity { get; set; }
        }
    }
}