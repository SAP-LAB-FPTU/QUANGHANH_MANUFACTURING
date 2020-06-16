using QUANGHANH2.Models;
using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.SupportClass;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Vattu
{
    public class XincapvattuController : Controller
    {
        //Property of the type IRepository <TEnt, in TPk>
        private readonly IXincapvattuRepository _repository;
        public XincapvattuController(IXincapvattuRepository repo)
        {
            _repository = repo;
        }

        [Auther(RightID = "33,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/xin-cap-vat-tu-sctx")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply> supplies = DBContext.Supplies.ToList();
            ViewBag.Supplies = supplies;
            return View("/Views/CDVT/Vattu/Xincapvattu.cshtml");
        }

        [Route("phong-cdvt/xin-cap-vat-tu-sctx/all")]
        [HttpGet]
        public ActionResult All()
        {
            IList<XincapvattuModelView> vattus = _repository.Vattus();
            return Json(new
            {
                success = true,
                data = vattus,
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "33,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/xin-cap-vat-tu-sctx/submit")]
        [HttpPost]
        public ActionResult Submit(IList<XincapvattuModelView> vattus)
        {
            bool result;
            if (_repository.HasDraft())
            {
                result = _repository.UpdateVattuStatus(vattus);
            }
            else
            {
                result = _repository.CreateVattus(vattus);
            }
            return Json(new
            {
                success = result
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "33,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/xin-cap-vat-tu-sctx/update")]
        [HttpPost]
        public ActionResult Update(IList<XincapvattuModelView> vattus)
        {
            bool result = _repository.UpdateVattus(vattus);
            return Json(new
            {
                success = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}