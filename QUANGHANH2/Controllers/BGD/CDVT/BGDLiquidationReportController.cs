using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDLiquidationReportController : Controller
    {
        [Route("ban-giam-doc/bao-cao-thanh-ly")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/LiquidationReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-thanh-ly/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/thanhly.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "thanhly.xls");
        }
    }
}