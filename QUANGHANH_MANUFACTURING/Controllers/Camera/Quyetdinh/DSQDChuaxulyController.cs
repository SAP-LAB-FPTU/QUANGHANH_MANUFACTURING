using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.Models;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.Camera.Quyetdinh
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
        public ActionResult Search(string documentary_id, string department, string reason, string dateStart, string dateEnd, string status)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            List<DocumentaryDB> incidents;

            string query = @"SELECT docu.*, docu.[out/in_come] as out_in_come, [type].documentary_name, depa.department_name FROM Documentary docu 
                inner join Department depa on docu.department_id_to = depa.department_id
                inner join DocumentaryType [type] on docu.documentary_type = [type].documentary_type
                where docu.documentary_code IS NOT NULL AND docu.documentary_status != 3 AND docu.documentary_type = 8 AND ";
            if (!documentary_id.Equals("")|| !department.Equals("") || !reason.Equals("") || !status.Equals("0") || !(dateStart.Equals("") || dateEnd.Equals("")))
            {
                if (!dateStart.Equals("") && !dateEnd.Equals(""))
                {
                    DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dtEnd = dtEnd.AddHours(23);
                    dtEnd = dtEnd.AddMinutes(59);
                    query += "docu.date_created BETWEEN '" + dtStart + "' AND '" + dtEnd + "' AND ";
                }
                if (!documentary_id.Equals("")) query += "docu.documentary_code LIKE @documentary_id AND ";
                if (!department.Equals("")) query += "depa.department_name LIKE @department_name AND ";
                if (!reason.Equals("")) query += "docu.reason LIKE @reason AND ";
                if (!status.Equals("0")) query += "docu.documentary_status = @documentary_status AND ";
            }
            query = query.Substring(0, query.Length - 5);
            incidents = DBContext.Database.SqlQuery<DocumentaryDB>(query + " order by " + sortColumnName + " " + sortDirection + " offset " + start + " rows fetch next " + length + " rows only",
                new SqlParameter("documentary_id", '%' + documentary_id + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("documentary_status", status)
                ).ToList();

            int totalrows = DBContext.Database.SqlQuery<int>(query.Replace("docu.*, docu.[out/in_come] as out_in_come, [type].documentary_name, depa.department_name", "count(documentary_id)"),
                new SqlParameter("documentary_id", '%' + documentary_id + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("documentary_status", status)
                ).FirstOrDefault();

            foreach (DocumentaryDB item in incidents)
            {
                switch (item.documentary_status)
                {
                    case 1:
                        item.stringstatus = "Đang xử lý";
                        break;
                    case 2:
                        item.stringstatus = "Đã xử lý chưa nghiệm thu";
                        break;
                }
                item.stringdate = item.date_created.ToString("dd/MM/yyyy");
            }
            return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }
    }
}