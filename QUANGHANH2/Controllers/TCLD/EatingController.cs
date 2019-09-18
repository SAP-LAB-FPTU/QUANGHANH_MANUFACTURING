using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class EatingController : Controller
    {
        // GET: Eating
        [Route("phong-tcld/dang-ky-suat-an")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Eating/Register.cshtml");
        }
    }
}