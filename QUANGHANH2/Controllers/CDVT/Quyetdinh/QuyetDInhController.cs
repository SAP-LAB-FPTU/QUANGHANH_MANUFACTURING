using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class QuyetDInhController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/dieu-dong")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Danh_sach_quyet_dinh_dieu_dong.cshtml");
        }
    }
}