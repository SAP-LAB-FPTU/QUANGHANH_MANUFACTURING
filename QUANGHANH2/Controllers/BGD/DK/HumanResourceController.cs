using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.BGD.DK
{
    public class HumanResourceController : Controller
    {
        // GET: /<controller>/
        [Route("ban-giam-doc/bao-cao-nhan-luc-tham-gia-san-xuat")]
        public ActionResult Index()
        {
            return View("/Views/BGD/DK/MonthlyHumanResource.cshtml");
        }
    }
}
