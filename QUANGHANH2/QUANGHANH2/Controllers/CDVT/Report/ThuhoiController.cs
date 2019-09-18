using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class ThuhoiController : Controller
    {
        [Route("phong-cdvt/bao-cao/thu-hoi")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/bao_cao_thu_hoi.cshtml");
        }
        [Route("phong-cdvt/bao-cao/thu-hoi/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/thuhoi.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "thuhoi.xls");
        }
    }
}