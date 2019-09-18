using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.Phanxuong.phanxuong
{
    public class PhanXuongController : Controller
    {
        [Route("phan-xuong")]
        public ActionResult Index()
        {
            return View("/Views/Phanxuong/phanxuong.cshtml");
        }
        
    }
}