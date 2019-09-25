using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.BGD
{
    public class SummaryReportController : Controller
    {
        // GET: /<controller>/
        [Auther(RightID ="005")]
        [Route("ban-giam-doc")]
        public ActionResult Index()
        {
            return View("/Views/BGD/Dashboard.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-nhanh-cong-tac-san-xuat")]
        public ActionResult QuickReportTCLD()
        {
            return View("/Views/BGD/QuickReport/bao-cao-nhanh-tcld.cshtml");
        }
        [Route("ban-giam-doc/bao-cao-nhanh-quan-ly-vat-tu")]
        public ActionResult QuickReportCDVT()
        {
            return View("/Views/BGD/QuickReport/bao-cao-nhanh-cdvt.cshtml");
        }

    }
}
