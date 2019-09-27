using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class TieuhaoController : Controller
    {
        private readonly ITieuhaoRepository _repository;

        public TieuhaoController(ITieuhaoRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "35")]
        [Route("phong-cdvt/vat-tu/tieu-hao")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/Tieuhao.cshtml");
        }

        [Auther(RightID = "35")]
        [HttpGet]
        [Route("phong-cdvt/vat-tu/tieu-hao/details")]
        public ActionResult Details(string SupplyId, string SupplyName, string DepartmentId, string DeparmentName)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            var search = new TieuhaoSearchModelView {
                SupplyId = SupplyId.Trim(),
                SupplyName = SupplyName.Trim(),
                DepartmentId = DepartmentId.Trim(),
                DeparmentName = DeparmentName.Trim()
            };
            var details = _repository.GetDetails(search);
            int recordsTotal = details.Count;
            int recordsFiltered = details.Count;
            details = details.Skip(start).Take(length).ToList();
            // calc SupplyInventory
            foreach(var detail in details)
            {
                detail.SupplyInventory = detail.SupplyQuantity - detail.SupplyUsed;
            }
            return Json(new
            {
                success = true,
                data = details,
                recordsTotal,
                recordsFiltered
            }, JsonRequestBehavior.AllowGet);
        }
    }
}