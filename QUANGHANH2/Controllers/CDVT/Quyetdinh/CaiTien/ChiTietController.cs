using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.CaiTien
{
    public class ChiTietController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/quyet-dinh/cai-tien-chi-tiet")]
        public ActionResult LoadPage()
        {
            int id = int.Parse(Request["id"]);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                int count = 1;
                List<Documentary_Improve_DetailDB> documentariesList = (from a in db.Documentary_Improve_Detail
                                                                        join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                                                        join c in db.Equipments on a.equipmentId equals c.equipmentId
                                                                        join d in db.Departments on c.department_id equals d.department_id
                                                                        where (b.documentary_id == id)
                                                                        select new Documentary_Improve_DetailDB
                                                                        {
                                                                            documentary_code = b.documentary_code,
                                                                            documentary_id = a.documentary_id,
                                                                            equipmentId = c.equipmentId,
                                                                            equipment_name = c.equipment_name,
                                                                            department_id = c.department_id,
                                                                            department_id_to = b.department_id_to,
                                                                            department_name = d.department_name,
                                                                            reason = b.reason,
                                                                        }).ToList();
                foreach (var el in documentariesList)
                {
                    el.order_number = count++;
                    el.idAndEquip = el.documentary_id + "^" + el.equipmentId;
                }
                ViewBag.list = documentariesList;
            }
            return View("/Views/CDVT/Quyet_dinh/Chi_tiet_cai_tien.cshtml");
        }

        [HttpPost]
        [Route("phong-cdvt/quyet-dinh/cai-tien-chi-tiet")]
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
                List<Documentary_Improve_DetailDB> documentariesList = (from a in db.Documentary_Improve_Detail
                                                                          join b in db.Documentaries on a.documentary_id equals b.documentary_id
                                                                          join c in db.Equipments on a.equipmentId equals c.equipmentId
                                                                          join d in db.Departments on c.department_id equals d.department_id
                                                                          where (b.documentary_id == id)
                                                                          select new Documentary_Improve_DetailDB
                                                                          {
                                                                              documentary_code = b.documentary_code,
                                                                              equipmentId = c.equipmentId,
                                                                              documentary_id = a.documentary_id,
                                                                              equipment_name = c.equipment_name,
                                                                              department_name = d.department_name,
                                                                              department_id = c.department_id,
                                                                              reason = b.reason
                                                                          }).ToList();
                foreach (var el in documentariesList)
                {
                    el.order_number = count++;
                    el.idAndEquip = el.documentary_id + "^" + el.equipmentId;
                }
                int totalrows = documentariesList.Count;
                int totalrowsafterfiltering = documentariesList.Count;

                //sorting
                documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Improve_DetailDB>();
                //paging

                documentariesList = documentariesList.Skip(start).Take(length).ToList<Documentary_Improve_DetailDB>();
                Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

                var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                var result = new JavaScriptSerializer().Serialize(js.Data);
                ViewBag.count = 0;
                return js;
            }
        }
    }
}