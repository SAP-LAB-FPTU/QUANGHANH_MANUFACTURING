using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class RecruitmentAndEndController : Controller
    {

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cac-don-vi-cham-dut-tuyen-dung")]
        public ActionResult RecruitmentAndEnd()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/RecruitmentAndEnd.cshtml");
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-tuyen-dung")]
        public ActionResult Recruitment()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/Recruitment.cshtml");
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tong-hop-cham-dut")]
        public ActionResult End()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/End.cshtml");
        }

        [Route("phong-tcld/cham-dut-va-tuyen-dung/tang-giam-lao-dong")]
        public ActionResult ListFrequency()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/ListFrequency.cshtml");
        }
        [Route("phong-tcld/cham-dut-va-tuyen-dung/tang-giam-lao-dong/theo-quy")]
        public ActionResult Frequency()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/ReportRecruitmentAndEnd/Frequency.cshtml");
        }
    }
}