using System.Collections.Generic;
using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.ModelViews;
using QUANGHANH_MANUFACTURING.Repositories.Intefaces;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Vattu
{
    public class XincapvattuSummaryController : Controller
    {
        //Property of the type IRepository <TEnt, in TPk>
        private readonly IXincapvattuSummaryRepository _repository;

        public XincapvattuSummaryController(IXincapvattuSummaryRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "28")]
        [Route("phong-cdvt/xin-cap-vat-tu-sctx-summary")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Vattu/XincapvattuSummary.cshtml");
        }

        [Route("phong-cdvt/xin-cap-vat-tu-sctx-summary/all")]
        [HttpGet]
        public ActionResult All(string departmentId)
        {
            IList<XincapvattuSummaryModelViewVer2> vattus = _repository.GetVattus(departmentId);
            return Json(new
            {
                success = true,
                data = vattus,
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID ="28")]
        [Route("phong-cdvt/xin-cap-vat-tu-sctx-summary/departments")]
        [HttpGet]
        public ActionResult Departments(string departmentId)
        {
            IList<XincapvattuDepartmentSummaryModelView> departments = _repository.GetDepartments();
            return Json(new
            {
                success = true,
                data = departments,
            }, JsonRequestBehavior.AllowGet);
        }

        [Route("phong-cdvt/xin-cap-vat-tu-sctx-summary/submit")]
        [HttpPost]
        public ActionResult Submit(IList<XincapvattuSummaryModelView> values,string departmentid)
        {
            bool result = _repository.CreateSupplyConsumable(values,departmentid);
            return Json(new
            {
                success = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}