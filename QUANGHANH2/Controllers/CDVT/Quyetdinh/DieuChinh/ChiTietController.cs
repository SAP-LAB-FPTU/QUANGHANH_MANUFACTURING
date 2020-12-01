//using QUANGHANH2.Models;
//using QUANGHANH2.SupportClass;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Dynamic;
//using System.Web.Mvc;
//using System.Web.Script.Serialization;

//namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.CaiTien
//{
//    public class ChiTietController : Controller
//    {
//        [Auther(RightID = "30")]
//        [HttpGet]
//        [Route("phong-cdvt/quyet-dinh/dieu-chinh/chi-tiet")]
//        public ActionResult LoadPage()
//        {
//            int id = int.Parse(Request["id"]);
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                db.Configuration.LazyLoadingEnabled = false;
//                List<Detail> documentariesList = (from a in db.Documentary_Improve_Detail
//                                                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
//                                                                        join c in db.Equipments on a.equipmentId equals c.equipmentId
//                                                                        join d in db.Status on c.current_Status equals d.statusid
//                                                                        where (b.documentary_id == id)
//                                                                        select new Detail
//                                                                        {
//                                                                            documentary_improve_id = a.documentary_improve_id,
//                                                                            equipmentId = c.equipmentId,
//                                                                            equipment_name = c.equipment_name,
//                                                                            statusname = d.statusname,
//                                                                        }).ToList();
//                ViewBag.list = documentariesList;
//            }
//            return View("/Views/CDVT/Quyetdinh/DieuChinh/ChiTiet.cshtml");
//        }

//        public class Detail
//        {
//            public int documentary_improve_id { get; set; }
//            public string equipmentId { get; set; }
//            public string equipment_name { get; set; }
//            public string statusname { get; set; }
//        }

//        [HttpPost]
//        [Route("phong-cdvt/quyet-dinh/dieu-chinh/chi-tiet")]
//        public ActionResult GetDetail(int documentary_improve_id, bool isEquip)
//        {
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//            db.Configuration.LazyLoadingEnabled = false;
//            if (isEquip)
//            {
//                var list = (from x in db.Supply_Documentary_Improve_Equipment
//                        join y in db.Equipments on x.equipmentId equals y.equipmentId
//                        where x.documentary_improve_id == documentary_improve_id
//                        select new
//                        {
//                            y.equipmentId,
//                            y.equipment_name,
//                            x.quantity_after,
//                            x.quantity_before
//                        }).ToList();
//                return Json(list);
//            }
//            else
//            {
//                var list = (from x in db.Supply_Documentary_Improve_Equipment
//                            join y in db.Supplies on x.supply_id equals y.supply_id
//                            where x.documentary_improve_id == documentary_improve_id
//                            select new
//                            {
//                                y.supply_id,
//                                y.supply_name,
//                                x.quantity_after,
//                                x.quantity_before
//                            }).ToList();
//                return Json(list);
//            }
//        }
//    }
//}