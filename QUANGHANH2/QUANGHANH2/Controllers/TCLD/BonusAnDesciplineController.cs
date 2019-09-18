using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BonusAnDesciplineController : Controller
    {
        [Route("phong-tcld/khen-thuong")]
        [HttpGet]
        public ActionResult Bonus()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/BonusAndDiscipline/KhenThuong.cshtml");
        }
        [Route("phong-tcld/ky-luat")]
        [HttpGet]
        public ActionResult Discipline()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/BonusAndDiscipline/KyLuat.cshtml");
        }
    }
}