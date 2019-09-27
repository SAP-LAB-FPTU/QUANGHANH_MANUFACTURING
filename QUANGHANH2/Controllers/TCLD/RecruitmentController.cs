using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class RecruitmentController : Controller
    {
        // GET: Recruitment
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Recruitment/Input.cshtml");
        }
    }
}