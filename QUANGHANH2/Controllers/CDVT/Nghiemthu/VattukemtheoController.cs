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
        public ActionResult Index(string id, int doc)
        {
            //ViewBag.Vattukemtheo = id.ToString();
            string requestID = id;

            List<Supply_Extend> supList3 = new List<Supply_Extend>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                db.Configuration.LazyLoadingEnabled = false;
                supList3 = (from a in db.Supply_Documentary_Equipment
                           where (a.equipmentId == requestID) && (a.supplyType == 3) && (a.documentary_id == doc)
                            join b in db.Supplies on a.supply_id equals b.supply_id
                           select new
                           {
                               equipmentId = a.equipmentId,
                               supply_id = a.supply_id,
                               quantity = a.quantity,
                               supplyStatus = a.supplyStatus,
                               supply_name = b.supply_name,
                               unit = b.unit


                           }).ToList().Select(p => new Supply_Extend
                           {
                               equipmentId = p.equipmentId,
                               supply_id = p.supply_id,
                               quantity = p.quantity,
                               supplyStatus = p.supplyStatus,
                               supply_name = p.supply_name,
                               unit = p.unit

                           }).ToList();

                ViewBag.ListSup3 = supList3;

            }
            return View("/Views/CDVT/Nghiemthu/Vattuditheo.cshtml");
        }
    }
}