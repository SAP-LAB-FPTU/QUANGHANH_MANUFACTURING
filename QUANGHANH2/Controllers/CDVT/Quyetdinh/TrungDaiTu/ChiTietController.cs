//using QUANGHANH2.Models;
//using QUANGHANH2.SupportClass;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic;
//using System.Web.Mvc;
//using System.Web.Routing;

//namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.TrungDaiTu
//{
//    public class ChiTietController : Controller
//    {
//        [Auther(RightID = "42")]
//        [Route("phong-cdvt/quyet-dinh/trung-dai-tu/chi-tiet")]
//        public ActionResult LoadPage(int id)
//        {
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                db.Configuration.LazyLoadingEnabled = false;

//                List<Detail> details = (from a in db.Documentary_big_maintain_details
//                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
//                                        where (b.documentary_id == id)
//                                        select new Detail
//                                        {
//                                            documentary_big_maintain_id = a.documentary_big_maintain_id,
//                                            equipmentId = a.equipmentId,
//                                            attach_to = a.attach_to,
//                                            remodel_type = a.remodel_type,
//                                            next_remodel_type = a.next_remodel_type,
//                                            end_date = a.end_date,
//                                            next_end_time = a.next_end_time,
//                                            equipment_big_maintain_reason = a.equipment_big_maintain_reason,
//                                            quantity = a.quantity
//                                        }).ToList();
//                List<string> equipmentId = details.Select(x => x.equipmentId).ToList();

//                var dict = db.Equipments
//                    .Where(x => equipmentId.Contains(x.equipmentId))
//                    .Select(x => new { x.equipmentId, x.equipment_name })
//                    .AsEnumerable()
//                    .ToDictionary(x => x.equipmentId, x => x.equipment_name);

//                details.ForEach(x => x.equipment_name = dict[x.equipmentId]);
//                ViewBag.details = details;
//            }
//            return View("/Views/CDVT/Quyetdinh/TrungDaiTu/ChiTiet.cshtml");
//        }

//        [Auther(RightID = "30,84,179,180,181,183,184,185,186,187,189,195,003")]
//        [HttpPost]
//        [Route("phong-cdvt/quyet-dinh/trung-dai-tu/chi-tiet")]
//        public ActionResult GetDetail(int documentary_big_maintain_id, bool isSupply)
//        {
//            try
//            {
//                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//                {
//                    if (isSupply)
//                    {
//                        var list = (from a in db.Supplies
//                                    join b in db.Supply_Documentary_Big_Maintain_Equipment on a.supply_id equals b.supply_id
//                                    where b.documentary_big_maintain_id == documentary_big_maintain_id
//                                    select new
//                                    {
//                                        a.supply_id,
//                                        a.supply_name,
//                                        b.quantity_plan,
//                                        b.quantity_in,
//                                        b.quantity_out,
//                                        b.quantity_used,
//                                        b.supplyDocumentaryEquipmentId
//                                    }).ToList();
//                        return Json(new { success = true, data = list });
//                    }
//                    else
//                    {
//                        var list = (from a in db.Equipments
//                                    join b in db.Supply_Documentary_Big_Maintain_Equipment on a.equipmentId equals b.equipmentId
//                                    where b.documentary_big_maintain_id == documentary_big_maintain_id
//                                    select new
//                                    {
//                                        a.equipmentId,
//                                        a.equipment_name,
//                                        b.quantity_plan,
//                                        b.quantity_in,
//                                        b.quantity_out,
//                                        b.quantity_used,
//                                        b.supplyDocumentaryEquipmentId
//                                    }).ToList();
//                        return Json(new { success = true, data = list });
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                return Json(new { success = false });
//            }
//        }

//        public class Detail
//        {
//            public int documentary_big_maintain_id { get; set; }
//            public string equipmentId { get; set; }
//            public string attach_to { get; set; }
//            public string equipment_name { get; set; }
//            public string equipment_big_maintain_reason { get; set; }
//            public string next_remodel_type { get; set; }
//            public DateTime end_date { get; set; }
//            public double next_end_time { get; set; }
//            public int quantity { get; set; }
//            public string remodel_type { get; set; }
//        }
//    }
//}