using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System.Collections.Generic;
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

        [Route("phong-cdvt/xin-cap-vat-tu-sctx")]
        public ActionResult Index()
        {
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

        [Route("phong-cdvt/xin-cap-vat-tu-sctx/submit")]
        [HttpPost]
        public ActionResult Submit(IList<XincapvattuModelView> vattus)
        {
            bool result = _repository.CreateVattus(vattus);
            return Json(new
            {
                success = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}