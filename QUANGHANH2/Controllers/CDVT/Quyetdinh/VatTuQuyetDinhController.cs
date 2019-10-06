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

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class VatTuQuyetDinhController : Controller
    {
        // GET: VatTuQuyetDinh
        [Route("phong-cdvt/vat-tu")]
        public ActionResult Index(string id, int doc)
        {
            ViewBag.Vattu = id.ToString();
            string requestID = id;
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Supply_Extend> supList = new List<Supply_Extend>();
            List<Supply_Extend> supList2 = new List<Supply_Extend>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {

                db.Configuration.LazyLoadingEnabled = false;
                supList = (from a in db.Supply_Documentary_Equipment
                           where (a.equipmentId == requestID) && (a.supplyType == 1) && (a.documentary_id == doc)
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

                ViewBag.ListSup = supList;
                supList2 = (from a in db.Supply_Documentary_Equipment
                           where (a.equipmentId == requestID) && (a.supplyType == 2) && (a.documentary_id == doc)
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
                ViewBag.ListSup2 = supList2;

            }
                return View("/Views/CDVT/Quyet_dinh/VatTuQuyetDinh.cshtml");
        }
    }
}

