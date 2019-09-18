using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.KCS
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-kcs/bao-cao/bao-cao-chat-luong-than-san-xuat")]
        public ActionResult Report()
        {
            return View("/Views/KCS/Report/Report.cshtml");
        }
        [Route("phong-kcs/bao-cao/nhap-bao-cao")]
        public ActionResult Spreadsheet()
        {
            return View("/Views/KCS/Report/Spreadsheet.cshtml");
        }
        [Route("phong-kcs/bao-cao/sua-bao-cao")]
        public ActionResult EditReport()
        {
            return View("/Views/KCS/Report/EditReport.cshtml");
        }
    }

}