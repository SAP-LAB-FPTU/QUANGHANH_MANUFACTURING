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

namespace QUANGHANH2.Controllers.CDVT.Nghiemthu
{
    public class VattukemtheoController : Controller
    {
        // GET: Vattukemtheo
        [Route("phong-cdvt/vat-tu-kem-theo")]
        public ActionResult Index(string id)
        {
            ViewBag.Vattukemtheo = id.ToString();
            string requestID = id;
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Supply_Extend> supList3 = new List<Supply_Extend>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                db.Configuration.LazyLoadingEnabled = false;
                supList3 = (from a in db.Supply_Documentary_Equipment
                           where (a.equipmentId == requestID) && (a.supplyType == 3)
                           join b in db.Supplies on a.supply_id equals b.supply_id
                           join c in db.Equipments on a.equipmentId equals c.equipmentId
                           join d in db.Acceptances on c.equipmentId equals d.equipmentId
                           select new
                           {
                               equipmentId = a.equipmentId,
                               supply_id = a.supply_id,
                               quantity = a.quantity,
                               supplyStatus = a.supplyStatus,
                               supply_name = b.supply_name,
                               unit = b.unit,
                               documentary_process_result = d.documentary_process_result


                           }).ToList().Select(p => new Supply_Extend
                           {
                               equipmentId = p.equipmentId,
                               supply_id = p.supply_id,
                               quantity = p.quantity,
                               supplyStatus = p.supplyStatus,
                               supply_name = p.supply_name,
                               unit = p.unit,
                               documentary_process_result = p.documentary_process_result

                           }).ToList();

                ViewBag.ListSup3 = supList3;

            }
            return View("/Views/CDVT/Nghiemthu/Vattuditheo.cshtml");
        }
    }
}