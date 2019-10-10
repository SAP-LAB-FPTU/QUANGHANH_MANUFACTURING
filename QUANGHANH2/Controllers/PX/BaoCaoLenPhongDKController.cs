using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.PX.PXKT
{
    public class BaoCaoLenPhongDKController : Controller
    {
        // GET: BaoCaoLenPhongDK
        public ActionResult Index()
        {
            return View();
        }
        [Route("phan-xuong-khai-thac/bao-cao-len-phong-dieu-khien")]
        public ActionResult Detail()
        {
            return View("/Views/Phanxuong/NhapBaoCao/PXKT.cshtml");
        }
    }
}