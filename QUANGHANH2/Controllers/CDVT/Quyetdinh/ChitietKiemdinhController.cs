using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh
{
    public class ChitietKiemdinhController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/quyet-dinh/Kiem-dinh-chi-tiet/")]
        public ActionResult LoadPage(String id)
        {
            ViewBag.id = id.ToString();
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_kiem_dinh.cshtml");
        }

        //    [HttpPost]
        //    public ActionResult Detail()
        //    {
        //        string requestID = Request["sessionId"];
        //        int start = Convert.ToInt32(Request["start"]);
        //        int length = 10;
        //        string searchValue = Request["search[value]"];
        //        string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
        //        string sortDirection = Request["order[0][dir]"];

        //        using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //        {
        //            //db.Configuration.LazyLoadingEnabled = false;
        //            //int count = 1;
        //            //List<NewDocumentary_repair_details> documentariesList = (from a in db.Documentary_repair_details
        //            //                                                      where (a.documentary_id == requestID)
        //            //                                                      join b in db.Documentaries on a.documentary_id equals b.documentary_id
        //            //                                                      join c in db.Equipments on a.equipmentId equals c.equipmentId
        //            //                                                      join d in db.Departments on c.department_id equals d.department_id
        //            //                                                      select new
        //            //                                                      {
        //            //                                                          documentary_id = a.documentary_id,
        //            //                                                          equipment_name = c.equipment_name,
        //            //                                                          department_name = d.department_name,
        //            //                                                          department_id = c.department_id,
        //            //                                                          repair_reason = a.repair_reason,
        //            //                                                          repair_type = a.repair_type,
        //            //                                                          reason = b.reason,
        //            //                                                          finish_date_plan = a.finish_date_plan
        //            //                                                      }).ToList().Select(p => new NewDocumentary_repair_details
        //            //                                                      {
        //            //                                                          documentary_id = p.documentary_id,
        //            //                                                          equipment_name = p.equipment_name,
        //            //                                                          department_name = p.department_name,
        //            //                                                          department_id = p.department_id,
        //            //                                                          repair_reason = p.repair_reason,
        //            //                                                          repair_type = p.repair_type,
        //            //                                                          reason = p.reason,
        //            //                                                          finish_date_plan = p.finish_date_plan
        //            //                                                      }).ToList();
        //            //foreach (var el in documentariesList)
        //            //{
        //            //    el.order_number = count++;

        //            //}
        //            //int totalrows = documentariesList.Count;
        //            //int totalrowsafterfiltering = documentariesList.Count;

        //            ////sorting
        //            //documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<NewDocumentary_repair_details>();
        //            ////paging

        //            //documentariesList = documentariesList.Skip(start).Take(length).ToList<NewDocumentary_repair_details>();
        //            //Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

        //            //var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

        //            //var result = new JavaScriptSerializer().Serialize(js.Data);
        //            //ViewBag.count = 0;
        //            //return js;
        //        }
        //    }
        //}
        public class NewDocumentary_repair_details : Documentary_repair_details
        {
            public string repair_type { get; set; }

            public string repair_reason { get; set; }

            public System.DateTime finish_date_plan { get; set; }

            public string documentary_id { get; set; }

            public string equipmentId { get; set; }

            public string department_id { get; set; }

            public string equipment_name { get; set; }

            public string department_name { get; set; }

            public string reason { get; set; }

            public int order_number { get; set; }
        }
    }
}