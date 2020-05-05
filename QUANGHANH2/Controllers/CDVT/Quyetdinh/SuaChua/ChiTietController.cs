using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ChiTietController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/quyet-dinh/sua-chua/chi-tiet")]
        public ActionResult LoadPage(int id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<Detail> details = new List<Detail>();
                List<string> equipmentId = new List<string>();

                List<Detail> temp = (from a in db.Documentary_repair_details
                                     join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                     where (b.documentary_id == id)
                                     select new Detail
                                     {
                                         equipmentId = a.equipmentId,
                                         equipmentId_dikem = a.equipmentId_dikem,
                                         repair_reason = a.repair_reason,
                                         repair_type = a.repair_type,
                                         finish_date_plan = a.finish_date_plan,
                                         quantity = a.quantity
                                     }).ToList();
                foreach (Detail item in temp)
                {
                    if (item.equipmentId_dikem == null)
                    {
                        equipmentId.Add(item.equipmentId);
                        details.Add(item);
                    }
                    else
                    {
                        equipmentId.Add(item.equipmentId_dikem);
                        details.Add(new Detail
                        {
                            equipmentId = item.equipmentId_dikem + " (" + item.equipmentId + ")",
                            repair_reason = item.repair_reason,
                            repair_type = item.repair_type,
                            finish_date_plan = item.finish_date_plan,
                            quantity = item.quantity
                        });
                    }
                }
                ViewBag.details = details;
            }
            return View("/Views/CDVT/Quyetdinh/SuaChua/ChiTiet.cshtml");
        }

        public class Detail
        {
            public string equipmentId { get; set; }
            public string equipmentId_dikem { get; set; }
            public string equipment_name { get; set; }
            public string repair_reason { get; set; }
            public string repair_type { get; set; }
            public DateTime finish_date_plan { get; set; }
            public int quantity { get; set; }
        }
    }

}