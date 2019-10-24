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
        [Route("phong-kcs")]
        public ActionResult Report()
        {
            Response.Redirect("phong-kcs/bao-cao/bao-cao-len-dk");
            return null;
        }
        [Route("phong-kcs/nhap-ke-hoach-san-xuat")]
        public ActionResult NhapKHSX()
        {
            return View("/Views/KCS/NhapKeHoach/InputPlan_Month.cshtml");
        }
        //[Route("phong-kcs/bao-cao/nhap-bao-cao")]
        //public ActionResult Spreadsheet()
        //{
        //    return View("/Views/KCS/Report/Spreadsheet.cshtml");
        //}
        //[Route("phong-kcs/bao-cao/sua-bao-cao")]
        //public ActionResult EditReport()
        //{
        //    return View("/Views/KCS/Report/EditReport.cshtml");
        //}
    }

}