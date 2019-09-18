using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class BriefController : Controller
    {
        // GET: /<controller>/
        [Route("phong-tcld/ho-so/xem-chi-tiet-ho-so")]
        public ActionResult ViewInfor()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/View.cshtml");
        }
        [Route("phong-tcld/ho-so/chinh-sua-ho-so")]
        public ActionResult Edit()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/Edit.cshtml");
        }
        [Route("phong-tcld/ho-so/danh-sach-ho-so")]
        public ActionResult List()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/List.cshtml");
        }
        [Route("phong-tcld/ho-so/them-ho-so")]
        public ActionResult Add()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/Add.cshtml");
        }
        [Route("phong-tcld/ho-so/lich-su-lam-viec")]
        public ActionResult WorkHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }
        [Route("phong-tcld/ho-so/chi-tiet-dieu-chuyen")]
        public ActionResult TransferHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
        }
    }
}
