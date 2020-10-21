using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.DK
{
    public class KeHoachKyThuatController : Controller
    {
        // GET: KeHoachKyThuat
        [Route("phong-dieu-khien/ke-hoach-san-xuat")]
        public ActionResult Index()
        {
            return View("/Views/DK/ke_hoach_san_xuat.cshtml");
        }
    }
}