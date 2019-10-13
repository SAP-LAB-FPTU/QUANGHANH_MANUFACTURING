using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.DK.InputPlan
{
    public class InputPlan_MonthController : Controller
    {
        // GET: InputPlan_Month
        [Route("phong-dieu-khien/ke-hoach-san-xuat")]
        public ActionResult Index()
        {
            return View("/Views/DK/InputPlan/InputPlan_Month.cshtml");
        }
    }
}