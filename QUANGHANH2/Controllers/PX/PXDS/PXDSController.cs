using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.PX.PXDS
{
    public class PxdsController : Controller
    {
        private readonly IPxdsRepository _repository;

        public PxdsController(IPxdsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        [Route("phan-xuong-doi-song/thong-ke-suat-an")]
        public ActionResult Index()
        {
            return View("/Views/PX/PXDS/View.cshtml");
        }

        [HttpGet]
        [Route("phan-xuong-doi-song/dang-ky-suat-an")]
        public ActionResult Input()
        {
            return View("/Views/PX/PXDS/Input.cshtml");
        }

        [HttpGet]
        [Route("phan-xuong-doi-song/dang-ky-suat-an/details")]
        public ActionResult RegistrationDetail()
        {
            var details = _repository.GetDetails();
            return Json(new
            {
                success = true,
                data = details
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("phan-xuong-doi-song/dang-ky-suat-an/save")]
        public ActionResult RegistrationSave(IList<PxdsModelView> details)
        {
            bool success = true;
            DateTime mondayOfNextWeek = _repository.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            if (_repository.HasMealRegistration(mondayOfNextWeek))
            {
                success = _repository.UpdateMealRegistration(details);
            }
            else
            {
                success = _repository.SaveMealRegistration(details);
            }
            return Json(new { success }, JsonRequestBehavior.AllowGet);
        }
    }
}