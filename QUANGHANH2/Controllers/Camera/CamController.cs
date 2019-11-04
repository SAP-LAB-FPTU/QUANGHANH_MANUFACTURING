using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.Camera
{
    public class CamController : Controller
    {
        [Route("camera")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/Camera/View.cshtml");
        }

       
    }
}