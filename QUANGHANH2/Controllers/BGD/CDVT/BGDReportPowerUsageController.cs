using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDReportPowerUsageController : Controller
    {
        [Route("ban-giam-doc/bao-cao-dien-nang")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/QuarterPowerUsage.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-dien-nang/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/diennang.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "diennang.xls");
        }
    }
}