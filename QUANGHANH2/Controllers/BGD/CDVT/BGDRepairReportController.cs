using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDRepairReportController : Controller
    {
        [Route("ban-giam-doc/bao-cao-sua-chua")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/RepairReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-sua-chua/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/suachua.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "suachua.xls");
        }
    }
}