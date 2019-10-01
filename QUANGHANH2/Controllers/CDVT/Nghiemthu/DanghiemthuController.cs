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
using System.Globalization;

namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
{
    public class DanghiemthuController : Controller
    {
        [Auther(RightID = "26")]
        [Route("phong-cdvt/da-nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Nghiemthu/Danghiemthu.cshtml");
        }

        [Auther(RightID = "26")]
        [Route("phong-cdvt/da-nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string equimentid,string equimentname, string date_start, string date_end)
        {
            //Server Side Parameter
            string requestID = Request["sessionId"];
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            //int length = 2;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend> docList = new List<Documentary_Extend>();

            //DateTime dstart = DateTime.ParseExact(date_start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //
            if (date_start == "") date_start = "01/01/1900";
            DateTime dstart = DateTime.ParseExact(date_start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dend;
            if (date_end == "") dend = DateTime.Now;
            else dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dend = dend.AddHours(23);
            dend = dend.AddMinutes(59);

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                docList = (from a in db.Acceptances
                          
                           join b in db.Equipments on a.equipmentId equals b.equipmentId
                           where (a.equipmentStatus == 3) && (a.equipmentId.Contains(equimentid) && b.equipment_name.Contains(equimentname) && (a.acceptance_date >= dstart && a.acceptance_date <= dend))
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
                docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<Documentary_Extend>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}