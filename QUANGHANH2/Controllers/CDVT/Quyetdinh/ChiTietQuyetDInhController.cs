using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class ChiTietQuyetDInhController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/dieu-dong-chi-tiet")]      
        public ActionResult LoadPage(String id)
        {
            ViewBag.id = id.ToString().Split('^')[0];
            ViewBag.code = id.ToString().Split('^')[2];
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_Quyet_dinh.cshtml");
        }

        [HttpPost]
        public ActionResult Detail()
        {
            string requestID = Request["sessionId"];
            int id = Int32.Parse(requestID);
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                int count = 1;
                List<Documentary_moveline_detailsDB> documentariesList = (from a in db.Documentary_moveline_details
                                                                       
                                                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                                                        join c in db.Equipments on a.equipmentId equals c.equipmentId
                                                                        join d in db.Departments on c.department_id equals d.department_id
                                                                          where (b.documentary_id == id)
                                                                          select new
                                                                        {
                                                                              documentary_id = b.documentary_id,
                                                                              documentary_code = b.documentary_code,
                                                                              equipmentId = c.equipmentId,
                                                                              equipment_moveline_status = a.equipment_moveline_status,
                                                                              department_detail = a.department_detail,
                                                                              date_to = a.date_to,
                                                                              equipment_name = c.equipment_name,
                                                                            department_name = d.department_name,
                                                                            department_id = c.department_id,
                                                                            reason = b.reason,

                                                                        }).ToList().Select(p => new Documentary_moveline_detailsDB
                                                                        {
                                                                            equipment_moveline_status = p.equipment_moveline_status,
                                                                            department_detail = p.department_detail,
                                                                            date_to = p.date_to,
                                                                            documentary_id = p.documentary_id,
                                                                            documentary_code = p.documentary_code,
                                                                            equipmentId = p.equipmentId,
                                                                            equipment_name = p.equipment_name,
                                                                            department_name = p.department_name,
                                                                            department_id = p.department_id,
                                                                            reason = p.reason,
                                                                        }).ToList();
                foreach (var el in documentariesList)
                {
                    el.order_number = count++;
                    el.idAndEquip = el.documentary_id + "^" + el.equipmentId;

                }
                int totalrows = documentariesList.Count;
                int totalrowsafterfiltering = documentariesList.Count;

                //sorting
                documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_moveline_detailsDB>();
                //paging

                documentariesList = documentariesList.Skip(start).Take(length).ToList<Documentary_moveline_detailsDB>();
                Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

                var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                var result = new JavaScriptSerializer().Serialize(js.Data);
                ViewBag.count = 0;
                return js;
            }
        }
    }
}