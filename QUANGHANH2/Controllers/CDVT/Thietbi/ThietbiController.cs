using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Views.CDVT
{
    public class CarController : Controller
    {
        public ActionResult Chitiet()
        {
            return View("/Views/CDVT/Car/Details.cshtml");
        }
        public ActionResult Dangkiem()
        {
            return View("/Views/CDVT/Car/Maintenance.cshtml");
        }
        public ActionResult Suco()
        {
            return View("/Views/CDVT/Car/Accident.cshtml");
        }
        public ActionResult Baoduong()
        {
            return View("/Views/CDVT/Car/Bao_duong_sua_chua.cshtml");
        }
        public ActionResult Lylich()
        {
            return View("/Views/CDVT/Car/Details.cshtml");
        }
        public ActionResult Hoatdong()
        {
            return View("/Views/CDVT/Hoat_dong.cshtml");
        }
    }
}