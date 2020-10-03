using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class MaterialProtectionController : Controller
    {
        [Route("phong-tcld/bao-ho-lao-dong/danh-sach-bhld-cua-cac-phan-xuong")]
        public ActionResult List()
        {
            ViewBag.nameDepartment = "nghiphep-baoholaodong";
            return View("/Views/TCLD/MaterialProtection/List.cshtml");
        }
    }
}