using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ChonThietBiController : Controller
    {
        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/chon-thiet-bi")]
        public ActionResult Index()
        {
            ViewBag.selected = Request["selected"] ?? "{}";
            return View("/Views/CDVT/Quyetdinh/SuaChua/ChonThietBi.cshtml");
        }

        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/chon-thiet-bi")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string department_name, string equipmentName)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                string query = "SELECT e.equipmentId, e.equipment_name, d.department_name, s.statusname " + 
                    "FROM Equipment e inner join Department d on e.department_id = d.department_id " +
                    "inner join Status s on e.current_Status = s.statusid where e.isAttach = 0 AND ";
                if (!equipmentId.Equals("")) query += "e.equipmentId LIKE @equipmentId AND ";
                if (!equipmentName.Equals("")) query += "e.equipment_name LIKE @equipment_name AND ";
                if (!department_name.Equals("")) query += "d.department_name LIKE @department_name AND ";
                query = query.Substring(0, query.Length - 5);
                List<BigEquip> equipList = db.Database.SqlQuery<BigEquip>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).ToList();

                int totalrows = db.Database.SqlQuery<int>(query.Replace("e.equipmentId, e.equipment_name, d.department_name, s.statusname", "count(*)"),
                    new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                    new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                    new SqlParameter("department_name", '%' + department_name + '%')).FirstOrDefault();
                return Json(new { success = true, data = equipList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }

        private class BigEquip
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string department_name { get; set; }
            public string statusname { get; set; }
        }
    }
}