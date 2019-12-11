using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Models;
namespace QUANGHANH2.Controllers.DK
{
    public class KHSXNamController : Controller
    {
        // GET: KHSXNam
        [Route("phong-dieu-khien/ke-hoach-san-xuat-nam")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities dbContext = new QUANGHANHABCEntities();
            List<TieuChi> listTieuChi = dbContext.Database.SqlQuery<TieuChi>("select * from TieuChi").ToList<TieuChi>();
            ViewBag.listTC = listTieuChi;
            return View("/Views/DK/KHSXNam.cshtml");
        }
    }
}