using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class RepairReportController : Controller
    {
        [Route("phong-cdvt/bao-cao/sua-chua")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/RepairReport.cshtml");
        }
        [Route("phong-cdvt/bao-cao/sua-chua/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/suachua.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "suachua.xls");
        }
    }
}