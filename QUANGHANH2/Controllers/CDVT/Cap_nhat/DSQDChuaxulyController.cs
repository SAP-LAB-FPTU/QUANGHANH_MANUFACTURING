﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.Cap_nhat
{
    public class DSQDDaxulyController : Controller
    {
        [Auther(RightID = "23")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Cap_nhat/DSQD.cshtml");
        }

        [Auther(RightID = "23")]
        [Route("phong-cdvt/cap-nhat/quyet-dinh/search")]
        [HttpPost]
        public ActionResult Search(string documentary_id, string type, string department, string reason, string dateStart, string dateEnd, string status)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = DateTime.ParseExact(dateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtEnd = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtEnd = dtEnd.AddHours(23);
            dtEnd = dtEnd.AddMinutes(59);
            string query = "SELECT docu.*, docu.[out/in_come] as out_in_come, depa.department_name FROM Documentary docu inner join Department depa on docu.department_id = depa.department_id" +
                " where docu.documentary_code IS NOT NULL and docu.date_created BETWEEN @start_time1 AND @start_time2 AND ";
            if (!documentary_id.Equals("") || !type.Equals("0") || !department.Equals("") || !reason.Equals("") || !status.Equals("0"))
            {
                if (!documentary_id.Equals("")) query += "docu.documentary_id LIKE @documentary_id AND ";
                if (!type.Equals("0")) query += "docu.documentary_type LIKE @documentary_type AND ";
                if (!department.Equals("")) query += "depa.department_name LIKE @department_name AND ";
                if (!reason.Equals("")) query += "docu.reason LIKE @reason AND ";
                if (!status.Equals("0")) query += "docu.documentary_status = @documentary_status AND ";
            }
            query = query.Substring(0, query.Length - 5);
            List<DocumentaryDB> incidents = DBContext.Database.SqlQuery<DocumentaryDB>(query,
                new SqlParameter("documentary_id", '%' + documentary_id + '%'),
                new SqlParameter("documentary_type", '%' + type + '%'),
                new SqlParameter("department_name", '%' + department + '%'),
                new SqlParameter("reason", '%' + reason + '%'),
                new SqlParameter("start_time1", dtStart),
                new SqlParameter("start_time2", dtEnd),
                new SqlParameter("documentary_status", status)
                ).ToList();
            int totalrows = incidents.Count;
            int totalrowsafterfiltering = incidents.Count;
            //sorting
            incidents = incidents.OrderBy(sortColumnName + " " + sortDirection).ToList<DocumentaryDB>();
            //paging
            incidents = incidents.Skip(start).Take(length).ToList<DocumentaryDB>();
            foreach (DocumentaryDB item in incidents)
            {
                item.linkIdCode = new LinkIdCode();
                switch (item.documentary_type)
                {
                    case "1":
                        item.stringtype = "Sửa chữa";
                        item.linkIdCode.link = "sua-chua";
                        break;
                    case "2":
                        item.stringtype = "Bảo dưỡng";
                        item.linkIdCode.link = "bao-duong";
                        break;
                    case "3":
                        item.stringtype = "Điều động";
                        item.linkIdCode.link = "dieu-dong";
                        break;
                    case "4":
                        item.stringtype = "Thu hồi";
                        item.linkIdCode.link = "thu-hoi";
                        break;
                    case "5":
                        item.stringtype = "Thanh lý";
                        item.linkIdCode.link = "thanh-ly";
                        break;
                    case "6":
                        item.stringtype = "Trung đại tu";
                        item.linkIdCode.link = "trung-dai-tu";
                        break;
                }
                switch (item.documentary_status)
                {
                    case 1:
                        item.stringstatus = "Đang xử lý";
                        break;
                    case 2:
                        item.stringstatus = "Đã xử lý chưa nghiệm thu";
                        break;
                    case 3:
                        item.stringstatus = "Đã nghiệm thu";
                        break;
                }
                item.stringdate = item.date_created.ToString("dd/MM/yyyy");
                item.linkIdCode.code = item.documentary_code;
                item.linkIdCode.id = item.documentary_id;
            }
            return Json(new { success = true, data = incidents, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
        }
    }
}