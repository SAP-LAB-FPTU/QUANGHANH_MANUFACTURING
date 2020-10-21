using System.Collections.Generic;
using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.AT
{
    public class ViewAccidentController : Controller
    {
        [Auther(RightID = "007")]
        [Route("phong-an-toan/danh-sach-tai-nan")]
        public ActionResult Index()
        {
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<NhanVien> listNhanVien = db.NhanViens.ToList<NhanVien>();
            ViewBag.listNhanVien = listNhanVien;
            return View("/Views/AT/ViewAccident.cshtml");
        }
    }
}