using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Occupation
{
    public class SideOccupationController : Controller
    {
        [Route("phong-tcld/quan-ly-dien-cong-viec")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Occupation/SideOccupation.cshtml");
        }
    }
}