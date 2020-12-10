using QUANGHANH2.EntityResult;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD.Employees
{
    public class TransferHistoryController : Controller
    {
        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
        [HttpGet]
        public ActionResult TransferHistoryget(string ddid)
        {
            ViewBag.ddid = ddid;
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            Employee employee = db.Employees.Where(x => x.employee_id == ddid).FirstOrDefault();
            ViewBag.checker = 1;
            if (employee != null)
            {
                ViewBag.name = employee.BASIC_INFO_full_name.ToUpper();
            }
            else
            {
                ViewBag.checker = 0;
            }
            return View("/Views/TCLD/Brief/TransferHistory.cshtml");
        }

        [Route("phong-tcld/quan-ly-nhan-vien/chi-tiet-dieu-dong")]
        [HttpPost]
        public ActionResult TransferHistory()
        {
            try
            {

                var ddid = Request["ddid"];
                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                int border = 2147483647;
                var temp = @"[HumanResources].[GetTranferHistory] {0}, {1}, {2}, {3}, {4}";
                List<GetTranferHistory_Result> newlist = db.Database.SqlQuery<GetTranferHistory_Result>
                    (temp, ddid, start, length, sortDirection, sortColumnName).ToList();
                int totalrows = db.Database.SqlQuery<GetTranferHistory_Result>
                    (temp, ddid, start, border, sortDirection, sortColumnName).ToList().Count();
                return Json(new { data = newlist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { data = "", draw = Request["draw"], recordsTotal = 0, recordsFiltered = 0 }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}