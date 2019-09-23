using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class WaterController : Controller
    {
        [Route("phong-cdvt/bao-cao/thoat-nuoc")]
        public ActionResult Water()
        {
            return View("/Views/CDVT/Report/WaterReport.cshtml");
        }
        [Route("phong-cdvt/bao-cao/thoat-nuoc/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/thoatnuoc.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "thoatnuoc.xls");
        }
    }
}