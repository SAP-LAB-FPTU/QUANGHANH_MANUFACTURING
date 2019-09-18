using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class BGDKiemdinhController : Controller
    {
        [Route("ban-giam-doc/bao-cao-kiem-dinh")]
        public ActionResult Index()
        {
            return View("/Views/BGD/CDVT/bao_cao_kiem_dinh.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-kiem-dinh/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/kiemdinh.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "kiemdinh.xls");
        }
    }
}