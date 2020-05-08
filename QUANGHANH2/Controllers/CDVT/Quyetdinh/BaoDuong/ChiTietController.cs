using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.BaoDuong
{
    public class ChiTietController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/bao-duong/chi-tiet")]
        public ActionResult LoadPage(int id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<string> equipmentId = new List<string>();

                List<Detail> details = (from a in db.Documentary_maintain_details
                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                        where (b.documentary_id == id)
                                        select new Detail
                                        {
                                            documentary_maintain_id = a.documentary_maintain_id,
                                            equipmentId = a.equipmentId_dikem == null ? a.equipmentId : (a.equipmentId_dikem + "  (" + a.equipmentId + ")"),
                                            equipmentId_dikem = a.equipmentId_dikem,
                                            maintain_type = a.maintain_type,
                                            equipment_maintain_reason = a.equipment_maintain_reason,
                                            finish_date_plan = a.finish_date_plan,
                                            quantity = a.quantity
                                        }).ToList();

                foreach (Detail item in details)
                {
                    if (item.equipmentId_dikem == null)
                    {
                        equipmentId.Add(item.equipmentId);
                    }
                    else
                    {
                        equipmentId.Add(item.equipmentId_dikem);
                    }
                }

                var dict = db.Equipments
                    .Where(x => equipmentId.Contains(x.equipmentId))
                    .Select(x => new { x.equipmentId, x.equipment_name })
                    .AsEnumerable()
                    .ToDictionary(x => x.equipmentId, x => x.equipment_name);

                details.ForEach(x => x.equipment_name = x.equipmentId_dikem == null ? dict[x.equipmentId] : dict[x.equipmentId_dikem]);
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
            public int documentary_maintain_id { get; set; }
            public string equipmentId { get; set; }
            public string equipmentId_dikem { get; set; }
            public string equipment_name { get; set; }
            public string maintain_type { get; set; }
            public string equipment_maintain_reason { get; set; }
            public DateTime finish_date_plan { get; set; }
            public int quantity { get; set; }
        }
    }
}
