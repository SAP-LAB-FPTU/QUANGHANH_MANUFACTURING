using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.TCLD
{
    public class TCLDController : Controller
    {
        // GET: /<controller>/
        [Route("phong-tcld/")]
        public ActionResult Dashboard()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao-cao-nhanh.cshtml");
        }
        [Route("phong-tcld/bao-cao-nhanh-lao-dong-tien-luong-vtl1")]
        public ActionResult DetailReport()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao_cao_nhanh_tung_phan_xuong.cshtml");
        }

        [Route("phong-tcld/bao-cao-chi-tiet-ca-1")]
        public ActionResult Report1()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao_cao_chi_tiet_ca_1.cshtml");
        }
        [Route("phong-tcld/bao-cao-chi-tiet-ca-2")]
        public ActionResult Report2()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao_cao_chi_tiet_ca_2.cshtml");
        }
        [Route("phong-tcld/bao-cao-chi-tiet-ca-3")]
        public ActionResult Report3()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/bao_cao_chi_tiet_ca_3.cshtml");
        }

        [Route("phong-tcld/bien-ban-chung")]
        public ActionResult CommonRecord()
        {
            ViewBag.nameDepartment = "baocao-sanluon-laodong";
            return View("/Views/TCLD/CommonRecord.cshtml");
        }
        //[Route("~/{tenphong}/")]
        //public ActionResult Hocnt(String tenphong, [FromQuery] String ten)
        //{
        //    ViewBag.name = ten + tenphong;
        //    return View("Views/TCLD/bao-cao-nhanh.cshtml");
        //}
    }
}
