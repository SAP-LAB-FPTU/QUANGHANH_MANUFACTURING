using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT
{
    public class VatTuQuyetDinhController : Controller
    {
        // GET: VatTuQuyetDinh
        [Route("phong-cdvt/vat-tu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/VatTuQuyetDinh.cshtml");
        }
    }
}