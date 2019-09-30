using QUANGHANH2.ModelViews;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.SupportClass;
using QUANGHANH2.Utils;
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
        [Route("phan-xuong-doi-song/theo-doi-suat-an")]
        public ActionResult Index()
        {
            return View("/Views/PX/PXDS/View.cshtml");
        }

        [Auther(RightID = "145")]
        [HttpGet]
        [Route("phan-xuong-doi-song/dang-ky-suat-an")]
        public ActionResult Input()
        {
            var timeHelper = new TimeHelper();
            DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            ViewBag.MondayOfNextWeek = mondayOfNextWeek.Date.ToString("dd/MM/yyyy");
            ViewBag.FridayOfNextWeek = mondayOfNextWeek.AddDays(5).Date.ToString("dd/MM/yyyy");
            return View("/Views/PX/PXDS/Input.cshtml");
        }

        [Auther(RightID = "145")]
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

        [Auther(RightID = "145")]
        [HttpPost]
        [Route("phan-xuong-doi-song/dang-ky-suat-an/save")]
        public ActionResult RegistrationSave(IList<PxdsModelView> details)
        {
            var timeHelper = new TimeHelper();
            DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            bool success;
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