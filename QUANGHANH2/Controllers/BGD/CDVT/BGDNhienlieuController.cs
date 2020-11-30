using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDNhienlieuController : Controller
    {
        [Route("ban-giam-doc/bao-cao-nhien-lieu")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/FuelConsumption.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-nhien-lieu/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/nhienlieu.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "nhienlieu.xls");
        }
    }
}