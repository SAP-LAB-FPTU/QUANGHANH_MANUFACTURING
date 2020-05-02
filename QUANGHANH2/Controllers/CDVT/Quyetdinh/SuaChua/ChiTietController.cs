using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANHCORE.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ChiTietController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/quyet-dinh/sua-chua-chi-tiet/")]
        public ActionResult LoadPage(String id)
        {
            ViewBag.id = id.ToString().Split('^')[0];
          
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_sua_chua.cshtml");
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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
                List<Documentary_repair_detailsDB> documentariesList = (from a in db.Documentary_repair_details
                                                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                                                        join c in db.Equipments on a.equipmentId equals c.equipmentId
                                                                        join d in db.Departments on c.department_id equals d.department_id
                                                                        where (b.documentary_id == id)
                                                                        select new
                                                                        {   documentary_id = b.documentary_id,
                                                                            documentary_code = b.documentary_code,
                                                                            equipmentId = c.equipmentId,
                                                                            equipment_name = c.equipment_name,
                                                                            department_name = d.department_name,
                                                                            department_id = c.department_id,
                                                                            repair_reason = a.repair_reason,
                                                                            repair_type = a.repair_type,
                                                                            reason = b.reason,
                                                                            finish_date_plan = a.finish_date_plan
                                                                        }).ToList().Select(p => new Documentary_repair_detailsDB
                                                                        {
                                                                            documentary_id = p.documentary_id,
                                                                            documentary_code = p.documentary_code,
                                                                            equipmentId = p.equipmentId,
                                                                            equipment_name = p.equipment_name,
                                                                            department_name = p.department_name,
                                                                            department_id = p.department_id,
                                                                            repair_reason = p.repair_reason,
                                                                            repair_type = p.repair_type,
                                                                            reason = p.reason,
                                                                            finish_date_plan = p.finish_date_plan
                                                                        }).ToList();
                foreach (var el in documentariesList)
                {
                    el.order_number = count++;
                    el.idAndEquip = el.documentary_id + "^" + el.equipmentId;

                }
                int totalrows = documentariesList.Count;
                int totalrowsafterfiltering = documentariesList.Count;

                //sorting
                documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_repair_detailsDB>();
                //paging

                documentariesList = documentariesList.Skip(start).Take(length).ToList<Documentary_repair_detailsDB>();
                Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

                var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                var result = new JavaScriptSerializer().Serialize(js.Data);
                ViewBag.count = 0;
                return js;
            }
        }
    }

}