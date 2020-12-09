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
                    List<GetWorkHistory_Result> listDiemDanhById = db.Database.SqlQuery<GetWorkHistory_Result>
                        (@"[Manufacturing].GetWorkHistory {0}, {1}, {2}, {3}, {4}", 
                        id, sortDirection, sortColumnName, start, length).ToList();
                    int totalrows = db.Database.SqlQuery<int>
                        (@"[Manufacturing].GetCountWorkHistory {0}", id).FirstOrDefault();

                    return Json(new { success = true, data = listDiemDanhById, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet); ;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
