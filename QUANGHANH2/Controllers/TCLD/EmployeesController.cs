using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.TCLD
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        [Route("phong-tcld/danh-sach-toan-cong-ty")]
        public ActionResult ListAll()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/ListAll.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/xem-chi-tiet-nhan-vien")]
        public ActionResult ViewInfor()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/View.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/chinh-sua-nhan-vien")]
        public ActionResult Edit()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/Edit.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/danh-sach-nhan-vien")]
        public ActionResult List()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/List.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/them-nhan-vien")]
        public ActionResult Add()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/Add.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        public ActionResult WorkHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }
        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-chuyen")]
        public ActionResult TransferHistory()
        {
            ViewBag.nameDepartment = "baohiem";
            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
        }
        //[Route("phong-tcld/quan-ly-nhan-vien/tang-giam-nhan-vien")]
        //public ActionResult Frequency()
        //{
        //    ViewBag.nameDepartment = "baohiem";
        //    return View("/Views/TCLD/Brief/Frequency.cshtml");
        //}
    }
}