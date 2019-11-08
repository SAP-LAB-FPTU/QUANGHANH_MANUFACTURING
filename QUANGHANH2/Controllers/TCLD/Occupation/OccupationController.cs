using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class OccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-cong-viec")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Occupation/Occupation.cshtml");
        }
    }
}