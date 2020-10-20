using QUANGHANH_MANUFACTURING.Models;
using QUANGHANH_MANUFACTURING.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH_MANUFACTURING.Controllers.TCLD.Certificates
{
    public class ReportController : Controller
    {
        [Auther(RightID = "149")]
        [Route("phong-tcld/chung-chi/bao-cao-chung-chi")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Certificate/Report.cshtml");
        }

        [Auther(RightID = "149")]
        [HttpPost]
        [Route("phong-tcld/chung-chi/bao-cao-chung-chi")]
        public ActionResult List()
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                string query = @"select c.TenChungChi, CONVERT(varchar, cn.NgayCap, 103) as NgayCap, CONVERT(varchar, DATEADD(MONTH, c.ThoiHan, cn.NgayCap), 103) as NgayHetHan, COUNT(*) as SoLuong from ChungChi c
                    join ChungChi_NhanVien cn on c.MaChungChi = cn.MaChungChi
                    WHERE c.TenChungChi like @TenChungChi
                    GROUP BY c.TenChungChi, cn.NgayCap, c.ThoiHan";

                var listdata = db.Database.SqlQuery<BaoCaoChungChi>(query +
                    " ORDER BY " + sortColumnName + " " + sortDirection +
                    " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY", 
                    new SqlParameter("TenChungChi", "%" + Request["TenChungChi"] + "%")).ToList();

                int totalrows = db.Database.SqlQuery<int>("select count(*) from (" + query + ") as d",
                    new SqlParameter("TenChungChi", "%" + Request["TenChungChi"] + "%")).FirstOrDefault();

                return Json(new { success = true, data = listdata, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows });
            }
        }

        private class BaoCaoChungChi
        {
            public string TenChungChi { get; set; }
            public string NgayCap { get; set; }
            public string NgayHetHan { get; set; }
            public int SoLuong { get; set; }
        }
    }
}