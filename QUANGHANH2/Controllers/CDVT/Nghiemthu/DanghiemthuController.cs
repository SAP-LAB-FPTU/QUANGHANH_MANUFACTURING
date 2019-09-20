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
    public class DanghiemthuController : Controller
    {
        [Route("phong-cdvt/da-nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Nghiemthu/Danghiemthu.cshtml");
        }

        [Route("phong-cdvt/da-nghiem-thu")]
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
                           where (a.equipmentStatus == 3)
                           join b in db.Equipments on a.equipmentId equals b.equipmentId
                           select new
                           {
                               //documentary_id = a.documentary_id,
                               equipmentId = b.equipmentId,
                               equipment_name = b.equipment_name,
                               acceptance_date = a.acceptance_date


                           }).ToList().Select(p => new Documentary_Extend
                           {
                               //documentary_id = p.documentary_id,
                               equipmentId = p.equipmentId,
                               equipment_name = p.equipment_name,
                               acceptance_date = p.acceptance_date

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
    }
}