using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class MaintainReportController : Controller
    {
        [Route("phong-cdvt/bao-cao/bao-duong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Report/MaintainReport.cshtml");
        }
        [Route("phong-cdvt/bao-cao/bao-duong/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/baoduong.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "baoduong.xls");
        }
    }
}