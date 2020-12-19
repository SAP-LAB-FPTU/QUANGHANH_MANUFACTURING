using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.Camera
{
    public class DSQDChuaxulyController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/xu-ly")]
        public ActionResult Index()
        {
            return View("/Views/Camera/Quyetdinh/DSQDChuaxuly.cshtml");
        }

        [Route("phong-cdvt/camera/xu-ly")]
        [HttpPost]
        public ActionResult Search(string documentary_id, string department, string reason, string dateStart, int status)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<DocumentaryDB> incidents;

            DateTime dtStart_0 = new DateTime();
            DateTime dtStart_1 = new DateTime();

            if (dateStart.Contains("-"))
            {
                var temp = dateStart.Split('-');
                dtStart_0 = DateTime.ParseExact(temp[0].Trim(), "dd/MM/yyyy", null);
                dtStart_1 = DateTime.ParseExact(temp[1].Trim(), "dd/MM/yyyy", null).AddDays(1);
            }
            else if (!string.IsNullOrEmpty(dateStart))
            {
                dtStart_0 = DateTime.ParseExact(dateStart, "dd/MM/yyyy", null);
                dtStart_1 = dtStart_0.AddDays(1);
            }

            incidents = (from docu in db.Documentaries
                         join depa in db.Departments on docu.department_id_to equals depa.department_id
                         join type in db.DocumentaryTypes on docu.documentary_type equals type.documentary_type
                         where !String.IsNullOrEmpty(docu.documentary_code) && docu.documentary_status != 3 && docu.documentary_type == 8
                         && docu.documentary_code.Contains(documentary_id) && depa.department_name.Contains(department) && docu.reason.Contains(reason) 
                         && (status == 0 || docu.documentary_status == status)
                         && (string.IsNullOrEmpty(dateStart) || (docu.date_created >= dtStart_0 && docu.date_created < dtStart_1))
                         select new DocumentaryDB
                         {
                             documentary_id = docu.documentary_id,
                             documentary_code = docu.documentary_code,
                             documentary_name = type.documentary_name,
                             department_name = depa.department_name,
                             date_created = docu.date_created,
                             person_created = docu.person_created,
                             reason = docu.reason,
                             out_income = docu.out_income,
                         }).ToList();

            int totalrows = (from docu in db.Documentaries
                             join depa in db.Departments on docu.department_id_to equals depa.department_id
                             join type in db.DocumentaryTypes on docu.documentary_type equals type.documentary_type
                             where !String.IsNullOrEmpty(docu.documentary_code) && docu.documentary_status != 3 && docu.documentary_type == 8
                             && docu.documentary_code.Contains(documentary_id) && depa.department_name.Contains(department) && docu.reason.Contains(reason)
                             && (status == 0 || docu.documentary_status == status)
                             && (string.IsNullOrEmpty(dateStart) || (docu.date_created >= dtStart_0 && docu.date_created < dtStart_1))
                             select docu).Count();

            incidents.ForEach(x => x.stringdate = x.date_created.ToString("dd/MM/yyyy"));
            return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }
    }
}