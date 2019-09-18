using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDMaintainReportController : Controller
    {
        [Route("ban-giam-doc/bao-cao-bao-duong")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/MaintainReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-bao-duong/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/baoduong.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "baoduong.xls");
        }
    }
}