using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDWaterController : Controller
    {
        [Route("ban-giam-doc/bao-cao-thoat-nuoc")]
        public ActionResult Water()
        {
            return View("/Views/BGD/CDVT/WaterReport.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-thoat-nuoc/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/thoatnuoc.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "thoatnuoc.xls");
        }
    }
}