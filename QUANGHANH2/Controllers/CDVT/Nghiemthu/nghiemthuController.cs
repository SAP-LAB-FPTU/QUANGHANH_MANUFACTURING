
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
{
    public class nghiemthuController : Controller
    {
        [Auther(RightID = "25")]
        [Route("phong-cdvt/nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Nghiemthu/Nghiemthu.cshtml");
        }
        [Route("phong-cdvt/nghiem-thu")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            string requestID = Request["sessionId"];
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend> docList = new List<Documentary_Extend>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                docList = (from a in db.Acceptances
                           where (a.equipmentStatus == 2)
                           join b in db.Equipments on a.equipmentId equals b.equipmentId
                           select new
                           {
                               documentary_id = a.documentary_id,
                               equipmentId = b.equipmentId,
                               equipment_name = b.equipment_name

                           }).ToList().Select(p => new Documentary_Extend
                           {
                               documentary_id = p.documentary_id,
                               equipmentId = p.equipmentId,
                               equipment_name = p.equipment_name
                           }).ToList();

                //docList = db.Documentaries.ToList<Documentary>();
                int totalrows = docList.Count;
                int totalrowsafterfiltering = docList.Count;
                //sorting
                //docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<Documentary_Extend>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Detail(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var query = db.Documentaries.SqlQuery("Select doc.reason,doc.documentary_type,doc.department_id,doc.documentary_id, doc.date_created,doc.person_created,doc.[out/in_come] as out_in_come,doc.documentary_status from Documentary doc where documentary_id = '" + id + "'").FirstOrDefault<Documentary>();
                return View(query);
            }

        }



        [HttpGet]
        public ActionResult Edit(string id)
        {
            List<Acceptance> AcceptanceList = new List<Acceptance>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Boolean status = false;
                db.Configuration.LazyLoadingEnabled = false;
                AcceptanceList = db.Acceptances.ToList<Acceptance>();
                try
                {
                    var query = "  UPDATE Acceptance SET acceptance_date = getdate(), equipmentStatus = 3 where equipmentId =  '" + id + "'";
                    db.Database.ExecuteSqlCommand(query);
                }
                catch (Exception e)
                {

                }
                db.SaveChanges();
                var acceptance = db.Acceptances.ToList<Acceptance>();
                foreach (Acceptance items in AcceptanceList)
                {
                    if (items.equipmentStatus != 3)
                    {
                        status = false;
                        break;
                    }
                    else
                    {
                        ChangeStatus(id);
                    }
                }

                return RedirectToAction("GetData");
            }
        }

        public ActionResult ChangeStatus(string id)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var query = "UPDATE Documentary SET documentary_status = 3 FROM Acceptance T1, Documentary T2 WHERE T1.documentary_id = T2.documentary_id AND T1.equipmentId = '" + id + "'";
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return RedirectToAction("GetData");
            }
        }
    }

}