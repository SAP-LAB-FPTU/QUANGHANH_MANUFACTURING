using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using QUANGHANH2.EntityResult;

namespace QUANGHANH2.Controllers.TCLD
{
    public class WorkHistoryController : Controller
    {
     
        //[Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        //public ActionResult WorkHistory()
        //{
        //    return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        //}

        [Route("phong-tcld/quan-ly-nhan-vien/lich-su-lam-viec")]
        public ActionResult workHistoryOfEmployee(string id)
        {
            try
            {
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
                GetShortEmployeeProfile_Result employee = db.Database.SqlQuery<GetShortEmployeeProfile_Result>
                    (@"[HumanResources].GetShortEmployeeProfile {0}", id).FirstOrDefault();
                ViewBag.employee = employee;
                ViewBag.error = 0;
               }
            catch (Exception e)
            {
                ViewBag.error = 1;
            }
            return View("/Views/TCLD/Brief/WorkHistory.cshtml");
        }

        [HttpPost]
        public ActionResult getDataHistoryWork(string id)
        {
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            try
            {
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    List<DiemDanh> listDiemDanhById = db.Database.SqlQuery<DiemDanh>("select h.NgayDiemDanh, h.Ca, d.GhiChu from Header_DiemDanh_NangSuat_LaoDong h inner join DiemDanh_NangSuatLaoDong d on h.HeaderID = d.HeaderID where d.MaNV = @MaNV order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY", new SqlParameter("MaNV", id)).ToList();
                    int totalrows = db.Database.SqlQuery<int>("select count(h.NgayDiemDanh) from Header_DiemDanh_NangSuat_LaoDong h inner join DiemDanh_NangSuatLaoDong d on h.HeaderID = d.HeaderID where d.MaNV = @MaNV", new SqlParameter("MaNV", id)).FirstOrDefault();

                    return Json(new { success = true, data = listDiemDanhById, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet); ;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private class DiemDanh
        {
            public DateTime NgayDiemDanh { get; set; }
            public int Ca { get; set; }
            public string GhiChu { get; set; }
        }

        
    }
}
