using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class ReportPowerUsageController : Controller
    {
        [Route("phong-cdvt/bao-cao/dien-nang")]
        public ActionResult Quarter()
        {
            return View("/Views/CDVT/Report/QuarterPowerUsage.cshtml");
        }
        [Route("phong-cdvt/bao-cao/dien-nang/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/diennang.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "diennang.xls");
        }
    }
}