using OfficeOpenXml;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.AT
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