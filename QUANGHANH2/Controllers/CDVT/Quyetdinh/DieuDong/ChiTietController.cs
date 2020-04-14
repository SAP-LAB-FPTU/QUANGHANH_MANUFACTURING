using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.DieuDong
{
    public class ChiTietController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/dieu-dong/chi-tiet")]
        public ActionResult Index(int id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            db.Configuration.LazyLoadingEnabled = false;
            List<Detail> details = (from e in db.Equipments
                                  join s in db.Status on e.current_Status equals s.statusid
                                  join d in db.Documentary_moveline_details on e.equipmentId equals d.equipmentId
                                  where d.documentary_id == id
                                  select new Detail
                                  {
                                      equipmentId = e.equipmentId,
                                      equipment_name = e.equipment_name,
                                      current_Status = s.statusname,
                                      department_detail = d.department_detail,
                                      date_to = d.date_to,
                                      equipment_moveline_reason = d.equipment_moveline_reason
                                  }).ToList();

            List<SupplyEquip> supplyEquip = db.Database.SqlQuery<SupplyEquip>(@"select a.equipmentId, a.equipmentId_dikem,
                c.equipment_name, a.supply_id, b.supply_name, a.quantity_plan, a.supplyStatus 
                from Supply_Documentary_Equipment a 
                left join Supply b on a.supply_id = b.supply_id
                left join Equipment c on a.equipmentId_dikem = c.equipmentId
                where a.documentary_id = @documentary_id", new SqlParameter("documentary_id", id)).ToList();

            ViewBag.details = details;
            ViewBag.supplyEquip = new JavaScriptSerializer().Serialize(supplyEquip);

            return View("/Views/CDVT/Quyetdinh/DieuDong/ChiTiet.cshtml");
        }

        public class Detail
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string current_Status { get; set; }
            public string department_detail { get; set; }
            public DateTime date_to { get; set; }
            public string equipment_moveline_reason { get; set; }
        }

        public class SupplyEquip
        {
            public string equipmentId { get; set; }
            public string equipmentId_dikem { get; set; }
            public string equipment_name { get; set; }
            public string supply_id { get; set; }
            public string supply_name { get; set; }
            public int quantity_plan { get; set; }
            public string supplyStatus { get; set; }
        }
    }
}